﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public float winningScore;
    public float[] playerScores;
    public Slider[] playerScoreUIElements;
    public Image[] playerScoreUIFillImages;
    private Color[] playerColors;
    
    public PitFluidControl pitFluid;
    
	// Use this for initialization
	void Start () {
	   
	}
    
    public void Init(int numPlebs, bool[] players, Color[] playerColors) {
        int activeCount = 0;
        for(int i = 0; i < players.Length; ++i) {
            if(players[i])
                activeCount++;     
        }
        Debug.Log(numPlebs + " / " + activeCount);
        winningScore = Mathf.Ceil(numPlebs / (float)activeCount);
        Debug.Log(winningScore);
        playerScores = new float[players.Length];
        this.playerColors = playerColors;
        
        for (int i = 0; i < playerScores.Length; ++i) {
            if(players[i]) {
                Debug.Log(playerScoreUIElements[i]);
                playerScoreUIElements[i].gameObject.SetActive(true);
                playerScoreUIElements[i].maxValue = winningScore;
                playerScores[i] = 0f;
                playerScoreUIFillImages[i].color = playerColors[i];
            }
       }
    }
	
	// Update is called once per frame
	void Update () {
	   for (int i = 0; i < playerScores.Length; ++i) {
           playerScoreUIElements[i].value = playerScores[i];
           //playerScoreUIFillImages[i].color = Color.Lerp(Color.white, playerColors[i], winningScore / playerScores[i]);
       }
	}
    
    public void IncrementScore(int playerNumber) {
        playerScores[playerNumber]++;
        UpdatePitFluid();
        
        // Signal a winner to the game controller
        if(playerScores[playerNumber] >= winningScore) {
            GetComponent<GameController>().OnPlayerWin(playerNumber);
        }
    }
    
    private void UpdatePitFluid() {
        float maxFraction = 0;
        for (int i = 0; i < playerScores.Length; ++i) {
            Debug.Log("Fraction " + i + ": " + playerScores[i] + " / " + winningScore);
            maxFraction = Mathf.Max(maxFraction, playerScores[i] / winningScore);
        }
        pitFluid.Set(maxFraction);
    }
}
