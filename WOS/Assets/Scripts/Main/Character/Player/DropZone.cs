using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public List<Item_3D> DropItems = new List<Item_3D>();
    public Inventory_Window Inventory_Window;

    public void Pickup_Item()
    {
        if(DropItems.Count > 0) //����� �������� �������� ����
        {
            Inventory_Window.Put_Item(DropItems[0].myItem2D);

            //3D�� ���� -> 2D ���� �κ��丮�� ������
            DropItems[0].Pickup();

            //����Ʈ���� ����
            DropItems.RemoveAt(0);
        }
    }
}
