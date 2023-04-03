using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnviarForma : MonoBehaviour
{

    // Cambio de Paneles
    [SerializeField] private Image mainContainer;
    [SerializeField] private Image secondContainer;

    // Cambio de textos
    // Nombre
    [SerializeField] private TMP_InputField nombreEntrada;
    [SerializeField] private TMP_Text nombreCompletoSalida;
    // Apellido
    [SerializeField] private TMP_InputField apellidoEntrada;
    // Correo
    [SerializeField] private TMP_InputField correoEntrada;
    [SerializeField] private TMP_Text correoSalida;
    // Usuario
    [SerializeField] private TMP_InputField usaurioEntrada;
    [SerializeField] private TMP_Text usuarioSalida;

    /*
    * Animacion de Panel
    */

    [SerializeField] private Animator animacionMainPanel;
    [SerializeField] private Animator animacionSecondPanel;

    private void Awake()
    {
        // // Prende el primer container por default
        // mainContainer.gameObject.SetActive(true);
        // secondContainer.gameObject.SetActive(false);
    }


    public void Enviar()
    {
        // Asignación de Textos
        AsignarInformacion(nombreEntrada, apellidoEntrada, nombreCompletoSalida);
        AsignarInformacion(correoEntrada, correoSalida);
        AsignarInformacion(usaurioEntrada, usuarioSalida);

        // Cambia de Panel
        CambioDePanel();
    }


    public void AsignarInformacion(TMP_InputField entrada, TMP_Text salida)
    {
        // Reemplaza el texto asignado.
        salida.text = entrada.text;
    }

    // Overload function
    public void AsignarInformacion(TMP_InputField entrada, TMP_InputField segundaEntrada, TMP_Text sumaEntradas)
    {
        sumaEntradas.text = entrada.text + " " + segundaEntrada.text;
    }

    public void CambioDePanel()
    {
        // Cambia de Panel de Ida y de Vuelta
        if (mainContainer.gameObject.activeSelf == true)
        {
            // mainContainer.gameObject.SetActive(false);

            //Panel Sube
            animacionMainPanel.SetTrigger("CambioPanelAnim");
            //Panel Baja
            secondContainer.gameObject.SetActive(true);
            animacionSecondPanel.SetTrigger("SecondPanelAnim");
        }
        else

        {
            // mainContainer.gameObject.SetActive(true);
            // secondContainer.gameObject.SetActive(false);
            //Panel Baja
            animacionMainPanel.SetTrigger("CambioPanelAnim");
            //Panel Sube
            animacionSecondPanel.SetTrigger("SecondPanelAnim");
        }
    }
}
