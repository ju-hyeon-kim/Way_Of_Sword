using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Transform myItem = eventData.pointerDrag.transform;

        if (TypeDetect(eventData))
        {
            //�������� �޴´�.
            myItem.SetParent(transform); // �������� �������� �θ� = ����
            myItem.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
            DropEvent(eventData);
        }
        else
        {
            //�������� ���� �ʴ´�.
            myItem.SetParent(myItem.GetComponent<Item_2D>().Before_Parents);
            myItem.SetSiblingIndex(myItem.GetComponent<Item_2D>().Before_ChildNum);
            myItem.localPosition = Vector3.zero;
        }
    }

    public virtual void DropEvent(PointerEventData eventData)
    {
        //�ڽĵ��� ������
    }

    public virtual bool TypeDetect(PointerEventData eventData) //������ Ÿ���� �����Ͽ� ���Կ� ������ ������ �˻��Ѵ�.
    {
        //�ڽĵ��� ������
        return true;
    }
}
