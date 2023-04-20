using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float randomPosicionX = Random.Range(-8.0f, 8.0f);
            float randomPosicionY = Random.Range(-4.5f, 4.5f);
            Vector3 posicionesRandom = new Vector3(randomPosicionX, randomPosicionY, 0.0f);

            Instantiate(pickupPrefab, posicionesRandom, Quaternion.identity);
        }
    }
}
