using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class myGold_Text : MonoBehaviour
{
    public void Change_Gold(int price)
    {
        GetComponent<TMP_Text>().text = $"{price.ToString("N0")} G";
    }
}
