//leetcode 733
//https://leetcode.com/problems/flood-fill/?envType=study-plan&id=graph-i

#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    void df(vector<vector<int>>& image, int initial, int sr, int sc, int color) {
        int m = image.size(), n = image[0].size();
        if(sr < 0 || sc < 0 || sr >= m || sc >= n)return;
        if(image[sr][sc]!= initial || image[sr][sc] == color)return;
        image[sr][sc] = color;
        df(image, initial, sr - 1, sc, color);
        df(image, initial, sr + 1, sc, color);
        df(image, initial, sr, sc - 1, color);
        df(image, initial, sr, sc + 1, color);
    }
    vector<vector<int>> floodFill(vector<vector<int>>& image, int sr, int sc, int color) {
        df(image, image[sr][sc], sr, sc, color);
        return image;
    }
};