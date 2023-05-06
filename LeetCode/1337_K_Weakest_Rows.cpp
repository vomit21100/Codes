//Leetcode 1337
//https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/

#include <iostream>
#include <algorithm>
#include <vector>

using namespace std; 

class Solution {
public:
    vector<int> kWeakestRows(vector<vector<int>>& mat, int k) {
        vector<pair<int, int>> clom;
        vector<int> result;
        for(int i = 0;i < mat.size();i++){
            //數士兵數量
            clom.push_back(pair<int, int>{countSolider(mat[i]), i});
        }

        //sort會由小到大排序 結果為士兵少的排前面
        sort(clom.begin(), clom.end());

        for(int i = 0;i < k;i++) {
            result.push_back(clom[i].second);
        }

        return result;
    }

    int countSolider(vector<int> &m){
        int head = 0, tail = m.size();
        //頭尾二分法
        while(head < tail){
            int mid = (head + tail) / 2;
            if(m[mid] == 1){
                head = mid + 1;
            }
            else{
                tail = mid;
            }
        }

        return head;
    }

    void test(){
        vector<vector<int>> mat = {{1,1,0,0,0},
                                   {1,1,1,1,0},
                                   {1,0,0,0,0},
                                   {1,1,0,0,0},
                                   {1,1,1,1,1}};
        vector<int> ans = {2, 0, 3}, result = kWeakestRows(mat,3);
        printf("%d\n", equal(ans.begin(), ans.end(), result.begin(), result.end()));
        mat.clear(), result.clear(), ans.clear();
    }
};

int main(){
    Solution sol;
    sol.test();
}