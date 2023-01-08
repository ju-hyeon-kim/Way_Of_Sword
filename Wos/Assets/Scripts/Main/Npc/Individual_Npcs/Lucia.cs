using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.Rendering.RendererUtils;

public class Lucia : Npc
{
    public GameObject Body_Outline;

    private void Start()
    {
        Child_Start_Setting();
    }

    public override void Outline_Active() // �ƿ����� ����
    {
        Body_Outline.SetActive(true);
    }

    public override void Outline_Unactive() // �ƿ����� ����
    {
        Body_Outline.SetActive(false);
    }
}
