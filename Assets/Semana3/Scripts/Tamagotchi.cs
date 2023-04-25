using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Tamagotchi : MonoBehaviour
{
    [Header("Controles Generales")]
    [SerializeField] Animator tamagotchiAnimator;
    [SerializeField] GameObject comida;
    [SerializeField] private Button[] botones;

    [Header("Contoles de Vida")]
    [SerializeField] private TMP_Text textoVida;
    [SerializeField] private int healAmount = 20;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private Color colorStart = new Color();
    [SerializeField] private Color colorDanger = new Color();

    [Header("Sprites Vida")]
    [SerializeField] private Sprite[] imagenesVida;
    [SerializeField] private GameObject imagenComida;

    Sprite imagenComidaSprite;

    private string porcentaje = "%";
    private int vida = 100;
    private int vidaMax = 100;


    private void Start()
    {
        textoVida.text = vida + porcentaje;
        textoVida.color = colorStart;

        imagenComidaSprite = imagenComida.GetComponent<SpriteRenderer>().sprite;

        ApagarBotones();
        Invoke("PrenderBotones", 3.0f);
        InvokeRepeating("Damage", 3.0f, 0.2f);
    }

    public void Dormir()
    {
        print("Dormir");
        ApagarBotones();
        tamagotchiAnimator.SetTrigger("triggerDormir");

        Invoke("RegresoIdle", 2.0f);
    }

    public void Shower()
    {
        print("Shower");
        ApagarBotones();
        tamagotchiAnimator.SetTrigger("triggerShower");

        Invoke("RegresoIdle", 2.0f);
    }

    public void Comer()
    {
        print("Comer");
        Curar();
        ApagarBotones();
        tamagotchiAnimator.SetTrigger("triggerComer");
        comida.SetActive(true);

        Invoke("ApagarComida", 2.0f);
    }

    private void RegresoIdle()
    {
        tamagotchiAnimator.SetTrigger("regresoIdle");
        PrenderBotones();
    }

    private void ApagarComida()
    {
        RegresoIdle();
        comida.SetActive(false);
    }

    private void ApagarBotones()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = false;
        }
    }

    private void PrenderBotones()
    {
        for(int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = true;
        }
    }

    private void Damage()
    {
        vida -= damageAmount;
        vida = Mathf.Clamp(vida, 0, vidaMax);
        textoVida.text = vida + porcentaje;

        if(vida < vidaMax / 2)
        {
            textoVida.color = colorDanger;
            imagenComida.GetComponent<SpriteRenderer>().sprite = imagenesVida[1];
        }

        if(vida < vidaMax / 5)
        {
            imagenComida.GetComponent<SpriteRenderer>().sprite = imagenesVida[2];
        }
    }

    private void Curar()
    {
        vida += healAmount;
        vida = Mathf.Clamp(vida, 0, vidaMax);
        textoVida.text = vida + porcentaje;

        if (vida > vidaMax / 2)
        {
            textoVida.color = colorStart;
        }
    }
}
