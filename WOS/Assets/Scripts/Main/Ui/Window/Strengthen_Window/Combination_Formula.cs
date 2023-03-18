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

    int Mstone_RrequiredQuantity = 10;
    int Gold_RrequiredQuantity = 1000;

    public void Setting(Item_2D item)
    {
        int strengthen = item.GetComponent<Item2D_isStrengthen>().Strengthen;
        Mstone_RrequiredQuantity *= strengthen + 1;
        MagicStone_QuantityText.text = $"({Get_HaveQuantity_ofMagicStone()}/{Mstone_RrequiredQuantity})";

        Gold_RrequiredQuantity *= strengthen + 1;
        Gold_QuantityText.text = $"{Gold_RrequiredQuantity}G";
        Gold_2D.myData.SellPrice = Gold_RrequiredQuantity;

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
}
