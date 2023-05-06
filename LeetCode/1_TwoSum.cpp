//https://leetcode.com/problems/two-sum/

#include<iostream>
#include<vector>
#include<unordered_map>

using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        unordered_map<int, int> map;
        for(int i = 0; i < nums.size();i++){
            if(map.find(target - nums[i]) == map.end()) //map.find找不到會回傳null
                map[nums[i]] = i;
            else
                return {map[target - nums[i]], i};
        }
        return {};
    }

    void test(){
        vector<int> test1 = {2, 7, 11, 5};
        cout << twoSum(test1, 9) << endl;
    }
};

int main(){
    Solution s;
    s.test();

    return 0;
}