using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager_Prep : MonoBehaviour
{
    Player player;
    UIManager_Prep UIManager_Prep;

    private void Start()
    {
        UIManager_Prep = FindObjectOfType<UIManager_Prep>();
        if (UIManager_Prep == null) { Debug.LogError("No UI Manager Found, Add one."); }

        player = FindObjectOfType<Player>();
        if (player == null) { Debug.LogError("No Player found in Scene. Add one."); }

    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
    }
}
