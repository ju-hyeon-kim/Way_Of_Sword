using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPGoldData_Window : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static XPGoldData_Window Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static XPGoldData_Window Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    public Image Image;
    public TMP_Text Name;
    public TMP_Text Price;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
