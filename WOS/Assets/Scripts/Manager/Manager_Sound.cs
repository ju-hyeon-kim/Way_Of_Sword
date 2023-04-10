using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Manager_Sound : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static Manager_Sound Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Manager_Sound Inst
    {
        get
        {
            if (Instence == null) //���� ����Ŵ����� ���� ��
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    public AudioMixer AudioMixer;
    public BgmSource BgmSource;
    public SfxSource SfxSource;
}