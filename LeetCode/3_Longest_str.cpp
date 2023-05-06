//https://leetcode.com/problems/longest-substring-without-repeating-characters/

#include<iostream>
#include<vector>

using namespace std;

class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        int j = 0, res = 0;
        //128個空間 數值為0 對應ascii
        vector<int>map(128, 0);
        for(int i = 0; i < s.size();i++){
            map[s[i]]++;
            while(map[s[i]] > 1){
                map[s[j]]--;
                j++;
            }
            res = (res < i-j+1) ? (i-j+1) : res;
        }
        return res;
    }
};