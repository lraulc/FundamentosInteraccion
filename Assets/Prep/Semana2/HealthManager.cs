using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health Bar Core Variables")]
    public int currentHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image gameOverScreen;

    [Header("Health Bar Visual Settings")]
    [SerializeField] private Image FillImage;
    [SerializeField] private Color startingColor = new Color(1, 1, 1, 1);
    [SerializeField] private Color dangerColor = new Color(1, 1, 1, 1);

    [Header("Restart Button Settings")]
    [SerializeField] private Button restartButton;

    PlayerPrep player;

    private void Awake()
    {
        gameOverScreen.gameObject.SetActive(false);
    }

    private void Start()
    {

        player = FindObjectOfType<PlayerPrep>();
        if (player == null) Debug.LogError($"Player not found on {this}");

        healthBar.value = healthBar.maxValue;
        currentHealth = (int)healthBar.value;

        FillImage.color = startingColor;
    }

    public void Damage(int currentHealth, int damageAmount)
    {
        healthBar.value -= damageAmount;
        FillImage.color = Color.Lerp(startingColor, dangerColor, math.remap(100, 0, 0, 1, healthBar.value));
    }

    public void GameOverScreen()
    {
        if (healthBar.value <= 0)
        {
            // Enable UI Game Over
            gameOverScreen.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
        }
    }

    public void Heal(int currentHealth, int healAmount)
    {
        healthBar.value += healAmount;
        FillImage.color = Color.Lerp(startingColor, dangerColor, math.remap(100, 0, 0, 1, healthBar.value));

    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync("2D_Juego_Terminado");
    }
}
