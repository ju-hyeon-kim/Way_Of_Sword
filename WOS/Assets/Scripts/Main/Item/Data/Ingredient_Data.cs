using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient_Data", menuName = "ScriptableObjects/Ingredient_Data", order = 1)]
public class Ingredient_Data : Item_Data
{
    [TextArea]
    public string Explanation;
}
