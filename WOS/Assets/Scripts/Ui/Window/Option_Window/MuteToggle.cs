using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public Slider mySlider;

    public void MuteOnOff() // OnValueChanged
    {
        if (GetComponent<Toggle>().isOn)
        {
            mySlider.value = 0.0001f;
        }
    }
}
