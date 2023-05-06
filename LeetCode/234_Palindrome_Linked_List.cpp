//Leetcode 234
//https://leetcode.com/problems/palindrome-linked-list/

#include <iostream>
using namespace std; 

class Solution {
public:
    ListNode* HalfWay(ListNode* head){ //取list的中間節點
        ListNode* slow = head;         
        ListNode* fast = head;
        while(true){
            if(fast == NULL){
                return slow;
            }
            else if(fast->next == NULL){
                return slow->next;
            }
            slow = slow->next;         //一次跳一格
            fast = fast->next->next;   //一次跳兩格
        }
    }
    ListNode* revereList(ListNode* head){
        ListNode* first = head;
        ListNode* second = head->next;
        ListNode* third;
        
        first->next = NULL;
        
        while (true){
            if (second == NULL)
                return first;
            
            third = second->next;
            second->next = first;
            
            
            first = second;
            second = third;
        }
    }

    bool isPalindrome(ListNode* head) {
        if (head == NULL || head->next == NULL)
            return true;
            
        ListNode* obverse = head;
        ListNode* reverse = revereList(HalfWay(head));

        while(reverse != NULL){
            if(obverse->val != reverse->val){
                return false;
            }
            reverse = reverse->next;
            obverse = obverse->next;
        }
        return true;
    }

    void test(){
        //ListNode是Leetcode網站自創的class
    }
};

int main(){
    Solution c;
    c.test();
}