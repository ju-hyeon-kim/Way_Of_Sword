using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Data : MonoBehaviour
{
    public int Quest_Number;
    public string Name;
    [Multiline]
    public string Explanation;
    public List<Item_Data> Reward;
}
