using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propiedades Movimiento")]
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float velocidad = 10.0f;

    private float vidaActual;

    // Limites de la pantalla para mi jugador
    float limiteHorizontal = -8.329f;
    float limiteVertical = 4.53f;


    private SpriteRenderer playerSprite;
    private Color damageColor = new Color(1, 0, 0, 1);
    private Color startColor = new Color(1, 1, 1, 1);
    
    
    /*
     * Variables de Managers
     */
    UIManager UIManager;


    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        if (UIManager == null)
        {
            Debug.LogError("No existe un UI manager en la escena, agrega uno.");
        }

        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerSprite.color = startColor;
    }

    
    // Update is called once per frame
    void Update()
    {
        vidaActual = UIManager.healthBar.value;
        // print($"Vida Actual Player = {vidaActual}");
        
        Movimiento();
    }

    private void Movimiento()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(inputHorizontal, inputVertical);

        //Frame independant
        transform.Translate(direccion * (velocidad * Time.deltaTime));

        if (transform.position.x < -8.329f)
        {
            transform.position = new Vector2(-8.329f, transform.position.y);
        }
        else if (transform.position.x > 8.329f)
        {
            transform.position = new Vector2(8.329f, transform.position.y);
        }

        // Limite Vertical
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -limiteVertical, limiteVertical));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            damageColorChange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
        {
            playerSprite.color = startColor;
        }
    }

    public void damageColorChange()
    {
        playerSprite.color = damageColor;
    }
}
