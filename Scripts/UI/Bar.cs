using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    public void OnVelaueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
