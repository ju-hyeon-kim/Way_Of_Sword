using TMPro;
using UnityEngine;

public class NowGold_Text : MonoBehaviour
{
    public void Change_Gold(int price)
    {
        GetComponent<TMP_Text>().text = $"{price.ToString("N0")} G";
    }
}
