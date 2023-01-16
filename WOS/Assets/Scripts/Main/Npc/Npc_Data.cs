using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Npc_IndividualData // Npc�𵨿� ���� �޶����� '���� ����Ÿ'
{
    public string Name;
    [Multiline]
    public string Greetings; // �λ�
    public Transform myForward;
    public Transform NameLabel_Zone;
    public GameObject Npc_Icon;
}

[System.Serializable]
public class Npc_CommonData // Npc�� �� �Ȱ��� ����ϴ� '���� ����Ÿ'
{
    public NpcTalk_Window NpcTalk_Window;
    public MainCam_Controller MainCam;
    public Vector3 OrgForward;
}
