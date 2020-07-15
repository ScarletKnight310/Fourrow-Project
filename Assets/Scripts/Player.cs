using System.Collections;
using System.Collections.Generic;


public class Player {
    public string name;
    public char token;
    public int wins = 0;

    public Player(string n, char t) {
        name = n;
        token = t;
    }
}
