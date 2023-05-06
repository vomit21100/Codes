//https://leetcode.com/problems/number-of-operations-to-make-network-connected/

#include <iostream>
#include <vector>

using namespace std; 

class Solution {
public:
    void dfs(vector<vector<int>> &adj, vector<bool> &visited, int src){
        visited[src] = true;
        for(int n : adj[src]){
            if(!visited[n])
                dfs(adj, visited, n);
        }
    }
    int makeConnected(int n, vector<vector<int>>& connections) {
        if(n > connections.size() + 1)return -1;
        vector<vector<int>> adj(n);
        vector<bool> visited(n, false);
        for(vector<int> &c : connections){
            adj[c[0]].push_back(c[1]);
            adj[c[1]].push_back(c[0]);
        }

        int ans = 0;
        
        //紀錄有幾個點是無法到達的點
        //第一次會把所有已連接的節點標記"已探訪" 其餘的都是無法抵達的節點
        for(int i = 0;i < n;i++){
            if(!visited[i]){
                dfs(adj, visited, i);
                ans++;
            }
        }

        //扣除第一次標記產生的次數
        return ans-1;
    }
};

int main(){
    return 0;
}