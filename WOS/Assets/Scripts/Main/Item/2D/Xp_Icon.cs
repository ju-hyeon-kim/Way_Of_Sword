using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xp_Icon : Item_Icon
{
    public Xp_Data Xp_Data;

    public override void GiveData()
    {
        //�̹���
        ItemData_Window.Inst.Public_Set.Image.sprite = Xp_Data.Image;
        //�̸�
        ItemData_Window.Inst.Public_Set.Name.text = Xp_Data.Name;
        //��ġ

        //������ ����Ÿ ������ Ȱ��ȭ ( myType�� ���� Set�� ������ )
        for (int i = 0; i < 4; i++)
        {
            ItemData_Window.Inst.Type_Sets[i].SetActive(false);
            if (i == (int)myType)
            {
                ItemData_Window.Inst.Type_Sets[i].SetActive(true);
            }
        }
    }


}
