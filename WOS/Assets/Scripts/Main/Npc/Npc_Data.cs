using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Npc_IndividualData // Npc모델에 따라 달라지는 '개별 데이타'
{
    public string Name;
    [Multiline]
    public string Greetings; // 인삿말
    public Transform myForward;
    public Transform NameLabel_Zone;
    public GameObject Npc_Icon;
}

[System.Serializable]
public class Npc_CommonData // Npc들 다 똑같이 사용하는 '공통 데이타'
{
    public NpcTalk_Window NpcTalk_Window;
    public MainCam_Controller MainCam;
    public Vector3 OrgForward;
}
