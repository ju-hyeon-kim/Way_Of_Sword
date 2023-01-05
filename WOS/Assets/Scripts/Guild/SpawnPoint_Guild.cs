using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Guild : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static SpawnPoint_Guild Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static SpawnPoint_Guild Inst
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
}
