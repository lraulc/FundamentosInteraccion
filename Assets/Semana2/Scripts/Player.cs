using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propiedades Movimiento")]
    [Range(0.0f,10.0f)]
    [SerializeField] private float velocidad;

    // Limites de la pantalla para mi jugador
    float limiteHorizontal = -8.329f;
    float limiteVertical = 4.53f;

    int a = 3;
    int b = 5;

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(inputHorizontal, inputVertical);

        //Frame independant

        if (transform.position.x > limiteHorizontal && transform.position.x < limiteHorizontal * -1)
        {
            transform.Translate(direccion * (velocidad * Time.deltaTime));
        }
        else
        {
            print("Ya se atoró");
        }



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //a = a + 1;
         //   a += 1;
         //   print(a);

         //   if (a > b)
         //   {
         //       print("Verdadero");
         //   }
         //   else
         //   {
         //       print("Falso");
          //  }

       // }

    }
}
