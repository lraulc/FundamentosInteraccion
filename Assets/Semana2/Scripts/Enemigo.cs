using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    UIManager UIManager;


    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        if (UIManager == null)
        {
            Debug.LogError("Oye, no hay UI Manager, agrega uno al Canvas.");
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            UIManager.Damage(50);
            print("ME ESTOY QUEMANDO, NO MAMES!!");
        }
    }
}
