//leetcode 695
//https://leetcode.com/problems/max-area-of-island/?envType=study-plan&id=graph-i
#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    void dfs(vector<vector<int>>& grid,int i,int j,int *count){
        if(i<0 || i>=grid.size() || j<0 || j>= grid[0].size())return;
        if(grid[i][j]<=0)return;
        grid[i][j] = -1;
        dfs(grid, i+1, j, count);
        dfs(grid, i-1, j, count);
        dfs(grid, i, j+1, count);
        dfs(grid, i, j-1, count);
        *count += 1;
    }
    int maxAreaOfIsland(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        int max = 0;
        for(int i = 0;i < m;i++){
            for(int j = 0;j < n;j++){
                int count = 0;
                if(grid[i][j] == 1)
                    dfs(grid, i, j, &count);
                max = (count > max) ? count : max;
            }
        }
        return max;
    }

    void test(){
        vector<vector<int>> grid = {{0,0,1,0,0,0,0,1,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,1,1,1,0,0,0},
                                    {0,1,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,1,0,0,1,1,0,0,1,0,1,0,0},
                                    {0,1,0,0,1,1,0,0,1,1,1,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,1,0,0},
                                    {0,0,0,0,0,0,0,1,1,1,0,0,0},
                                    {0,0,0,0,0,0,0,1,1,0,0,0,0}};
        cout << maxAreaOfIsland(grid) << endl;
    }
};

int main(){
    Solution s;
    s.test();
}