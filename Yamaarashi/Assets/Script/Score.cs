﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public int Scores = 0;
    public Text scoreText;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = Scores.ToString();
    }

    public void ScoreUp()
    {
        Scores++;
    } 
}
