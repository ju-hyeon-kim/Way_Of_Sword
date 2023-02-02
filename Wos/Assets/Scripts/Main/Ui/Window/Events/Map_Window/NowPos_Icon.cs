using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowPos_Icon : MonoBehaviour
{
    Vector3 setPos = new Vector3(30.0f, 50.0f, 0.0f);
    public Transform NowPos;

    public void ChangePos(Transform Pos)
    {
        this.transform.SetParent(Pos);
        this.transform.position = Pos.position + setPos;
    }
    public void ReturnPos()
    {
        this.transform.SetParent(NowPos);
        this.transform.position = NowPos.position + setPos;
    }
    public void ChangeNowPos(Transform Pos)
    {
        NowPos = Pos;
    }
}
