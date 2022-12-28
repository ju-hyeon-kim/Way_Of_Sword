using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotType
{
    PlayerEquipment, InvenEquipment
}

public class Item_Slot : MonoBehaviour, IDropHandler
{
    public SlotType myType = default(SlotType); // �ν����Ϳ��� ������

    public virtual void OnDrop(PointerEventData eventData)
    {
        switch(myType) 
        {
            case SlotType.InvenEquipment: // �κ��丮â�� ��� â�� ���
                // �������� �������� �� ��� �������� �ƴϸ� ���� �� ����
                if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Equipment)
                {
                    eventData.pointerDrag.transform.SetParent(transform); // �������� �������� �θ� = ����
                    eventData.pointerDrag.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
                }
                // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
                eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                break;
            case SlotType.PlayerEquipment: // �÷��̾�â�� ��� â�� ���
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
