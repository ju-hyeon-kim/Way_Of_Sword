using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xp_2D : Item_2D
{
   /* public override void GiveData_DW()
    {
        //이미지
        //XpGoldData_Window.Inst.Image.sprite = myData.Image;
        //이름
        XpGoldData_Window.Inst.Name.text = myData.Name;
        //수치
        XpGoldData_Window.Inst.Price.text = $"{myData.Price}Xp";
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
    }*/

}
