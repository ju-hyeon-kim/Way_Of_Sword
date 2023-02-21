using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRange : MonoBehaviour
{
    public List<Item_3D> DropItems = new List<Item_3D>();

    public void Pickup_Item()
    {
        if(DropItems.Count > 0) //����� �������� �������� ����
        {
            //�������� �κ��丮�� �ֱ�
            Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(DropItems[0].myItem2D);

            //�������� ����ٰ� �޽������� ǥ��
            Dont_Destroy_Data.Inst.Message_Window.Get_Item(DropItems[0].myItem2D);

            //3D�� ���� -> 2D ���� �κ��丮�� ������
            DropItems[0].Pickup();

            //����Ʈ���� ����
            DropItems.RemoveAt(0);
        }
    }
}
