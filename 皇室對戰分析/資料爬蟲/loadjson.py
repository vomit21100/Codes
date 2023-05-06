# -*- coding: utf-8 -*-
"""
Created on Mon Feb 13 16:25:22 2023

@author: weiho
"""

import json

path = 'output1.json'
f = open(path, 'r', encoding='utf8')
str1 = json.load(f)
f.close()



for i in str1:
    print(i['tag'])