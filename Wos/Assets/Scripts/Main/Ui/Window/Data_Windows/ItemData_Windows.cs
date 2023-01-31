using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemData_Windows : MonoBehaviour // ΩÃ±€≈Ê
{
    public GameObject[] myWindows;

    public ItemData_Window Show_DataWindow(Item_2D item2D)
    {
        for(int i = 0; i < myWindows.Length; i++)
        {
            if(i == (int)item2D.myData.ItemType)
            {
                myWindows[i].GetComponent<ItemData_Window>().Data_Setting(item2D);
                myWindows[i].SetActive(true);
                return myWindows[i].GetComponent<ItemData_Window>();
            }
            else
            {
                myWindows[i].SetActive(false);
            }
        }
        return null;
    }
}
