//https://leetcode.com/problems/regular-expression-matching/

#include<iostream>
#include<string>

using namespace std;

class Solution {
public:
    bool isMatch(string s, string p) {
        
    }

    void test(){
        //1 true
        cout << isMatch("ab", "a.") << '\n' << endl;
        //2 false
        cout << isMatch("ab", "a") << '\n' << endl;
        //3 true
        cout << isMatch("aa", "a*") << '\n' << endl;
        //3 true
        cout << isMatch("abc", "*abc") << '\n' << endl;
        //4 true
        cout << isMatch("ab", "ab*") << '\n' << endl;
        //5 true
        cout << isMatch("abc", "a.c") << '\n' << endl;
        //6 true
        cout << isMatch("abc", "a.c") << '\n' << endl;
        //7 true
        cout << isMatch("ab", ".*") << '\n' << endl;
    }
};

int main(){
    Solution s;
    s.test();
}