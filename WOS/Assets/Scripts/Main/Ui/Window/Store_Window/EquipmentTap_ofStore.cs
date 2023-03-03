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
            GoodsBars[i].ReadytoSell();
        }
    }
}
