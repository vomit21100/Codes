//Leetcode 13
//https://leetcode.com/problems/roman-to-integer/


#include <iostream>
#include <string>
#include <map>

using namespace std; 

class Solution {
public:
    int romanToInt(string s) {
        int total = 0;
        map<char, int> C = {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };


        for(int i=0;i<s.size();i++){
            if(i == 0 || C[s[i]] <= C[s[i - 1]]){
                total += C[s[i]];
            }
            else{
                total += (C[s[i]] - 2*C[s[i - 1]]);
            }
        }

        return total;
    }

    void test(){
        int x;
        x = romanToInt("LVIII");
        printf("%d\n", x == 58);
        x = romanToInt("MCMXCIV");
        printf("%d\n", x == 1994);
    }
};

int main(int argc, char** argv){
    Solution s;
    s.test();
}