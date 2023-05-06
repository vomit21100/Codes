//https://leetcode.com/problems/add-two-numbers/

#include<iostream>
#include<vector>

using namespace std;

class Solution {
public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        ListNode* res = new ListNode(0);
        ListNode* curr = res;
        int carry = 0;
        while(l1 != NULL || l2 != NULL || carry != 0){
            //l1 & l2 有可能是null 所以不能用l1->val做判斷條件
            int x = l1 ? l1->val : 0;
            int y = l2 ? l2->val : 0;
            int sum = x + y + carry;
            carry = sum / 10;
            curr->next = new ListNode(sum % 10);
            curr = curr->next;

            //l1是否為null
            l1 = l1 ? l1->next : nullptr;
            l2 = l2 ? l2->next : nullptr;
        }

        return res->next;
    }
};