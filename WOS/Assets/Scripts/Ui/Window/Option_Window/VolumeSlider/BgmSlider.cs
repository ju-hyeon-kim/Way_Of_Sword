using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : VolumeSlider
{
    public override void SetVolume() //onchangevalue
    {
        
        Slider slider = GetComponent<Slider>();

        //�����̴� �����(flaot) -> ���� -> ������ͼ�������(db)
        Manager_Sound.Inst.AudioMixer.SetFloat("Bgm", Mathf.Log10(slider.value) * 20);
        Level.text = $"{Mathf.Round(slider.value * 100)}";
        if (slider.value != 0.0001f)
        {
            MuteToggle.isOn = false;
        }
    }
}
