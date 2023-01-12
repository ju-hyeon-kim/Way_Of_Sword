using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Data : MonoBehaviour
{
    public int Quest_Number;
    public string Name;
    [Multiline]
    public string Explanation;
    public List<GameObject> Reward;

    public virtual void Start_Questing()
    {

    }
}
