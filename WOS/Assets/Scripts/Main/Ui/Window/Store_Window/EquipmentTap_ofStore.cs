using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentTap_ofStore : MonoBehaviour
{
    public GoodsBar[] GoodsBars;

    private void Start()
    {
        for(int i = 0; i < GoodsBars.Length; i++)
        {
            GameObject Item = Instantiate(Dont_Destroy_Data.Inst.Manager_Item.ItemList[GoodsBars[0].ItemID], GoodsBars[0].ItemSlot);
            Item.transform.SetAsFirstSibling();
        }
    }
       
}
