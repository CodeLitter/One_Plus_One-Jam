using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public GameObject credits;
    public GameObject instructions;

    public void openCredits()
    {
        if (!instructions.activeSelf)
        {
            credits.SetActive(true);
        }        
    }

    public void closeCredits()
    {
        credits.SetActive(false);
    }

    public void openInstructions()
    {
        if (!credits.activeSelf)
        {
            instructions.SetActive(true);
        }
    }

    public void closeInstructions()
    {
        instructions.SetActive(false);
    }

}
