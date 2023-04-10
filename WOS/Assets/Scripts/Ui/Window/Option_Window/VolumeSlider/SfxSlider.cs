using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxSlider : VolumeSlider
{
    public override void SetVolume() // onchangedvalue
    {
        float decibel = Mathf.Log10(mySlider.value) * 20; //슬라이더의 필어마운트값 -> 데시벨로 바꿈
        Manager_Sound.Inst.AudioMixer.SetFloat("Sfx", decibel);

        Level.text = $"{Mathf.Round(mySlider.value * 100)}";
        if (mySlider.value != 0.0001f)
        {
            MuteToggle.isOn = false;
        }
    }
}
