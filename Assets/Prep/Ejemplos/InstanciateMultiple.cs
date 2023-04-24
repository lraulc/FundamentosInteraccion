using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateMultiple : MonoBehaviour
{
    [Header("Prefab - Counter")]
    [SerializeField] private GameObject celulaPrefab;
    [SerializeField] private int cantidadCelulas = 5;
    [SerializeField] private Transform parent;

    [Header("Prefab - Array")]
    [SerializeField] private Color[] coloresRandom = new Color[5];
    [SerializeField] private GameObject[] celulas = new GameObject[5];


    private float limiteIzquierda = -8.9f;
    private float limiteAbajo = -4.42f;

    private void Start()
    {
        AparecerCelulas();
    }

    private void AparecerCelulas()
    {
        for (int i = 0; i < cantidadCelulas; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(limiteIzquierda, -limiteIzquierda), Random.Range(limiteAbajo, -limiteAbajo), 0.0f);
            GameObject celulaNueva = Instantiate(celulaPrefab, randomPos, Quaternion.identity, parent);
            CambiarColorCelulas(celulaNueva);
        }
    }

    private void CambiarColorCelulas(GameObject celula)
    {
        for (int elemento = 0; elemento < celulas.Length; elemento++)
        {
            Color randomColor = RandomColor();
            celulas[elemento].GetComponent<SpriteRenderer>().color = randomColor;
        }
    }

    private Color RandomColor()
    {
        Color randColor = new Color();
        for (int i = 0; i < coloresRandom.Length; i++)
        {
            coloresRandom[i] = Random.ColorHSV(0.0f, 1.0f, 0.3f, 1.0f, 0.2f, 1.0f);
            randColor = coloresRandom[i];
        }
        return randColor;
    }
}
