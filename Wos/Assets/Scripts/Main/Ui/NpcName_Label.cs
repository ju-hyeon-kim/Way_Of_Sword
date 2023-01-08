using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcName_Label : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static NpcName_Label Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static NpcName_Label Inst
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

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
