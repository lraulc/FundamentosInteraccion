using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propiedades Movimiento")] [Range(0.0f, 10.0f)] [SerializeField]
    private float velocidad = 10.0f;

    // Limites de la pantalla para mi jugador
    float limiteHorizontal = -8.329f;
    float limiteVertical = 4.53f;

    // Update is called once per frame
    void Update()
    {
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
}
