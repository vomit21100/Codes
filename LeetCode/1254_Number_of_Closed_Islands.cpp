//https://leetcode.com/problems/number-of-closed-islands/?envType=study-plan&id=graph-i
//計算所有非觸碰邊界的島

#include<iostream>
#include<vector>

using namespace std;

class Solution {
public:
    void dfs(vector<vector<int>>& grid, int i, int j, int *value){
        if(i<0 || i>=grid.size() || j<0 || j>= grid[0].size()){
            //true => 到達邊界
            *value = 1;
            return;
        }
        if(grid[i][j])return;

        grid[i][j] = 2;
        dfs(grid, i+1, j, value);
        dfs(grid, i-1, j, value);
        dfs(grid, i, j+1, value);
        dfs(grid, i, j-1, value);
        return;
    }
    int closedIsland(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        int result = 0, judge = 0;
        for(int i = 0;i < m;i++){
            for(int j = 0;j < n;j++){
                if(!grid[i][j]){
                    judge = 0;
                    dfs(grid, i, j, &judge);
                    result = !judge ? result + 1 : result;
                }
            }
        }
        return result;
    }
};