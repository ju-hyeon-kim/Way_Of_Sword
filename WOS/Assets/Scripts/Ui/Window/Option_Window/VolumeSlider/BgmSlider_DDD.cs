using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider_DDD : BgmSlider
{
    //���� ����� �ͼ��� ���ú� -> �ʾ��Ʈ ������ ���� -> ���氪���� ����
    void Start()
    {
        //���ú� -> �ʾ��Ʈ������ �ٲ�
        float decibel = 0;
        Manager_Sound.Inst.AudioMixer.GetFloat("Bgm", out decibel);

        mySlider.value = Mathf.Pow(10, decibel / 20);
        Level.text = $"{Mathf.Round(mySlider.value * 100)}";
    }
}
