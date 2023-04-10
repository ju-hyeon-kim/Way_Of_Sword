using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterData : MonoBehaviour
{
    public TMP_Text ItemName;
    public TMP_Text Strengthen;
    public TMP_Text StatName;
    public TMP_Text Stat;

    public void Setting(Item_2D Item)
    {
        Item_Data Idata = Item.myData;
        ItemName.text = Idata.Name;
        

        Strengthen.color = Color.red;
        int strengthen = Item.GetComponent<Item2D_isStrengthen>().Strengthen;
        Strengthen.text = $"+{strengthen + 1}";

        switch (Idata.ItemType)
        {
            case ItemType.Equipment:
                Equipment_Data EquipData = Idata as Equipment_Data;
                if (EquipData.EquipmentType == EquipmentType.Weapon)
                {
                    StatName.text = " 공격력";
                }
                else
                {
                    StatName.text = " 방어력";
                }
                Stat.text = $" +{EquipData.Stat[strengthen + 1]}<color=#ff0000>(+{AddStat(EquipData, strengthen)})</color>";
                break;
        }

        float AddStat(Equipment_Data data, int strnegthen)
        {
            float addstat = data.Stat[strnegthen + 1] - data.Stat[strnegthen];
            return addstat;
        }
    }
}
