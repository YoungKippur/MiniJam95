using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public int scoreToWin = 5;
    public int[] scores;
    public int currentPlayer; // the player who's turn is to create the map

    public Game() {
        this.scores = new int[] { 0, 0 };
        this.currentPlayer = 0;
    }

    public int PassTurn(int winner) {
        this.scores[winner]++;
        if(this.scores[winner] >= this.scoreToWin) return winner;
        this.currentPlayer = this.currentPlayer == 0 ? 1 : 0;
        return -1;
    }
}
