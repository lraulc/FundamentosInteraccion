using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTitle;
    private string scoreString = "Score: ";
    private int scoreNumero = 0;

    private void Start()
    {
        scoreTitle.text = scoreString + scoreNumero;
    }

    public void SetScore(int puntaje)
    {
        scoreNumero += puntaje;
        scoreTitle.text = scoreString + scoreNumero;
    }

}
