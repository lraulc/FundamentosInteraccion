using System.Collections;
using System.Collections.Generic;
using TMPro; // Para acceder a objetos de tipo text mesh pro
using UnityEngine.UI; // Para acceder a cualquier cosa de UI (viven dentro del canvas)
using UnityEngine;

public class BotonSend : MonoBehaviour
{
    [Header("Contenedores")] [SerializeField]
    private Image contenedorPrincipal;

    [SerializeField] private Image contendendorSecundario;

    [Header("Input Fields")] [SerializeField]
    private TMP_InputField nombre;

    [SerializeField] private TMP_InputField apellido;
    [SerializeField] private TMP_InputField correoInputField;
    [SerializeField] private TMP_InputField userInputField;

    [Header("Textos Tarjeta Secundaria")] [SerializeField]
    private TMP_Text nombreCompleto;

    [SerializeField] private TMP_Text correo;
    [SerializeField] private TMP_Text user;

    string nombreApellido;

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
        
        //Asignacion de Nombre
        nombreApellido = nombre.text + " " + apellido.text;
        nombreCompleto.text = nombreApellido;

        
        // Asignacion de correo
        correo.text = correoInputField.text;
        
        // Asignacion de Usuario
        user.text = userInputField.text;

        
        // Usando funciones
        // CambioTextos(nombre, apellido, nombreCompleto);
        // CambioTextos(correoInputField, correo);
        // CambioTextos(userInputField, user);
    }

    public void RegresarAForma()
    {
        // Desactivar segundo
        contendendorSecundario.gameObject.SetActive(false);
        // Activar principal
        contenedorPrincipal.gameObject.SetActive(true);
    }

    
    /*
     * EXTRAS
     */
    
    private void CambioTextos(TMP_InputField inputField, TMP_Text textoSalida)
    {
        textoSalida.text = inputField.text;
    }

    // Function Overload
    private void CambioTextos(TMP_InputField primerInputField, TMP_InputField segundoInputField,
        TMP_Text sumaInputFields)
    {
        if (primerInputField.text == string.Empty)
        {
            sumaInputFields.text = segundoInputField.text;
        }
        else
        {
            sumaInputFields.text = primerInputField.text + " " + segundoInputField.text;
        }
    }
}