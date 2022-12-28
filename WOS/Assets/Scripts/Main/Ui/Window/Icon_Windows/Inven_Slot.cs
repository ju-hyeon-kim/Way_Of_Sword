using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : MonoBehaviour, IDropHandler
{
    ItemSlot_Type itemslot_type = ItemSlot_Type.Inven;
    public InvenSlot_Type invenslot_type = default(InvenSlot_Type); // �ν����Ϳ��� ������

    public void OnDrop(PointerEventData eventData)
    {
        switch (invenslot_type)
        {
            case InvenSlot_Type.Equipment: // �κ�â�� ��񽽷��� ���
                if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Equipment)
                {
                    eventData.pointerDrag.transform.SetParent(transform); // �������� �������� �θ� = ����
                    eventData.pointerDrag.transform.SetSiblingIndex(1); // �������� ������ 2��° �ڽ����� ����
                    eventData.pointerDrag.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
                }
                // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
                eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                break;
        }
    }
}
