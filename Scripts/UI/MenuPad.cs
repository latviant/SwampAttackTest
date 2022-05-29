using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPad : MonoBehaviour
{
    public void OpenPad(GameObject pad)
    {
        pad.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePad(GameObject pad)
    {
        pad.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
