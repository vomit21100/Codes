import os
import datetime
import pandas as pd
import numpy as np
from mlxtend.frequent_patterns import fpgrowth

#Empty dataframe
df = pd.DataFrame()

#Empty deck
deck = []
exclude = []

def Read_data(Time_range:list=[]):
    #Use global variable
    global df

    #Choose data base on time
    all_data = os.listdir('./data/Battles/Merged')
    if Time_range == []:
        data_file = all_data
    else:
        data_file = []
        for file in all_data:
            data_time = datetime.datetime.strptime(file[:-4], '%Y-%m-%d')   #exclude '.csv'
            if data_time >= Time_range[0] and data_time <= Time_range[1]:
                data_file.append(file)

    #Load in data
    for file in data_file:
        file_path = './data/Battles/Merged/{}'.format(file)
        df1 = pd.read_csv(file_path)
        df = pd.concat([df, df1])

    #In case there has any duplicate data
    df = df.drop_duplicates(subset=['battleTime'])

#Read all cards data and get names of all champion cards
#Used in Filter_data() to filter champion cards out
def Get_champion_data():
    #Read cards data
    card_data = pd.read_csv('./data/Cards/cards.csv')

    filter = (card_data['Rarity'] == 'Champion')

    return card_data.loc[filter, 'Name'].values

#Delete redundant data
def Filter_data(cards:list=[], evolution = 1, champion = 1):
    #Use global variable
    global df

    #Filter base on selected card
    team_deck = df.columns[6:16]
    team_filter = (df[team_deck].isin(cards).sum(axis=1) == len(cards))

    opponent_deck = df.columns[16:26]
    opponent_filter = (df[opponent_deck].isin(cards).sum(axis=1) == len(cards))

    #specifiy use evolution card or not
    #might have 0 data after filter

    #Use evolution card, value of 'evolution' indeicate how many evolutions would be used
    team_UseEvolution = (df['team_0_evolution_count'] <= evolution)
    opponent_UseEvolution = (df['opponent_0_evolution_count'] <= evolution)

    #same step as previous but for champion cards
    champion_cards = Get_champion_data()
    team_UseChampion = (df[team_deck].isin(champion_cards).sum(axis=1) <= champion)
    opponent_UseChampion = (df[opponent_deck].isin(champion_cards).sum(axis=1) <= champion)

    team_filter = ((team_filter & team_UseChampion & team_UseEvolution) | (opponent_filter & opponent_UseEvolution & opponent_UseChampion))
    
    #Filter complete
    df = df[team_filter]


#Preprocess data for FP tree
#Propose is to make a True-False table of each cards in deck
def Preprocess_FP_data():
    #Use global variable
    global df, deck, exclude
    
    team_need_col = df.columns[7:15]     #exclude support card and evolution count
    opponent_need_col = df.columns[17:25]

    #Set conditions
    team_filter = (df[team_need_col].isin(deck).sum(axis=1) == len(deck))
    team_exclude = (df[team_need_col].isin(exclude).sum(axis=1) == 0)

    opponent_filter = (df[opponent_need_col].isin(deck).sum(axis=1) == len(deck))
    opponent_exclude = (df[opponent_need_col].isin(exclude).sum(axis=1) == 0)

    #Retrieve deck data that contain all selected cards
    team_deck = df.loc[(team_filter & team_exclude), team_need_col].values
    opponent_deck = df.loc[(opponent_filter & opponent_exclude), opponent_need_col].values
    all_decks = np.concatenate([team_deck, opponent_deck])

    #First, retrieve every used cards as column names
    used_cards = []
    for row in team_deck:
        for card in row:
            if card not in used_cards:
                used_cards.append(card)
    
    for row in opponent_deck:
        for card in row:
            if card not in used_cards:
                used_cards.append(card)
    
    used_cards = np.array(used_cards)

    #Second, fill in True-False table in another array
    deck_count = all_decks.shape[0]
    cards_count = used_cards.shape[0]
    table = np.full((deck_count, cards_count), False)       #Create array with all value False

    for i in range(deck_count):
        for card in all_decks[i]:
            pos = np.where(used_cards == card)      #Find the position of current card in 'used_cards'
            table[i, pos] = True

    return pd.DataFrame(table, columns=used_cards).drop(deck, axis=1)       #Delete cards columns which already selected

#Calculate win rate of each combination
def Get_win_rate(data):
    team_deck = df.columns[6:16]
    opponent_deck = df.columns[16:26]

    combinations = data['itemsets'].values

    winRate = []
    for combination in combinations:
        winnerCount = df[(df[team_deck].isin(combination).sum(axis=1) == len(combination))].shape[0]
        loserCount = df[(df[opponent_deck].isin(combination).sum(axis=1) == len(combination))].shape[0]

        winRate.append(winnerCount / (winnerCount + loserCount))

    return winRate

#Use FP Growth to analyze
def Analyze(mini_use_rate = 0, mini_win_rate = 0):
    #Use global variable
    global df

    #check if too less data in df
    if df.shape[0] <= 50:
        print(df.shape)
        print('符合條件的卡組數量太少 無法分析')
        return -1
    
    #create another dataframe and preprocess data again
    fp_data = Preprocess_FP_data()
    
    #Generate FP tree
    result = fpgrowth(fp_data, 0.01, use_colnames=True)

    #Add win rate into result
    result['Win Rate'] = Get_win_rate(result)

    #Add ranking
    useRate_normalize = (result['support'] - result['support'].min()) / (result['support'].std())
    winRate_normalize = (result['Win Rate'] - result['Win Rate'].min()) / (result['Win Rate'].std())
    result['Ranking'] = useRate_normalize + winRate_normalize

    #Sort data by ranking
    result.sort_values('Ranking', ascending=False)

    result.to_csv('deck.csv')
    #return result
    

if __name__== '__main__':
    d1 = datetime.datetime(2024,  1, 1)
    d2 = datetime.datetime(2024, 12, 12)
    
    deck = ['Evol Knight']
    exclude = ['Little Prince']
    Read_data([d1, d2])
    Filter_data(deck, 2, 2)
    print(df.shape)
    Analyze()