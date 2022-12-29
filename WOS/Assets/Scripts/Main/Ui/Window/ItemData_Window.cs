using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData_Window : MonoBehaviour // 싱글톤
{
    #region 싱글톤 세팅 + Awake()
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
        //아이템에 맞게 세팅
    }
}
