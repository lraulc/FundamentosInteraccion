using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private UIManager_Prep uiManagerPrep;

    private void Start()
    {
        uiManagerPrep = FindObjectOfType<UIManager_Prep>();
        if (uiManagerPrep == null) Debug.LogError("No UI Manager found in Scene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiManagerPrep.SetScore(10);
            Destroy(this.gameObject);
        }
    }
}
