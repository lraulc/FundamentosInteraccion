using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    UIManager UIManager;

    [SerializeField] private int categoria;
    private Color pickupColor = new Color(1, 1, 1, 1);
    private SpriteRenderer sprite;
    
    
    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        if (UIManager == null)
        {
            Debug.LogError("UI Manager no existe en la escena, agrega uno.");
        }

        sprite = GetComponent<SpriteRenderer>();

        categoria = categoriaRandom();
        colorCategoria(categoria);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            switch (categoria)
            {
                case 0:
                    UIManager.SetScore(1);
                    UIManager.Heal(5);
                    break;
                case 1:
                    UIManager.SetScore(50);
                    UIManager.Heal(5);
                    break;
                case 2:
                    UIManager.SetScore(400);
                    UIManager.Heal(5);
                    break;
                default:
                    print("No existe esa categoria");
                    break;
            }
            UIManager.AgregarContador();
            Destroy(this.gameObject);
        }
    }

    //private int categoriaRandom()
    //{
    //    return Random.Range(0, 3);
    //}

    private int categoriaRandom()
    {
        int valorRandom = Random.Range(0, 3);
        return valorRandom;
    }

    private void colorCategoria(int categoriaRandom)
    {
        switch (categoriaRandom)
        {
            case 0:
                pickupColor = Color.green;
                sprite.color = pickupColor;
                break;
            case 1:
                pickupColor = Color.yellow;
                sprite.color = pickupColor;
                break;
            case 2:
                pickupColor = Color.magenta;
                sprite.color = pickupColor;
                break;
            default:
                print("No hay categoría de " + this.gameObject);
                break;
        }
    }


}
