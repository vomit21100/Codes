# AllPicturesRandomizeName
將所有從Ehviewer下載的完整圖庫的檔名以隨機16進制數命名，同時儲存所有使用過的數字保證未來不會重複使用，使用二元樹提高歷史紀錄搜索速度


Logs

getAllFiles.py

	getAllFiles()
		2022/07/06: 回傳所有非特定資料夾內的檔案名稱
		2022/08/07: 修改檔案類別判斷方式
		
	moveFile()
		2022/07/06: 移動所有非特定資料夾內的檔案到/result，若沒有result則創建一個
		2022/08/07: 修正result創建問題、新增刪除空資料夾功能
		
randomNumGenerater.py

	class Tree
		insert(self, val)
			2022/07/06: 根據二元樹規則插入數字
		
		find(self, val)
			2022/07/06: 探索整棵樹找指定數，有一致的數回傳1，反之則0
		
	initRoot()
		2022/07/06: 從numbers.txt中載入數值，若numbers.txt為空則創建一個數值為空的根節點
		
	writeNumbers(val)
		2022/07/06: 採16進制將指定數寫入numbers.txt中
		
	randomlize(root, files)
		2022/07/06: 創建10位十進制隨機數做為新檔名，若二元樹中已有相同數則重新創建隨機數直至無重複
		2022/08/07: 新增呼叫moveFile()
	
	renameFile(file, num)
		2022/07/06: 重命名檔案名為num
		
numbers.txt

	2022/07/06: 儲存所有使用過的數
