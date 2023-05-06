//https://leetcode.com/problems/string-to-integer-atoi/

#include<iostream>
#include<string>
#include<climits>

using namespace std;

class Solution {
public:
    int myAtoi(string s) {
        int res = 0, i = 0, sign = 1, num;
        while(s[i] == ' ')i++;
        if(s[i] == '+' || s[i] == '-'){
            sign = 1 - 2 * (s[i++] == '-');
        }
        while(s[i] >= '0' && s[i] <= '9'){
            num = (s[i] - '0') * sign;
            //cout << num << endl;
            if (res > INT_MAX/10 || (res == INT_MAX / 10 && num >= 7)) return INT_MAX;
            if (res < INT_MIN/10 || (res == INT_MIN / 10 && num <= -8)) return INT_MIN;
            res = 10*res + num;
            i++;
        }
        return res;
    }
    void test(){
        cout << myAtoi("-91283472332") << endl;
        cout << myAtoi("   -42") << endl;
        cout << myAtoi("words and 987") << endl;
        cout << myAtoi("00000-42a1234") << endl;
        cout << myAtoi("-2147483648") << endl;
        cout << myAtoi("  +  413") << endl;
    }
};

int main(){
    Solution s;
    s.test();
}