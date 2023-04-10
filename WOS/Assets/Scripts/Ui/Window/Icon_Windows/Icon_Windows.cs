using UnityEngine;

public class Icon_Windows : MonoBehaviour
{
    public SwordIcon_Window SwordIcon_Window;

    void Start()
    {
        SwordIcon_Window.StartSetting(); // 현재 오브 슬롯에 장착되어있는 오브에 따라 스킬 셋 세팅
    }
}
