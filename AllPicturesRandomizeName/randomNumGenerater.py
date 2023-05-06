# -*- coding: utf-8 -*-
"""
Created on Sun Jul  3 01:05:25 2022

@author: deava
"""

import os
import random
import getAllFiles as GF

class Tree:
    def __init__(self, val = None):
        if val != None:
            self.val = val
        else:
            self.val = None
        self.left = None
        self.right = None
        
    def insert(self, val):
        if self.val:
            if val > self.val:
                if self.left is None:
                    self.left = Tree(val)
                else:
                    self.left.insert(val)
            if val < self.val:
                if self.right is None:
                    self.right = Tree(val)
                else:
                    self.right.insert(val)
        else:
            self.val = val
        
    def find(self, val):
        if self.val is val:
            return 1
        elif self.val is None:
            return 0
        else:
            if val > self.val:
                if self.left is None:
                    return 0
                else:
                    return self.left.find(val)
            if val < self.val:
                if self.right is None:
                    return 0
                else:
                    return self.right.find(val)
    

def initRoot():
    root = Tree()
    with open('numbers.txt', 'r') as f:
        lines = f.readline()
        #print(lines)
        while lines != '':
            root.insert(int(lines, 16))
            lines = f.readline()
        f.close()
    
    return root

def writeNumbers(val):
    num = hex(val)
    with open('numbers.txt', 'a') as f:
        f.writelines(num + '\n')
        f.close()

def renameFile(file, num):
    line = file.find('/')
    dot = file.rfind('.')            #由後向前尋找
    num = hex(num)[2:]
    fileName = file[:line + 1] + num + file[dot:]
    os.rename(file, fileName)

def randomlize(root, files):
    for i in files:
        while 1:
            num = int(random.random() * pow(10, 10))
            if not root.find(num):
                #print(i)
                writeNumbers(num)
                renameFile(i, num)
                root.insert(num)
                break
    GF.moveFile()
        
        
    
if __name__ == '__main__':
    root = initRoot()
    files = GF.getAllFiles()
    randomlize(root, files)
    print('done')