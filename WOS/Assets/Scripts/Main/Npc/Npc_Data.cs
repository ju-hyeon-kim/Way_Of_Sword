using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Npc_Data
{
    public string Name;
    [TextArea]
    public string Talk; // �λ�
    public Sprite Profile;
    public Transform myForward;
}
