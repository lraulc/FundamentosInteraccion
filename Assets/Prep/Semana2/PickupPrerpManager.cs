using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPrerpManager : MonoBehaviour
{
    [SerializeField] private bool isEmpty = true;

    [SerializeField] private GameObject Pickup;
    public List<GameObject> PickupList = new List<GameObject>();
    int elements;

    private void Awake()
    {
        if (Pickup == null) Debug.LogError($"Please add Gameobject to {this.gameObject}");
    }

    private void Update()
    {
        if (PickupList.Contains(null))
        {
            PickupList.Remove(Pickup);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickupList.Add(Instantiate(Pickup, new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f), 0.0f), Quaternion.identity, this.gameObject.transform));
        }
    }
}
