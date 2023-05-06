## 目的
---
分析皇室戰爭這款手游中的世界前1000名玩家的對戰紀錄，遊戲中有多種不同的對戰模式，資料中只擷取經典1v1對戰資料做分析，最終目的是透過分析結果得出勝算最高的卡組或針對某張卡的最佳組合

## 目前進度
---
 1. 採集資料(done)
 	用爬蟲從royaleapi上抓取資料
	+ Getdata.ipynb: 透過https://royaleapi.com/player/ + 玩家id來收集資料，網站本身有提供csv檔下載，資料儲存在data資料夾裡
	+ AllCard.ipynb: 從https://statsroyale.com/cards 上抓取所有卡牌的名稱、種類、聖水消耗
 1. 整理資料(done)
 	+ Getdata.ipynb: 把多個csv檔的資料整合，再把對戰種類是'pathOfLegend'(也就是1v1)的資料抽出來，最後只留下需要的columns
 1. 選擇演算法(undone)
 	+ 還沒做
