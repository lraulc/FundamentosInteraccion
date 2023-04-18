using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    UIManager UIManager;

    [SerializeField] private int categoria;

    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        if (UIManager == null)
        {
            Debug.LogError("UI Manager no existe en la escena, agrega uno.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jugador")
        {

            switch (categoria)
            {
                case 0:
                    UIManager.SetScore(1);
                    break;
                case 1:
                    UIManager.SetScore(50);
                    break;
                case 2:
                    UIManager.SetScore(400);
                    break;
                default:
                    print("No existe esa categoria");
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
