"""
從蝦皮上把圖片抓下來 再整合進一個csv檔方便用sql語法把資料存進資料庫
"""
import json
import requests
import shutil
import csv

with open('data.json', encoding='utf-8') as file:
    datas = json.load(file)

with open('data.json', 'w', encoding='utf-8') as file:
    json.dump(datas, file, ensure_ascii=False)

#data = [['name', 'price', 'Description', 'quantity', 'Sold_Out', 'CategoryID', 'imgPath', 'sellerID']]
data = []
for i in datas['prods']:
    url = 'https://c.ecimg.tw' + i['picS']
    response = requests.get(url, stream=True)
    img = i['picS'].split('/')
    with open('./img/'+img[3], 'wb') as file:
        shutil.copyfileobj(response.raw, file)
    
    data.append([i['name'], i['price'], i['describe'], 100, 0, 4, './img/'+img[3], 2])

with open('4.csv', 'a' ,encoding='utf-8') as csvfile:
    writer = csv.writer(csvfile)
    for i in data:
        writer.writerow(i)
        print(i[0])
