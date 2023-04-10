using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : VolumeSlider
{
    public override void SetVolume() //onchangevalue
    {
        
        Slider slider = GetComponent<Slider>();

        //슬라이더 밸류값(flaot) -> 적용 -> 오디오믹서볼륨값(db)
        Manager_Sound.Inst.AudioMixer.SetFloat("Bgm", Mathf.Log10(slider.value) * 20);
        Level.text = $"{Mathf.Round(slider.value * 100)}";
        if (slider.value != 0.0001f)
        {
            MuteToggle.isOn = false;
        }
    }
}
