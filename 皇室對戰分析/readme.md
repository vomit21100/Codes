## 目的

分析皇室戰爭這款手游中的世界前1000名玩家的對戰紀錄，遊戲中有多種不同的對戰模式，資料中只擷取經典1v1對戰資料做分析，最終目的是透過分析結果得出勝算最高的卡組或針對某張卡的最佳組合

## 目前進度

 1. 採集資料(done)
 	用爬蟲從royaleapi上抓取資料
	+ GetBattleData.py: 透過https://royaleapi.com/player/ + 玩家id來收集資料，網站本身有提供csv檔下載，資料儲存在data資料夾裡
	+ GetCardsData.ipynb: 從https://statsroyale.com/cards 跟 https://www.deckshop.pro/card/list 上抓取所有卡牌的名稱、種類、聖水消耗及圖像
 	+ GetWebCookies.py: 由於下載對戰資料的網站需要先用tiwtter登入，所以採用先動態登入的方式取得cookie，再將得來的cookie用於靜態網頁的抓取
 1. 整理資料(done)
 	+ GetBattleData.ipynb: 把多個csv檔的資料整合，再把對戰種類是'pathOfLegend'(也就是1v1)的資料抽出來，最後只留下需要的columns，同時將卡組中的特殊卡排的數量統計下來
 1. 選擇演算法(80%)
 	+ Analyze.py: 使用mlxten中提供fp_growth函式實現pattern mining
  	  	- Read_data(): 讀取並載入已下載且處理完的資料，可以指定特定時間段的資料
    		- Get_champion_data(): 取得各卡組中使用的英雄卡(特殊卡排的其中一種)數量
      		- Filter_data(): 跟據需求返回只使用指定數量特殊卡牌的卡組
        	- Preprocess_FP_data(): 由於mlxten的fp_growth函式需要轉換成特定的True-False表，但是mlxten提供的轉換函式無法在我的資料集中正常運作，因此需要另外處理
         	- Get_win_rate(): 計算各個常用組合的勝率
          	- Analyze(): 先將前處理完成的資料送入fp_growth函式裡面並得到另一個DataFrame，再將新得到的DataFrame加上勝率(從Get_win_rate取得)，最後再輸出成另一個csv檔
1. UI(30%)
   	+ 參考UI資料夾的pdf檔案，不過當中已有部分修改
          
## 已知問題或待改進:
   + 動態爬蟲時網頁會短暫出現在畫面上
   + 部分圖像沒有可靠的獲取網站
   + 其中一種特殊卡牌並未被加進演算法的範圍內
   + 每次分析都是使用實時運算，會占用大量的記憶體及時間
