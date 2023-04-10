using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeforeData : MonoBehaviour
{
    public TMP_Text ItemName;
    public TMP_Text Strengthen;
    public TMP_Text StatName;
    public TMP_Text Stat;

    public void Setting(Item_2D Item)
    {
        Item_Data Idata = Item.myData;
        ItemName.text = Idata.Name;
        int strengthen = Item.GetComponent<Item2D_isStrengthen>().Strengthen;
        Strengthen.text = $"+{strengthen}";

        switch (Idata.ItemType)
        {
            case ItemType.Equipment:
                Equipment_Data EquipData = Idata as Equipment_Data;
                if(EquipData.EquipmentType == EquipmentType.Weapon)
                {
                    StatName.text = " 공격력";
                }
                else
                {
                    StatName.text = " 방어력";
                }
                Stat.text = $" +{EquipData.Stat[strengthen]}";
                break;
        }
    }
}
