using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcName_Label : MonoBehaviour
{
    #region 싱글톤 세팅 + Awake()
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
            if (Instence == null) // 다른 오브젝트의 Awake()에서 Inst를 호출할 경우
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
