using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{
    public List<int> ages = new List<int>();
    public List<GameObject> objects = new List<GameObject>();
    [SerializeField] private GameObject Pickup;

    PickupPrerpManager pickupPrerpManager;

    private void Start()
    {
        pickupPrerpManager = FindObjectOfType<PickupPrerpManager>();
        if (pickupPrerpManager == null) Debug.LogError($"No Pickup Prep Manager found on {this.gameObject}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // objects.Add();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (objects.Count > 0)
            {
                // ages.Remove(ages[Random.Range(0, ages.Count)]);
            }
        }
    }
}
