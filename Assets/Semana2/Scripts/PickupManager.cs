using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    public List<int> listaPickups = new List<int>();

    private void Start()
    {
        InvokeRepeating("aparecerPelotas", 1.0f, 1.0f);
    }


    private void aparecerPelotas()
    {
        float randomPosicionX = Random.Range(-8.0f, 8.0f);
        float randomPosicionY = Random.Range(-4.5f, 4.5f);
        Vector3 posicionesRandom = new Vector3(randomPosicionX, randomPosicionY, 0.0f);

        GameObject pickup = Instantiate(pickupPrefab, posicionesRandom, Quaternion.identity);
        pickup.transform.SetParent(gameObject.transform);

        OrdenarLista();
    }

    public void OrdenarLista()
    {
        int categoriaCero = 0;
        int categoriaUno = 0;
        int categoriaDos = 0;
        for (int i = 0; i < listaPickups.Count; i++)
        {
            if (listaPickups[i] == 0)
            {
                categoriaCero++;
            }
            else if (listaPickups[i] == 1)
            {
                categoriaUno++;
            }
            else
            {
                categoriaDos++;
            }
        }
        // print($"Categoria Cero: {categoriaCero}\nCategoria Uno: {categoriaUno}\nCategoria Dos: {categoriaDos}");
    }
}
