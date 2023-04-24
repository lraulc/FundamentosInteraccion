using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamagotchi : MonoBehaviour
{
    [SerializeField] Animator tamagotchiAnimator;
    [SerializeField] GameObject comida;

    public void Dormir()
    {
        print("Dormir");
        tamagotchiAnimator.SetTrigger("triggerDormir");

        Invoke("RegresoIdle", 2.0f);
    }

    public void Shower()
    {
        print("Shower");
        tamagotchiAnimator.SetTrigger("triggerShower");

        Invoke("RegresoIdle", 2.0f);
    }

    public void Comer()
    {
        print("Comer");

        tamagotchiAnimator.SetTrigger("triggerComer");
        comida.SetActive(true);

        Invoke("ApagarComida", 2.0f);
    }

    private void RegresoIdle()
    {
        tamagotchiAnimator.SetTrigger("regresoIdle");
    }

    private void ApagarComida()
    {
        RegresoIdle();
        comida.SetActive(false);
    }
}
