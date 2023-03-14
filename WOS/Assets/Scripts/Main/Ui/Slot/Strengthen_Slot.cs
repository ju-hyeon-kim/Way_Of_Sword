using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strengthen_Slot : Item_Slot
{
    public GameObject NoticeText;
    public Strengthen_Objects Strengthen_Objects;

    public override void OnDrop_ofChild()
    {
        NoticeText.SetActive(false);
        Strengthen_Objects.Setting(myItem);
        Strengthen_Objects.gameObject.SetActive(true);
    }
}
