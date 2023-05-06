//leetcode 200
//https://leetcode.com/problems/number-of-islands/?envType=study-plan&id=graph-i

class Solution {
public:
    void dfs(vector<vector<char>>& grid,int si,int sj){
        if(si < 0 || sj < 0 || si >= grid.size() || sj >= grid[0].size())return;
        if(grid[si][sj] == '0' || grid[si][sj] == '2')return;

        grid[si][sj] = '2';

        dfs(grid, si+1, sj);
        dfs(grid, si-1, sj);
        dfs(grid, si, sj+1);
        dfs(grid, si, sj-1);
    }
    int numIslands(vector<vector<char>>& grid) {
        int island = 0;
        for(int i = 0;i < grid.size();i++){
            for(int j = 0;j < grid[0].size();j++){
                if(grid[i][j] == '1'){
                    dfs(grid, i, j);
                    island++;
                }
            }
        }
        return island;
    }
};