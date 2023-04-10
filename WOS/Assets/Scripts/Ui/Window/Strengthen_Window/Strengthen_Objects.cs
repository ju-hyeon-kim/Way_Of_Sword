using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strengthen_Objects : MonoBehaviour
{
    public Combination_Formula Combination_Formula;
    public BeforeData BeforeData;
    public AfterData AfterData;
    

    public void Setting(Item_2D Item)
    {
        Combination_Formula.Setting(Item);
        BeforeData.Setting(Item);
        AfterData.Setting(Item);
    }
}
