using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;

    // private void Start()
    // {
    //     InvokeRepeating("aparecerPelotas", 1.0f, 1.0f);
    // }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aparecerPelotas();
        }
    }


    private void aparecerPelotas()
    {
        float randomPosicionX = Random.Range(-8.0f, 8.0f);
        float randomPosicionY = Random.Range(-4.5f, 4.5f);
        Vector3 posicionesRandom = new Vector3(randomPosicionX, randomPosicionY, 0.0f);

        GameObject pickup = Instantiate(pickupPrefab, posicionesRandom, Quaternion.identity);
        pickup.transform.SetParent(gameObject.transform);
    }
}
