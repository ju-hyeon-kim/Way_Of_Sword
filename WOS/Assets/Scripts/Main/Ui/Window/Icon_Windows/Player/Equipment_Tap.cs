using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Tap : MonoBehaviour
{
    public Equipment_Slot[] Slots;

    public float AddAp()
    {
        Weapon_Slot ws = Slots[0] as Weapon_Slot;
        return ws.Get_WeaponAp();
    }

    public float AddDp()
    {
        // ���߿� ���� 1~7 ���� �˻��Ͽ� ���� ������ ���� �ʿ�
        return 0;
    }
}
