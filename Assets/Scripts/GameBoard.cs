using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBoard : MonoBehaviour
{
    private char empty = '\0';

    private int length = 6;
    private int width = 7;
    
    private char[,] board;
    private bool gameOver;
    public string method;
    public char winnerToken;
    public int checkerCount = 3;

    void Start()
    {
        Clear();
    }
    
    public void SetChecker(char token, int loc) {
        if(loc < width && loc >= 0)
            SetChecker(token, length - 1, loc);   
    }

    private void SetChecker(char token, int l1, int l2) {
       if (l1 < 0)
           return;

       if(board[l1,l2] == empty) {
           board[l1, l2] = token;
            CheckWin(token, l1 , l2);
       } else {
            SetChecker(token, l1 - 1, l2);
       }
    }

    private void CheckWin(char token, int l1, int l2) {
        // checks vertical
        int v = CheckWin(token, l1, l2, new Vector2Int(-1, 0)) + CheckWin(token, l1, l2, new Vector2Int(1, 0));
        if (v >= checkerCount) {
            gameOver = true;
            winnerToken = token;
            method = "v";
            return;
        }
        // checks dia 1
        int d1 = CheckWin(token, l1, l2, new Vector2Int(-1, -1)) + CheckWin(token, l1, l2, new Vector2Int(1, 1));
        if (d1 >= checkerCount) {
            gameOver = true;
            winnerToken = token;
            method = "d1";
            return;
        }
        // checks hori
        int h = CheckWin(token, l1, l2, new Vector2Int(0, -1)) + CheckWin(token, l1, l2, new Vector2Int(0, 1));
        if (h >= checkerCount) {
            gameOver = true;
            winnerToken = token;
            method = "h";
            return;
        }
        // checks dia 2
        int d2 = CheckWin(token, l1, l2, new Vector2Int(1, -1)) + CheckWin(token, l1, l2, new Vector2Int(-1, 1));
        if (d2 >= checkerCount) {
            gameOver = true;
            winnerToken = token;
            method = "d2";
        }
    }

    private int CheckWin(char token, int o1, int o2, Vector2Int dir) {
        return CheckWin(token, o1,  o2,  dir, 0);
    }

    private int CheckWin(char t, int o1, int o2, Vector2Int dir, int num) {
        int n1 = o1 + dir.x;
        int n2 = o2 + dir.y;
        // checks index
        if ((n1 < length && n1 >= 0) && (n2 < width && n2 >= 0)) {
            if(board[n1,n2] == t) 
                return CheckWin(t, n1, n2, dir, num + 1);
        }
        return num;
    }

    public bool gameIsWon() {
        return gameOver;
    }

    public void Clear() {
        gameOver = false;
        board = new char[length, width];
        winnerToken = empty;
    }

    /*
    private void Update() {
        //Test();
    }

    private void Test() {
        if (!gameOver) {
            SetChecker('p', Random.Range(0, width));
            SetChecker('g', Random.Range(0, width));
            string b = " ";
            for (int x = 0; x < board.GetLength(0); x += 1) {
                for (int y = 0; y < board.GetLength(1); y += 1) {
                    if (board[x, y] == empty)
                        b = b + " x";
                    else
                        b = b + " " + board[x, y];
                }
                b = b + "\n";
            }
            Debug.Log(b);
        }
    }
    */
}
