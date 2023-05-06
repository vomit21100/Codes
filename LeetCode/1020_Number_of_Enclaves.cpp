//https://leetcode.com/problems/number-of-enclaves/?envType=study-plan&id=graph-i
//https://leetcode.com/problems/number-of-enclaves/discuss/265555/C%2B%2B-with-picture-DFS-and-BFS

#include<iostream>
#include<vector>

using namespace std;

class Solution {
public:
    void dfs(vector<vector<int>>& grid, int i, int j){
        if(i<0 || i>=grid.size() || j<0 || j>=grid[0].size() || grid[i][j] == 0){
            return;
        }
        grid[i][j] = 0;
        dfs(grid, i+1, j);
        dfs(grid, i-1, j);
        dfs(grid, i, j+1);
        dfs(grid, i, j-1);
    }
    int numEnclaves(vector<vector<int>>& grid) {
        int n = grid.size(), m = grid[0].size();
        int result = 0;
        for(int i = 0;i < n;i++){
            for(int j = 0;j < m;j++){
                if(i * j == 0 || i == n - 1 || j == m - 1){
                    dfs(grid, i, j);
                }
            }
        }
        for(int i = 0;i < n;i++){
            for(int j = 0;j < m;j++){
                result = grid[i][j] == 1 ? result+1 : result;
            }
        }
        return result;
    }
};