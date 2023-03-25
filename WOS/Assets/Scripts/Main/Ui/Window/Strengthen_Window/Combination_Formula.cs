using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combination_Formula : MonoBehaviour
{
    public TMP_Text MagicStone_QuantityText;
    public TMP_Text Gold_QuantityText;
    public Item_2D Gold_2D;
    public TMP_Text Percentage_Text;
    public Strengthen_Button Strengthen_Button;
    public int Mstone_RrequiredQuantity; // 강화에 쓰일 마석의 필요량 -> Strengthen_Button이 호출해서 사용함

    int Gold_RrequiredQuantity; // 강화에 쓰일 골드의 필요량

    public void Setting(Item_2D item)
    {
        
        int strengthen = item.GetComponent<Item2D_isStrengthen>().Strengthen;
        Mstone_RrequiredQuantity = 10;
        Mstone_RrequiredQuantity *= strengthen + 1;
        MagicStone_QuantityText.text = $"({Get_HaveQuantity_ofMagicStone()}/{Mstone_RrequiredQuantity})";

        Gold_RrequiredQuantity = 1000;
        Gold_RrequiredQuantity *= strengthen + 1;
        Gold_QuantityText.text = $"{Gold_RrequiredQuantity}G";
        Gold_2D.myData.SellPrice = Gold_RrequiredQuantity;

        int p = 100 - (10 * strengthen);
        Percentage_Text.text = $"{p}%";

        Strengthen_Button.Setting_forStrengthen(item, Gold_RrequiredQuantity);
        Strengthen_Button.Lock.SetActive(!IsMstone_Enough());
    }

    int Get_HaveQuantity_ofMagicStone()
    {
        //현재 보유하고있는 마석의 수량 가져오기
        return Dont_Destroy_Data.Inst.Inventory_Window.Get_HaveAmount_ofMagicStone();
    }

    public bool IsMstone_Enough()
    {
        if(Get_HaveQuantity_ofMagicStone() > Mstone_RrequiredQuantity)
        {
            return true;
        }
        return false;
    }

    public bool Strengthen_Result(int strengthen)
    {
        bool result = false;

        
        bool[] array = new bool[10]; 
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = false;
        }

        for (int i = strengthen; i < array.Length; i++)
        {
            array[i] = true;
        }

        int r = Random.Range(0, 9);
        if (array[r])
        {
            result = true;
        }

        return result;
    }
}
