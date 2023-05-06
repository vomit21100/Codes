//Leetcode 383
//https://leetcode.com/problems/ransom-note/

#include <iostream>
#include <string>

using namespace std; 

class Solution {
public:
    bool canConstruct(string ransomNote, string magazine) {
        int isContain = 0;
        int Msize = magazine.size();
        for(int i = 0;i < ransomNote.size();i++){
            isContain = 0;
            for(int j = 0;j < Msize;j++){
                if(ransomNote[i] == magazine[j]){
                    magazine[j] = ' ';
                    isContain = 1;
                    break;
                }
            }
            
            if(!isContain)
                return false;
        }

        return true;
    }

    void test(){
        int result[2];
        result[0] = 0;
        result[1] = canConstruct("aa", "ab");
        printf("except: %d\nget: %d\n", result[0], result[1]);
        result[0] = 1;
        result[1] = canConstruct("aa", "aab");
        printf("except: %d\nget: %d\n", result[0], result[1]);
    }
};

int main(){
    Solution s;
    s.test();
}