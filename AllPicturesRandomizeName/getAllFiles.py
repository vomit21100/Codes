# -*- coding: utf-8 -*-
"""
Created on Sun Jul  3 01:11:40 2022

@author: deava
"""
import os
import shutil

def getAllFiles():
    names = []
    types = ['.jpg', '.png', '.gif', '.mp4', '.jpeg', '.webm']
    ignoreTypes = ['.thumb']
    ignoreFiles = ['getAllFiles.py', 'randomNumGenerater.py', 'Test.py', 
                   '__pycache__', 'numbers.txt', 'numbers備份', 'result', '.git', '.gitignore', 'LICENSE', 'README.md']
    folders = os.listdir()
    for i in ignoreFiles:
        if i in folders:
            folders.remove(i)
    for i in folders:
        images = os.listdir(i)
        lists = []
        for j in images:
            dot = j.rfind('.') - len(j)
            if j in ignoreTypes:
                os.remove(i + '/' + j)
                print('removed: ' + i + '/' + j)
            elif j[dot:] in types:
                lists.append(j)
            else:
                print('Unknow type: ' + i + '/' + j)
        for j in range(len(lists)):
            lists[j] = i + '/' + lists[j]
        names = names + lists
    
    #print(names)
    return names

def moveFile():
    path = 'result/'
    ignoreFiles = ['getAllFiles.py', 'randomNumGenerater.py', 'Test.py', 
                   '__pycache__', 'numbers.txt', 'numbers備份', '.git', '.gitignore', 'LICENSE', 'README.md']
    folders = os.listdir()
    for i in ignoreFiles:
        if i in folders:
            folders.remove(i)
    
    if 'result' not in folders:
        os.mkdir('result')
    for i in folders:
        images = os.listdir(i)
        for j in images:
            print(i + '/' + j)
            shutil.move(i + '/' + j, path + j)
        if i != 'result':
            os.rmdir(i)

if __name__ == '__main__':
    #folders = getAllFiles()
    #getAllFiles()
    moveFile()