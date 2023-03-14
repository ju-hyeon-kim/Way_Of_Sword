using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combination_Formula : MonoBehaviour
{
    public TMP_Text MagicStone_QuantityText;
    public TMP_Text Gold_QuantityText;
    public TMP_Text Percentage_Text;

    int MagicStone_RrequiredQuantity = 10;
    int Gold_RrequiredQuantity = 1000;

    public void Setting(Item_2D Item)
    {
        ItemData_isStrengthen Sdata = Item.myData as ItemData_isStrengthen;
        int strengthen = Sdata.Strengthen;

        MagicStone_RrequiredQuantity *= strengthen + 1;
        MagicStone_QuantityText.text = $"({Get_HaveQuantity_ofMagicStone()}/{MagicStone_RrequiredQuantity})";

        Gold_RrequiredQuantity *= strengthen + 1;
        Gold_QuantityText.text = $"{Gold_RrequiredQuantity}G";
    }

    int Get_HaveQuantity_ofMagicStone()
    {
        //현재 보유하고있는 마석의 수량 가져오기
        return 0;
    }
}
