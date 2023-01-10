using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpGoldData_Window : MonoBehaviour
{
    #region 싱글톤 세팅 + Awake()
    private static XpGoldData_Window Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static XpGoldData_Window Inst
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

    public Image Image;
    public TMP_Text Name;
    public TMP_Text Price;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
