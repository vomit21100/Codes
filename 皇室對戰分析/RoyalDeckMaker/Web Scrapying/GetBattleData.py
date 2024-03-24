import requests
import time
import json
import random
import os
import pathlib
import pandas as pd
import numpy as np
from lxml import html
from bs4 import BeautifulSoup as bs
from datetime import date
from GetWebCookies import Get_cookie

headers = {}

current_working_path = os.getcwd()
this_file_path = pathlib.Path(__file__).parent.resolve()


def Set_headers(user_email, user_password):
    #Add cookie value into headers
    cookie = Get_cookie(user_email, user_password)
    headers['user-agent'] = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36 Edg/109.0.1518.78'
    headers['accept'] = 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9'
    headers['cookie'] = cookie

def Get_player_id(user_email, user_password):
    #Get top 1000 player's ID
    response = requests.get('https://royaleapi.com/players/leaderboard', headers = headers)
    soup = bs(response.text, "html.parser")

    data = soup.select('script')

    data = data[15]
    text = data.get_text()
    start = text.find('[')-1
    end = text.rfind(']')+1

    JsonData = json.loads(text[start : end])

    return JsonData

def Get_battles(user_email, user_password):
    #Set headers
    Set_headers(user_email, user_password)

    #Make a new folder
    folder = '../data/Battles/{Datetime}/'.format(Datetime = date.today().strftime("%Y-%m-%d"))
    if not os.path.exists(folder):
        os.mkdir(folder)

    #Start downloading data into folder that created in previous step
    index = 0
    PlayerData = Get_player_id(user_email, user_password)
    for i in PlayerData:
        print(index, i['tag'])
        url = 'https://royaleapi.com/player/' + i['tag'] + '/battles/csv'
        data = requests.get(url, headers = headers)
        with open(folder + i['tag'] + '.csv', 'wb') as file:
            file.write(data.content)
            file.close()
        time.sleep(random.randint(10, 30))
        index += 1

def Merge_data():
    wanted = ['type','battleTime',
              'team_0_tag',    'team_0_crowns',
              'opponent_0_tag','opponent_0_crowns',
              'team_0_evolution_count', 'team_0_cards_0_name', 'team_0_cards_1_name', 'team_0_cards_2_name', 'team_0_cards_3_name', 'team_0_cards_4_name', 'team_0_cards_5_name', 'team_0_cards_6_name', 'team_0_cards_7_name', 'team_0_supportCards_0_name',
              'opponent_0_evolution_count', 'opponent_0_cards_0_name', 'opponent_0_cards_1_name', 'opponent_0_cards_2_name', 'opponent_0_cards_3_name', 'opponent_0_cards_4_name', 'opponent_0_cards_5_name', 'opponent_0_cards_6_name', 'opponent_0_cards_7_name', 'opponent_0_supportCards_0_name',]

    team_0_evolution = ['team_0_cards_0_evolutionLevel', 'team_0_cards_1_evolutionLevel', 'team_0_cards_2_evolutionLevel', 'team_0_cards_3_evolutionLevel', 'team_0_cards_4_evolutionLevel', 'team_0_cards_5_evolutionLevel', 'team_0_cards_6_evolutionLevel', 'team_0_cards_7_evolutionLevel']
    opponent_0_evolution = ['opponent_0_cards_0_evolutionLevel', 'opponent_0_cards_1_evolutionLevel', 'opponent_0_cards_2_evolutionLevel', 'opponent_0_cards_3_evolutionLevel', 'opponent_0_cards_4_evolutionLevel', 'opponent_0_cards_5_evolutionLevel', 'opponent_0_cards_6_evolutionLevel', 'opponent_0_cards_7_evolutionLevel']

    #Get all downloaded data
    os.chdir('../data/Battles')
    folders = os.listdir()
    folders.remove('Merged')

    Merged = os.listdir('Merged')

    for folder in folders:
        #Check if data in this had been process yet
        if folder + '.csv' in Merged:
            continue

        df = pd.DataFrame()
        files = len(os.listdir(folder))
        processing = 1
        for i in os.listdir(folder):
            print('Processing:', folder, str(processing), '/', str(files), i)
            processing += 1

            try:
                #Read files
                df1 = pd.read_csv(folder + '/' + i, index_col=False)

                #keep only 1v1 data
                fliter = (df1['type'] == 'pathOfLegend')
                df1 = df1[fliter]

                df = pd.concat([df, df1])

            except ValueError as err:
                print('Error occurred when reading {}'.format(i))


        #Fill up missing columns
        df.reset_index(inplace=True, drop=True)
        fill_missing_columns = pd.DataFrame(None, columns= (wanted + team_0_evolution + opponent_0_evolution))
        df = pd.concat([df, fill_missing_columns])

        #Count how many evolution each deck used
        team_count = df[team_0_evolution].sum(axis=1).astype(int)
        opponent_count = df[opponent_0_evolution].sum(axis=1).astype(int)

        df['team_0_evolution_count'] = team_count
        df['opponent_0_evolution_count'] = opponent_count

        #Adjust card name to evolution type
        team_filter = (df[team_0_evolution] == 1)
        opponent_filter = (df[opponent_0_evolution] == 1)

        for col in range(team_filter.shape[1]):     #For team deck
            filter_column = team_filter.iloc[:, col]
            team_column = wanted[col + 7]       #columns for 'team_0_cards_0_name'...
            df.loc[filter_column, team_column] = 'Evol ' + df.loc[filter_column, team_column]

        for col in range(opponent_filter.shape[1]):     #For opponent deck
            filter_column = opponent_filter.iloc[:, col]
            opponent_column = wanted[col + 17]       #columns for 'opponent_0_cards_0_name'...
            df.loc[filter_column, opponent_column] = 'Evol ' + df.loc[filter_column, opponent_column]

        #Clean data
        df = df[wanted]
        df = df.drop_duplicates(subset=['battleTime'])

        #Adjust data, make winner deck ahead
        team_info = df.columns[2:4]
        opponent_info = df.columns[4:6]
        team_deck = df.columns[6:16]
        opponent_deck = df.columns[16:26]
        need_swap = (df['opponent_0_crowns'] > df['team_0_crowns'])

        df.loc[need_swap, np.append(team_info, opponent_info)] = df.loc[need_swap, np.append(opponent_info, team_info)].values
        df.loc[need_swap, np.append(team_deck, opponent_deck)] = df.loc[need_swap, np.append(opponent_deck, team_deck)].values
        
        #Fill up null data
        
        df['team_0_supportCards_0_name'].fillna('Tower Princess', inplace=True)
        df['opponent_0_supportCards_0_name'].fillna('Tower Princess', inplace=True)
    
        df.to_csv('./Merged/{}.csv'.format(folder), encoding='utf-8', index=False)


if __name__== '__main__':
    #Move working directory to this file directory
    os.chdir(this_file_path)

    Get_battles('@gmail.com', '')
    Merge_data()

    #Move working directory back
    os.chdir(current_working_path)