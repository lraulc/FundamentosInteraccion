using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propiedades Movimiento")]
    [Range(0.0f,10.0f)]
    [SerializeField] private float velocidad;

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(inputHorizontal, inputVertical);

        //Frame independant
        transform.Translate(direccion * (velocidad * Time.deltaTime));

        print($"Valor Horizontal: {inputHorizontal}\nValor Vertical: {inputVertical}");
    }
}
