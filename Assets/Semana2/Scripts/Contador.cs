using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    int contador = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            contador++;

            if (contador == 10)
            {
                print("Ya termine de contar");
            }
        }
    }
}
