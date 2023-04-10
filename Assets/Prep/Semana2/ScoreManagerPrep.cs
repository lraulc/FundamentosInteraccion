using TMPro;
using UnityEngine;

public class ScoreManagerPrep : MonoBehaviour
{
    [Header("Score Core Variables")]
    public int score;
    [SerializeField] private TMP_Text scoreTitle;
    private string startingText = "Score: ";

    private void Start()
    {
        score = 0;
        scoreTitle.text = startingText + score;
    }


    public void UpdateScore(int points)
    {
        score += points;
        scoreTitle.text = startingText + score.ToString();
    }
}
