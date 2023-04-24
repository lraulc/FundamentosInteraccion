using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("General Debug")]
    [SerializeField] private bool hasUI = false;

    [Header("UI Elements - Healthbar and Score")]
    [SerializeField] private TMP_Text scoreTitle;
    [SerializeField] private TMP_Text contadorText;
    [SerializeField] public Slider healthBar;
    [SerializeField] private TMP_Text contadorComida;
    [SerializeField] private GameObject gameOverContainer;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color startColor = new Color(1, 1, 1, 1);
    [SerializeField] private Color endColor = new Color(1, 1, 1, 1);

    private string scoreString = "Score: ";
    private int scoreNumero = 0;

    private string contadorString = "Contador: ";
    private int contadorNum = 0;

    Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        if (player == null) { Debug.LogError("No hay player en la escena"); }

        fillImage.color = startColor;
        
        scoreTitle.text = scoreString + scoreNumero;

            // Cuando arranca mi juego, apaga el panel de game over
            gameOverContainer.SetActive(false);

            contadorComida.text = contadorString + contadorNum;

        }

    }

    public void SetScore(int puntaje)
    {
        scoreNumero += puntaje;
        scoreTitle.text = scoreString + scoreNumero;
    }

    public void AgregarContador()
    {
        contadorNum++;
        contadorText.text = contadorString + contadorNum;
    }






    public void Damage(int damageAmount)
    {
        healthBar.value -= damageAmount;

        if (healthBar.value < healthBar.maxValue / 2)
        {
            fillImage.color = endColor;
        }

        if (healthBar.value <= 0)
        {
            GameOverScreen();
        }
    }

    public void Heal(int healAmount)
    {
        healthBar.value += healAmount;
        if (healthBar.value >= healthBar.maxValue / 2)
        {
            fillImage.color = startColor;
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

    public void SumaComida()
    {
        contadorNum += 1;
        contadorComida.text = contadorString + contadorNum;
    }
}
