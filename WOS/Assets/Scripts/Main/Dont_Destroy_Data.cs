using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    #region 싱글톤 세팅 + Awake()
    private static Dont_Destroy_Data Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
        DontDestroyOnLoad(this);
    }

    public static Dont_Destroy_Data Inst
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

    public Manager_Cams Manager_Cams;
    public Map_Window Map_Window;

    public void Start_Setting()
    {
        Manager_Cams.Start_Setting();
        Manager_Quest.Inst.Start_Setting();
    }
}
