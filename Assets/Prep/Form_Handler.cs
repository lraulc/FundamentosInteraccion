using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Form_Handler : MonoBehaviour
{

    [SerializeField] private TMP_InputField[] userFilledContent;
    [SerializeField] private Image UIContainer;
    [SerializeField] private Toggle checkbox;
    [SerializeField] private Button sendButton;

    FilledForm _filledForm;
    public bool todosLlenos = false;
    public bool clicked = false;

    // Anim Canvas
    Vector2 startPos;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float offset = 1.0f;


    private void Awake()
    {
        sendButton.interactable = false;
        // vaciar variables
        for (int i = 0; i < userFilledContent.Length; i++)
        {
            userFilledContent[i].text = null;
        }
    }

    private void Start()
    {
        checkbox.isOn = false;
        sendButton.interactable = false;

        startPos = UIContainer.gameObject.transform.position;
    }

    private void ToggleButton(bool checkboxState)
    {
        sendButton.interactable = checkboxState;
    }

    public void EvaluateForms()
    {
        int counter = 0;

        for (int i = 0; i < userFilledContent.Length; i++)
        {
            if (userFilledContent[i].text == string.Empty)
            {
                userFilledContent[i].GetComponent<FilledForm>().isComplete(false);
            }
            else
            {
                userFilledContent[i].GetComponent<FilledForm>().isComplete(true);
                counter += 1;
                // print($"{userFilledContent[i].name} = {userFilledContent[i].GetComponent<FilledForm>().isComplete(true)}");
            }
        }

        if (counter >= userFilledContent.Length && checkbox.isOn == true)
        {
            todosLlenos = true;
            ToggleButton(true);
            print(todosLlenos);
        }
        else
        {
            ToggleButton(false);
            todosLlenos = false;
        }
    }

    public void Click()
    {
        clicked = true;
    }
}
