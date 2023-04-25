using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Tamagotchi_Terminado : MonoBehaviour
{
    [SerializeField] Animator tamagotchiAnimator;
    [SerializeField] GameObject comida;

    [SerializeField] Button[] botones;
    private AnimatorClipInfo[] animatorClips;

    public int vidaTamagochi = 100;

    GameManager_Tamago gameManager;

    private void Start()
    {
        ApagarBotones();

        gameManager = FindObjectOfType<GameManager_Tamago>();
        if (gameManager == null) Debug.LogError("No hay Game Manager, agrega uno.");


        vidaTamagochi = gameManager.vidaActual;


        Invoke("ActivarBotones", 3.0f);
    }


    private void Update()
    {
        vidaTamagochi = gameManager.vidaActual;
        RIP();
    }

    private void ActivarBotones()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = true;
        }
    }

    private void ApagarBotones()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = false;
        }
    }

    public void Dormir()
    {
        print("Dormir");
        tamagotchiAnimator.SetTrigger("triggerDormir");
        ApagarBotones();

        Invoke("RegresoIdle", 2.0f);
    }

    public void Shower()
    {
        print("Shower");
        tamagotchiAnimator.SetTrigger("triggerShower");
        gameManager.LimpiaPopo();
        ApagarBotones();
        Invoke("RegresoIdle", 2.0f);
    }

    public void Comer()
    {
        print("Comer");
        Curar();
        tamagotchiAnimator.SetTrigger("triggerComer");
        comida.SetActive(true);
        ApagarBotones();

        Invoke("ApagarComida", 2.0f);
    }


    private void RegresoIdle()
    {
        tamagotchiAnimator.SetTrigger("regresoIdle");
        ActivarBotones();
    }

    private void ApagarComida()
    {
        RegresoIdle();
        comida.SetActive(false);
    }


    // Adicionales

    private void Curar()
    {
        gameManager.Curar(20);
    }
    public void RIP()
    {
        if (vidaTamagochi <= 0 || gameManager.isRIP == true)
        {
            tamagotchiAnimator.SetTrigger("triggerRIP");
            Invoke("ReloadGame", 3.0f);
        }
    }

    private void ReloadGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
