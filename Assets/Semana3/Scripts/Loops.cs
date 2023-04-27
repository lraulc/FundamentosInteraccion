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



    static public int categoria = 0;

    public int Btn_abeja()
    {
        //cambio de sprite
        categoria = 0;
        return categoria;
    }
    public int Btn_mariposa()
    {
        //cambio de sprite
        categoria = 1;
        return categoria;
    }
    public int Btn_catarina()
    {
        //cambio de sprite
        categoria = 2;
        return categoria;
    }

    public int Seleccion()
    {
        switch (categoria)
        {
            case 0:
                categoria = Btn_abeja();
                break;
            case 1:
                categoria = Btn_mariposa();
                break;
            case 2:
                categoria = Btn_catarina();
                break;
            default:
                Debug.LogError("Esa categoria no existe");
                break;
        }
        return categoria;
    }






}
