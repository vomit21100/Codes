//Leetcode 412
//https://leetcode.com/problems/fizz-buzz/

#include <iostream>
#include <string>
#include <vector>

using namespace std; 

class Solution {
public:
    vector<string> fizzBuzz(int n) {
        vector<string> s;
        s.reserve(n);
        for(int i = 1;i <= n;i++){
            if(i%15 == 0)s.push_back("FizzBuzz");
            else if(i%3 == 0)s.push_back("Fizz");
            else if(i%5 == 0)s.push_back("Buzz");
            else s.push_back(to_string(i));
        }
        return s;
    }
    void test(){
        vector<string> vec;
        vec = fizzBuzz(9);
        for (int i = 0; i < vec.size(); i++) {
            cout << vec[i] << " ";
        }
        cout << "\n";
        vec.clear();

        vec = fizzBuzz(20);
        for (int i = 0; i < vec.size(); i++) {
            cout << vec[i] << " ";
        }
        cout << "\n";
    }
};

int main(){
    Solution s;
    s.test();
}