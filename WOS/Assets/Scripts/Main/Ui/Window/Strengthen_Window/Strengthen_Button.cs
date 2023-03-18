using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Strengthen_Button : MonoBehaviour
{
    public GameObject Lock;
    public Strengthen_Anim Strengthen_Anim;

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
        //지불
        Pay();

        //강화 애니메이션
        Strengthen_Anim.gameObject.SetActive(true);
        Strengthen_Anim.OnAnim();

        //Strengthen++
        //Item.GetComponent<Item2D_isStrengthen>().Strengthen++;
    }

    void Pay() // 아이템과 돈을 지불한다.
    {
        Dont_Destroy_Data.Inst.Manager_Gold.NowGold -= Price;
    }
}