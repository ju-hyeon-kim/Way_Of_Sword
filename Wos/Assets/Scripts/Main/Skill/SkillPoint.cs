using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SKILLTYPE
{
    RANGE, VECTOR
}

public class SkillPoint : MonoBehaviour
{
    public string Name;
    public SKILLTYPE skilltype;
}
