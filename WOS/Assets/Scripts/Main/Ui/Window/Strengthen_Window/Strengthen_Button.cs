using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Strengthen_Button : MonoBehaviour
{
    public GameObject Lock;
    public Strengthen_Anim Strengthen_Anim;
    public Combination_Formula Combination_Formula;

    Item_2D Item;
    int Price = 0;

    public void Lock_SetActive(bool b)
    {
        Lock.SetActive(b);
    }

    public void Setting_forStrengthen(Item_2D item, int price)
    {
        this.Item = item;
        Price = price;
    }

    public void ClickButton() //��ư ���ε�
    {
        Question_Window QWindow = Dont_Destroy_Data.Inst.Question_Window;
        string text = "�������� ��ȭ�Ͻðڽ��ϱ�?";
        QWindow.WindowSetting(text, Strengthen_Item);
        QWindow.gameObject.SetActive(true);
    }

    void Strengthen_Item() // Qustion_Window�� YesButtonŬ���� �ߵ�
    {
        //������ ���� ����
        Item.canDrag = false;
        Item.canViewData = false;

        //����
        Pay();

        //��ȭ�� �������� �������� ���
        bool result = Combination_Formula.Strengthen_Result(Item.GetComponent<Item2D_isStrengthen>().Strengthen);
        if(result)
        {
            Item.GetComponent<Item2D_isStrengthen>().Strengthen++;
        }

        //��ȭ �ִϸ��̼�
        Strengthen_Anim.gameObject.SetActive(true);
        Strengthen_Anim.OnAnim(result);
    }

    void Pay() // �����۰� ���� �����Ѵ�.
    {
        Dont_Destroy_Data.Inst.Inventory_Window.Pay_MagicStone(Combination_Formula.Mstone_RrequiredQuantity);
        Dont_Destroy_Data.Inst.Manager_Gold.NowGold -= Price;
    }
}