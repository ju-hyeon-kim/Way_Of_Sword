using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_2D : Item_2D
{
    public override void GiveData_DW()
    {
        Ingredient_Data mydata = myData.GetComponent<Ingredient_Data>(); // ��ũ���ͺ� ������Ʈ�� ������Ʈ�� ���������ʱ⿡  �ش� ���� ���Ұ�

        //�̹���
        ItemData_Window.Inst.Public_Set.Image.sprite = GetComponent<Image>().sprite;
        //�̸�
        ItemData_Window.Inst.Public_Set.Name.text = mydata.Name;
        //����
        ItemData_Window.Inst.Public_Set.Price.text = $"�Ǹ� ����: {mydata.Price} G";


        //Ÿ��
        ItemData_Window.Inst.Public_Set.Type.text = "���";
        //����
        ItemData_Window.Inst.Ingredient_Set.Explanation_Text.text = mydata.Explanation;


        //������ Ÿ�Կ� �´� ���� â�� Ȱ��ȭ
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
