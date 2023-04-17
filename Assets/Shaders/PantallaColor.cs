using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode]
public class PantallaColor : MonoBehaviour
{
    [SerializeField] private Color screenColor = new Color(1, 1, 1, 1);
    private Material screenMaterial;

    private void OnValidate()
    {
        screenMaterial = gameObject.GetComponent<Image>().material;
    }

    private void Update()
    {
        screenMaterial.SetColor("_SolidColor", screenColor);
    }
}
