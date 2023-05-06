//leetcode 1672
//https://leetcode.com/problems/richest-customer-wealth/
#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    int maximumWealth(vector<vector<int>>& accounts) {
        int max_value = 0, count;
        for(vector<int> &cus: accounts){
            count = 0;
            for(int i = 0;i < cus.size();i++){
                count += cus[i];
            }
            max_value = max_value < count ? count : max_value;
        }
        return max_value;
    }
    void test(){
        vector<vector<int>> accounts_a = {{1,2,3},{4,5,6}};
        cout << maximumWealth(accounts_a) << endl;
        vector<vector<int>> accounts_b = {{1,5}, {7,3}, {3,5}};
        cout << maximumWealth(accounts_b) << endl;
    }
};

int main(){
    Solution sol;
    sol.test();
}