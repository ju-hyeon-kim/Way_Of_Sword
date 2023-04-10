using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Store_Window : Window, IPointerEnterHandler, IPointerExitHandler
{
    public Transform[] Taps;
    public Image[] NameTags;
    public Item_Slot[] SellZone_Slots;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(true);
    }

    public void ExitButton()
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(true);
        this.gameObject.SetActive(false);
    }

    public void Push_NameTag(int tapnum)
    {
        //NameTag
        for(int i = 0; i < NameTags.Length; i++)
        {
            if(i == tapnum)
            {
                NameTags[i].color = Color.white;
                NameTags[i].maskable = false;
            }
            else
            {
                NameTags[i].color = new Color(0.6f, 0.6f, 0.6f);
                NameTags[i].maskable = true;
            }
        }
        //Taps
        Taps[tapnum].SetAsLastSibling();
    }

    public void SellButton()
    {
        //Question_Window ����
        Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
        string s = $"�������� �Ǹ� �Ͻðڽ��ϱ�?\n�Ǹ� �� ��� �� ���: {Get_TotalPrice(false)}G";
        QW.WindowSetting(s, () => QW_YButton());
        QW.gameObject.SetActive(true);
    }

    int Get_TotalPrice(bool isSell)
    {
        int totalprice = 0;
        for (int i = 0; i < SellZone_Slots.Length; i++)
        {
            if (SellZone_Slots[i].myItem != null) // �������� �ִٸ�
            {
                totalprice += SellZone_Slots[i].myItem.myData.SellPrice;
                if(isSell)
                {
                    Destroy(SellZone_Slots[i].myItem.gameObject);
                }
            }
        }
        return totalprice;
    }

    void QW_YButton()
    {
        //�Ǹ��ϱ�
        Dont_Destroy_Data.Inst.Manager_Gold.NowGold += Get_TotalPrice(true);
    }
}
