using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    UIManager_Prep UIManager;

    private void Start()
    {
        UIManager = FindObjectOfType<UIManager_Prep>();
        if (UIManager == null) { Debug.LogError("No UI Manager found, add one"); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIManager.Damage(50);
        }
    }
}
