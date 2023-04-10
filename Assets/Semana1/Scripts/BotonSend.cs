using System.Collections;
using System.Collections.Generic;
using TMPro; // Para acceder a objetos de tipo text mesh pro
using UnityEngine.UI; // Para acceder a cualquier cosa de UI (viven dentro del canvas)
using UnityEngine;

public class BotonSend : MonoBehaviour
{

    string nombreApellido;

    [Header("Contenedores")]
    [SerializeField] private Image contenedorPrincipal;
    [SerializeField] private Image contendendorSecundario;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField nombre;
    [SerializeField] private TMP_InputField apellido;

    [Header("Textos Tarjeta Secundaria")]
    [SerializeField] private TMP_Text nombreCompleto;


    private void Start()
    {
        nombreApellido = nombreCompleto.text;
    }


    public void EnviarForma()
    {
        // Desactivar container principal
        contenedorPrincipal.gameObject.SetActive(false);
        // Activar container secundario
        contendendorSecundario.gameObject.SetActive(true);

        // Quiero asignar el texto del input field de
        // nombre en el texto de nombre del segundo panel
        nombreApellido = nombre.text + " " + apellido.text;
        nombreCompleto.text = nombreApellido;
    }

    public void RegresarAForma()
    {
        // Desactivar segundo
        contendendorSecundario.gameObject.SetActive(false);
        // Activar principal
        contenedorPrincipal.gameObject.SetActive(true);
    }
}
