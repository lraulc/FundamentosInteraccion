using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerTamago : MonoBehaviour
{
    [SerializeField] private Animator tamagochiAnimator;
    [SerializeField] private Button[] button;
    private string animationTriggerName;

    public void Eat()
    {
        TriggerAnimation("Eat");
        button[0].interactable = true;
        button[1].interactable = false;
        button[2].interactable = false;
        print("Eat");
    }
    public void Sleep()
    {
        TriggerAnimation("Sleep");
        print("Eat");
        button[0].interactable = false;
        button[1].interactable = true;
        button[2].interactable = false;
    }
    public void Shower()
    {
        TriggerAnimation("Shower");
        print("Eat");
        button[0].interactable = false;
        button[1].interactable = false;
        button[2].interactable = true;
    }

    private void TriggerAnimation(string triggerName)
    {
        tamagochiAnimator.SetTrigger(triggerName);
    }
}
