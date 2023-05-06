//https://leetcode.com/problems/longest-palindromic-substring/
//先找最外兩個相同字符 再確認中間是否迴文的做法會超時
//改為由中間向外尋找
#include<iostream>
#include<cstring>
#include<string>

using namespace std;

class Solution {
public:
    string longestPalindrome(string s) {
        if(s.size() <= 1)return s;

        int st, sn, max = 0, n = s.size(), x;
        for(int i = 0;i < n - 1;i++){
            st = i, sn = i;
            while(st >= 0 && sn < n && s[st] == s[sn]){
                st--, sn++;
            }

            //(sn - 1) - (st + 1) + 1 = sn - st -1
            if(sn - st - 1 > max){
                max = sn - st - 1;
                x = st + 1;
            }

            //偶數長度時
            if(s[i] == s[i+1]){
                st = i, sn = i + 1;
                while(st >= 0 && sn < n && s[st] == s[sn]){
                    st--, sn++;
                }

                //(sn - 1) - (st + 1) + 1 = sn - st -1
                if(sn - st - 1 > max){
                    max = sn - st - 1;
                    x = st + 1;
                }
            }
        }
        return s.substr(x, max);
    }


    void test(){
        string str1 = "babcda";
        cout << longestPalindrome(str1) << endl;

        string str2 = "cbccbda";
        cout << longestPalindrome(str2) << endl;

        string str3 = "bb";
        cout << longestPalindrome(str3) << endl;

    }
};

int main(){
    Solution s;
    s.test();
}