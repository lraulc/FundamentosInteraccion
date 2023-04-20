using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTitle;
    [SerializeField] public Slider healthBar;
    [SerializeField] private GameObject gameOverContainer;
    private string scoreString = "Score: ";
    private int scoreNumero = 0;



    Player player;



    private void Start()
    {
        scoreTitle.text = scoreString + scoreNumero;

        player = FindObjectOfType<Player>();
        if (player == null) { Debug.LogError("No hay player en la escena"); }

        // Cuando arranca mi juego, apaga el panel de game over
        gameOverContainer.SetActive(false);
    }

    public void SetScore(int puntaje)
    {
        scoreNumero += puntaje;
        scoreTitle.text = scoreString + scoreNumero;
    }

    public void Damage(int damageAmount)
    {
        healthBar.value -= damageAmount;

        if (healthBar.value <= 0)
        {
            GameOverScreen();
        }
    }

    public void GameOverScreen()
    {
        gameOverContainer.SetActive(true);
        player.gameObject.SetActive(false);
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
