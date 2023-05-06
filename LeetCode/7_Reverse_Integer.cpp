//https://leetcode.com/problems/reverse-integer/

#include<iostream>
#include<climits>
#include<cmath>

using namespace std;

class Solution {
public:
    int reverse(int x) {
        int rev = 0;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;

            //INT_MAX & INT_MIN <== <climits>
            if (rev > INT_MAX/10 || (rev == INT_MAX / 10 && pop > 7)) return 0;
            if (rev < INT_MIN/10 || (rev == INT_MIN / 10 && pop < -8)) return 0;
            rev = rev * 10 + pop;
        }
        return rev;
    }

    void test(){
        cout << reverse(-324) << endl;
        cout << reverse(-9871) << endl;
        cout << reverse(502) << endl;
    }
};

int main(){
    Solution s;
    s.test();
}