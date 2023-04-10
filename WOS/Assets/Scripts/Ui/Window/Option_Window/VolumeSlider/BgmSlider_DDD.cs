using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider_DDD : BgmSlider
{
    //현재 오디오 믹서의 데시벨 -> 필어마운트 값으로 변경 -> 변경값으로 세팅
    void Start()
    {
        //데시벨 -> 필어마운트값으로 바꿈
        float decibel = 0;
        Manager_Sound.Inst.AudioMixer.GetFloat("Bgm", out decibel);

        mySlider.value = Mathf.Pow(10, decibel / 20);
        Level.text = $"{Mathf.Round(mySlider.value * 100)}";
    }
}
