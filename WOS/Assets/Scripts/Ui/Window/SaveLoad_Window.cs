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

    public void FlipButton(bool isnext)// onclick
    {


        bool b = isnext ? Now_PageNum < 3 : Now_PageNum > 1;
        if (b)
        {
            //sfx
            //Manager_Sound.Inst.SfxSource.OnPlay(7);

            Set_OnOff(false);
            string s = isnext ? "NextFlip" : "FrontFlip";
            Book_Anim.SetTrigger(s);
        }
    }

    public void Plus_PageNum() //AnimEvent
    {
        Now_PageNum++;
        Change_PageNum(Now_PageNum);
        Set_OnOff(true);
    }

    public void Minus_PageNum() //AnimEvent
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