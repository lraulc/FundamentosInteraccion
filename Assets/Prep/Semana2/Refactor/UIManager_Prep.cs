using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager_Prep : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    private int score = 0;
    private string scoreString = "Score: ";
    
    private void Start()
    {
        scoreText.text = scoreString + score;
    }

    public void SetScore(int puntos)
    {
        score += puntos;
        scoreText.text = scoreString + score;
    }
}
