using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tamagotchi : MonoBehaviour
{
    [SerializeField] Animator tamagotchiAnimator;
    [SerializeField] GameObject comida;
    [SerializeField] private Button[] botones;


    private void Start()
    {
        ApagarBotones();
        Invoke("PrenderBotones", 3.0f);
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
}
