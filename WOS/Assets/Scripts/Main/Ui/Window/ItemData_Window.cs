using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData_Window : MonoBehaviour // �̱���
{
    #region �̱��� ���� + Awake()
    private static ItemData_Window Instence = null;

    private void Awake()
    {
        if(Instence == null)
        {
            Instence = this;
        }
    }

    public static ItemData_Window Inst
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
    public TMP_Text Type;
    public TMP_Text AP;
    public TMP_Text Price;
    public TMP_Text Document_Text;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetData()
    {
        //�����ۿ� �°� ����
    }
}
