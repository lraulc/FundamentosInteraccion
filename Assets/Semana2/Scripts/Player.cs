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


    // Escala Objeto
    Transform playerTransform;
    Vector3 flip = new Vector3(-1, 1, 1);



    private float vidaActual;

    // Limites de la pantalla para mi jugador
    float limiteHorizontal = -8.329f;
    float limiteVertical = 4.53f;


    private SpriteRenderer playerSprite;
    private Color damageColor = new Color(1, 0, 0, 1);
    [SerializeField] private Color startColor = new Color(1, 1, 1, 1);


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
        playerTransform = gameObject.transform;
        vidaActual = UIManager.healthBar.value;
        Movimiento();
    }

    private void Movimiento()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");


        print($"Input Horizontal: {inputHorizontal}\nInput Vertical: {inputVertical}");

        Vector3 direccion = new Vector3(inputHorizontal, inputVertical);

        //Frame independant
        playerTransform = transform;
        playerTransform.Translate(direccion * (velocidad * Time.deltaTime));

        if (playerTransform.position.x < limiteHorizontal)
        {
            playerTransform.position = new Vector2(limiteHorizontal, playerTransform.position.y);
        }
        else if (playerTransform.position.x > -limiteHorizontal)
        {
            playerTransform.position = new Vector2(-limiteHorizontal, transform.position.y);
        }

        // Limite Vertical
        playerTransform.position = new Vector2(playerTransform.position.x, Mathf.Clamp(transform.position.y, -limiteVertical, limiteVertical));


        if (inputHorizontal > 0.1f)
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * flip.x, playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (inputHorizontal < 0.1f)
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, playerTransform.localScale.z);
        }

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
