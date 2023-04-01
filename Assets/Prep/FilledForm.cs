using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledForm : MonoBehaviour
{
    public bool isFilled = false;

    private void Awake()
    {
        isFilled = false;
    }

    public bool isComplete(bool hasInput)
    {
        isFilled = hasInput;
        return isFilled;
    }
}
