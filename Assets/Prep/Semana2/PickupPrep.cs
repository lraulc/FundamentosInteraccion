using UnityEngine;

public class PickupPrep : MonoBehaviour
{
    [SerializeField] public int points = 10;
    ScoreManagerPrep scoreManager;
    HealthManager healthManager;

    [Header("Pickup Type")]
    [SerializeField] public bool randomType = false;
    [Tooltip("0 = Points, 1 = Heal, 2 = Heal + Points")]
    [SerializeField] private int healAmount = 10;
    [SerializeField] public int pickupType;

    [Header("Pickup Color")]
    private Color startingColor;
    private SpriteRenderer sprite;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManagerPrep>();
        if (scoreManager == null) Debug.LogError($"No ScoreManager found in {this.gameObject}");

        healthManager = FindObjectOfType<HealthManager>();
        if (healthManager == null) Debug.LogError($"No Health Manager found on {this.gameObject}");

        sprite = GetComponent<SpriteRenderer>();

        if (randomType == true)
        {
            pickupType = Random.Range(0, 3);
            PickupTypeColorChange(pickupType);
        }
        else
        {
            PickupTypeColorChange(pickupType);
        }

    }

    private void PickupTypeColorChange(int type)
    {
        switch (type)
        {
            case 0:
                startingColor = Color.blue;
                sprite.color = startingColor;
                break;
            case 1:
                startingColor = Color.green;
                sprite.color = startingColor;
                break;
            case 2:
                startingColor = Color.yellow;
                sprite.color = startingColor;
                break;
            default:
                print("No pickup type assigned");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (pickupType)
            {
                case 0:
                    scoreManager.UpdateScore(points);
                    break;
                case 1:
                    print("Heal");
                    healthManager.Heal(healthManager.currentHealth, healAmount);
                    break;
                case 2:
                    print("Heal + points");
                    scoreManager.UpdateScore(points);
                    healthManager.Heal(healthManager.currentHealth, healAmount / 2);
                    break;
                default:
                    print("No Type found");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
