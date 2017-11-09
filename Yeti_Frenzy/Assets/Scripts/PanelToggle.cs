using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public GameObject panel;

    public void openPanel()
    {
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }

}
