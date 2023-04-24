using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{

    //private string[] nombres = { "Nombre1", "Nombre2", "Nombre3", "Nombre4" };

    [SerializeField] private GameObject[] objetos;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            print($"Nombre de Objeto: {objetos[i].name}\nPosicion Objeto: {objetos[i].transform.position}");
        }
    }
}
