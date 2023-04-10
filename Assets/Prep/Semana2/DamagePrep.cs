using UnityEngine;

public class DamagePrep : MonoBehaviour
{
    [SerializeField] private int stayDamage = 1;

    HealthManager healthManager;
    PlayerPrep player;

    private void Start()
    {
        player = FindObjectOfType<PlayerPrep>();
        if (player == null) Debug.LogError("Player not found!");

        healthManager = FindObjectOfType<HealthManager>();
        if (player == null) Debug.LogError("Health Manager not found!");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Keep doing damage");
            healthManager.Damage(healthManager.currentHealth, stayDamage);
            healthManager.GameOverScreen();
        }
    }
}
