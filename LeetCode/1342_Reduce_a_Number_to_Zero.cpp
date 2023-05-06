//Leetcode 1342
//https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
//bitset
#include <iostream>

using namespace std; 

class Solution {
public:
    int numberOfSteps(int num) {
        int res = 0;
        while(num){
            if(num & 1)num -= 1;
            else num >>= 1;
            res += 1; 
        }
        return res;
    }
    void test(){
        numberOfSteps(14);
    }
};

int main(){
    Solution s;
    s.test();
}