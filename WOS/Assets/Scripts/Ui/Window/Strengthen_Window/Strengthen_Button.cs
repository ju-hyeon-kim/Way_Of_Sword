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

    public void ClickButton() //버튼 바인딩
    {
        Question_Window QWindow = Dont_Destroy_Data.Inst.Question_Window;
        string text = "아이템을 강화하시겠습니까?";
        QWindow.WindowSetting(text, Strengthen_Item);
        QWindow.gameObject.SetActive(true);
    }

    void Strengthen_Item() // Qustion_Window의 YesButton클릭시 발동
    {
        //아이템 상태 변경
        Item.canDrag = false;
        Item.canViewData = false;

        //지불
        Pay();

        //강화가 성공인지 실패인지 계산
        bool result = Combination_Formula.Strengthen_Result(Item.GetComponent<Item2D_isStrengthen>().Strengthen);
        if(result)
        {
            Item.GetComponent<Item2D_isStrengthen>().Strengthen++;
        }

        //강화 애니메이션
        Strengthen_Anim.gameObject.SetActive(true);
        Strengthen_Anim.OnAnim(result);
    }

    void Pay() // 아이템과 돈을 지불한다.
    {
        Dont_Destroy_Data.Inst.Inventory_Window.Pay_MagicStone(Combination_Formula.Mstone_RrequiredQuantity);
        Dont_Destroy_Data.Inst.Manager_Gold.NowGold -= Price;
    }
}