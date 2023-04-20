using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager_Prep : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public Slider healthBar;
    [SerializeField] private Image gameOverPanel;

    private float vidaActual;
    private int score = 0;
    private string scoreString = "Score: ";
    public bool isGameOver = false;


    GameManager_Prep gameManager_Prep;


    private void Awake()
    {
        gameOverPanel.gameObject.SetActive(false);
    }


    private void Start()
    {
        scoreText.text = scoreString + score;
        vidaActual = healthBar.value;

        gameManager_Prep = FindObjectOfType<GameManager_Prep>();
        if (gameManager_Prep == null) { Debug.LogError("No Game Manager Found"); }


    }

    public void SetScore(int puntos)
    {
        score += puntos;
        scoreText.text = scoreString + score;
    }

    public void Damage(int damageAmount)
    {
        vidaActual -= damageAmount;
        healthBar.value = vidaActual;

        if (vidaActual == 0)
        {
            SetGameOverScreen();
        }
    }

    public bool SetGameOverScreen()
    {
        gameOverPanel.gameObject.SetActive(true);
        isGameOver = true;
        gameManager_Prep.GameOver();
        return isGameOver;
    }
}
