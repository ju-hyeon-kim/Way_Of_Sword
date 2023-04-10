using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Toggle MuteToggle;
    public TMP_Text Level;

    protected Slider mySlider
    {
        get => GetComponent<Slider>();
    }

    public virtual void SetVolume() { } // OnChangedValue

    
}
