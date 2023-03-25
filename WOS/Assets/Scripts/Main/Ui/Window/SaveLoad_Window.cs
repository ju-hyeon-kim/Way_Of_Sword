using TMPro;
using UnityEngine;

public class SaveLoad_Window : MonoBehaviour
{
    [Header("-----SaveLode_Window-----")]
    public Animator Book_Anim;
    public GameObject SaveLode_Set;
    public SavePage[] SavePages;
    public TMP_Text PageNumber;
    public int Now_PageNum = 1;

    public void NextButton()
    {
        if (Now_PageNum < 3)
        {
            Set_OnOff(false);
            Book_Anim.SetTrigger("NextFlip");
        }
    }

    public void FrontButton()
    {
        if (Now_PageNum > 1)
        {
            Set_OnOff(false);
            Book_Anim.SetTrigger("FrontFlip");
        }
    }

    public void Plus_PageNum()
    {
        Now_PageNum++;
        Change_PageNum(Now_PageNum);
        Set_OnOff(true);
    }

    public void Minus_PageNum()
    {
        Now_PageNum--;
        Change_PageNum(Now_PageNum);
        Set_OnOff(true);
    }

    void Set_OnOff(bool b)
    {
        if (b)
        {
            for (int i = 0; i < SavePages.Length; i++)
            {
                if (i == Now_PageNum - 1)
                {
                    SavePages[i].gameObject.SetActive(true);
                }
                else
                {
                    SavePages[i].gameObject.SetActive(false);
                }
            }

        }
        SaveLode_Set.SetActive(b);

    }

    void Change_PageNum(int Num)
    {
        PageNumber.text = $" {Num} / 3";
    }
}