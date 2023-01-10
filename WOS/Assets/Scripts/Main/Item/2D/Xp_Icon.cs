using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xp_Icon : Icon
{
    public Xp_Data Xp_Data;

    public override void GiveData_DW()
    {
        //�̹���
        XpGoldData_Window.Inst.Image.sprite = Xp_Data.Image;
        //�̸�
        XpGoldData_Window.Inst.Name.text = Xp_Data.Name;
        //��ġ
        XpGoldData_Window.Inst.Price.text = $"{Xp_Data.Price}Xp";
    }

    public override void Show_DataWindow()
    {
        XpGoldData_Window.Inst.gameObject.SetActive(true);
        size = ItemData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f -1f, size.y * 0.5f - 80f);
    }

    public override void Updating_DataWindow(PointerEventData eventData)
    {
        XpGoldData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public override void unShow_DataWindow()
    {
        XpGoldData_Window.Inst.gameObject.SetActive(false);
    }

}
