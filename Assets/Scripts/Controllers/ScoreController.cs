﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public float totalAchievableScore;
    public float[] playerScores;
    public Slider[] playerScoreUIElements;
    public Image[] playerScoreUIFillImages;
    private Color[] playerColors;
    
	// Use this for initialization
	void Start () {
	   
	}
    
    public void Init(int numPlebs, int numPlayers, Color[] playerColors) {
        totalAchievableScore = numPlebs;
        playerScores = new float[numPlayers];
        this.playerColors = playerColors;
        
        for (int i = 0; i < playerScores.Length; ++i) {
           playerScoreUIElements[i].maxValue = totalAchievableScore;
           playerScores[i] = 0f;
       }
    }
	
	// Update is called once per frame
	void Update () {
	   for (int i = 0; i < playerScores.Length; ++i) {
           playerScoreUIElements[i].value = playerScores[i];
           playerScoreUIFillImages[i].color = Color.Lerp(Color.white, playerColors[i], totalAchievableScore / playerScores[i]);
       }
	}
    
    public void IncrementScore(int playerNumber) {
        playerScores[playerNumber]++;
    }
}
