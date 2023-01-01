using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public Item.Type SlotType = default; // �ν����Ϳ��� ������

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ���� Ÿ�԰� ���ٸ� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void DropEvent(PointerEventData eventData)
    {
        Transform myItem = eventData.pointerDrag.transform;
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        myItem.transform.SetAsFirstSibling();
        // ���� �����̶��
        if(SlotType == Item.Type.Obe)
        {
            myItem.GetComponent<Obe_Icon>().SkillSet_Conection();
        }
    }
}
