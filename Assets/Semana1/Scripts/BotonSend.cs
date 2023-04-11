using System.Collections;
using System.Collections.Generic;
using TMPro; // Para acceder a objetos de tipo text mesh pro
using UnityEngine.UI; // Para acceder a cualquier cosa de UI (viven dentro del canvas)
using UnityEngine;

public class BotonSend : MonoBehaviour
{
    [Header("Contenedores")] 
    [SerializeField] private Image contenedorPrincipal;

    [SerializeField] private Image contendendorSecundario;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField nombre;

    [SerializeField] private TMP_InputField apellido;
    [SerializeField] private TMP_InputField correoInputField;
    [SerializeField] private TMP_InputField userInputField;

    [Header("Textos Tarjeta Secundaria")] 
    [SerializeField] private TMP_Text nombreCompleto;
    [SerializeField] private TMP_Text correo;
    [SerializeField] private TMP_Text user;


    public void EnviarForma()
    {
        // Desactivar container principal
        contenedorPrincipal.gameObject.SetActive(false);
        // Activar container secundario
        contendendorSecundario.gameObject.SetActive(true);

        // Quiero asignar el texto del input field de
        // nombre en el texto de nombre del segundo panel

        //Asignacion de Nombre
        CambioTextos(nombre, apellido, nombreCompleto);

        // Asignacion de correo
        CambioTextos(correoInputField, correo);
        
        // Asignacion de Usuario
        CambioTextos(userInputField, user);

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
    
    private void CambioTextos(TMP_InputField entradaInputField, TMP_Text salidaTexto)
    {
        salidaTexto.text = entradaInputField.text;
    }

    // Function Overload
    private void CambioTextos(TMP_InputField primerTexto, TMP_InputField segundoTexto, TMP_Text sumaTextos)
    {
        sumaTextos.text = primerTexto.text + " " + segundoTexto.text;
    }


}