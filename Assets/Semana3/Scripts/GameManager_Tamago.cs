using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager_Tamago : MonoBehaviour
{
    [SerializeField] private TMP_Text vida;
    private string porcentaje = "%";
    public int vidaActual = 100;


    [SerializeField] private GameObject popo;
    public int cantidadPopo;
    public bool isRIP;

    Tamagotchi_Terminado tamagochi;

    private void Start()
    {
        vida.text = vidaActual + porcentaje;
        isRIP = false;

        tamagochi = FindObjectOfType<Tamagotchi_Terminado>();
        if (tamagochi == null) Debug.LogError("No hay Tamagochi");

        // Daño constante cada X segundos.
        InvokeRepeating("Damage", 3.0f, 0.2f);
    }

    private void Update()
    {
        if (cantidadPopo > 3)
        {
            isRIP = true;
            tamagochi.RIP();
        }
    }


    public void Popos()
    {
        Instantiate(popo, new Vector3(Random.Range(-4.0f, 4.0f), 0.0f, 0.0f), Quaternion.identity);
        cantidadPopo++;
        print($"Popos: {cantidadPopo}");
    }


    public void Curar(int healAmount)
    {
        vidaActual += healAmount;
        vidaActual = Mathf.Clamp(vidaActual, 0, 100);
        vida.text = vidaActual + porcentaje;
        Invoke("Popos", Random.Range(0.2f, 3.0f));
    }

    public void Damage()
    {
        vidaActual -= 1;
        vidaActual = Mathf.Clamp(vidaActual, 0, 100);
        vida.text = vidaActual + porcentaje;
    }
}
