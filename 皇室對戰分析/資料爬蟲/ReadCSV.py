# -*- coding: utf-8 -*-
"""
Created on Mon Feb 13 18:53:32 2023

@author: weiho
"""

import pandas as pd
import os

wanted = ['type',
          'team_0_crowns',
          'opponent_0_crowns',
          'team_0_cards_0_name','team_0_cards_1_name','team_0_cards_2_name','team_0_cards_3_name','team_0_cards_4_name','team_0_cards_5_name','team_0_cards_6_name','team_0_cards_7_name',
          'team_0_cards_0_level','team_0_cards_1_level','team_0_cards_2_level','team_0_cards_3_level','team_0_cards_4_level','team_0_cards_5_level','team_0_cards_6_level','team_0_cards_7_level',
          'team_0_cards_0_maxLevel','team_0_cards_1_maxLevel','team_0_cards_2_maxLevel','team_0_cards_3_maxLevel','team_0_cards_4_maxLevel','team_0_cards_5_maxLevel','team_0_cards_6_maxLevel','team_0_cards_7_maxLevel', 
          'opponent_0_cards_0_name','opponent_0_cards_1_name','opponent_0_cards_2_name','opponent_0_cards_3_name','opponent_0_cards_4_name','opponent_0_cards_5_name','opponent_0_cards_6_name','opponent_0_cards_7_name',
          'opponent_0_cards_0_level','opponent_0_cards_1_level','opponent_0_cards_2_level','opponent_0_cards_3_level','opponent_0_cards_4_level','opponent_0_cards_5_level','opponent_0_cards_6_level','opponent_0_cards_7_level',
          'opponent_0_cards_0_maxLevel','opponent_0_cards_1_maxLevel','opponent_0_cards_2_maxLevel','opponent_0_cards_3_maxLevel','opponent_0_cards_4_maxLevel','opponent_0_cards_5_maxLevel','opponent_0_cards_6_maxLevel','opponent_0_cards_7_maxLevel']

os.chdir('../data')
files = os.listdir()

df = pd.read_csv(files[0])
for i in files[1:]:
    df1 = pd.read_csv(i)
    df = pd.concat([df, df1])
    
fliter = (df['type'] == 'pathOfLegend')
df = df[fliter]
"""
df1 = pd.read_csv(files[2])
df2 = pd.read_csv(files[3])

df = pd.concat([df1, df2])

fliter = df['type'] == 'pathOfLegend'
df3 = df[fliter]

column_names = df.keys().values.tolist()

df4 = df3[wanted]
"""