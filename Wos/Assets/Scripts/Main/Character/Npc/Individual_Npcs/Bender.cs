using System.Collections.Generic;
using UnityEngine;

public class Bender : Npc
{
    public Renderer[] RendererList;
    public Material Outline_mat;
    List<Material[]> Origin = new List<Material[]>();

    private void Start()
    {
        Child_Start_Setting();

        for (int i = 0; i < RendererList.Length; ++i)
        {
            Origin.Add(RendererList[i].materials);
        }
    }

    public override void Outline_SetActive(bool b)
    {
        
        if(b) //아웃라인 적용
        {
            for (int i = 0; i < RendererList.Length; ++i)
            {
                Material[] Change = new Material[2];
                Change[0] = RendererList[i].materials[0];
                Change[1] = Outline_mat;
                RendererList[i].materials = Change;
            }
        }
        else //아웃라인 해제
        {
            
            for (int i = 0; i < RendererList.Length; ++i)
            {
                RendererList[i].materials = Origin[i];
            }
        }
    }
}