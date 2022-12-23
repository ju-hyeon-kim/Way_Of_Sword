using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public Material OutLine;
    public Renderer[] RendererList;


    private void Start()
    {
        for(int i = 0; i < RendererList.Length; ++i)
        {
            Material[] Change = new Material[2];
            Change[0] = RendererList[i].materials[0];
            Change[1] = OutLine;
            RendererList[i].materials = Change;
        }
    }
    private void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, this.gameObject.layer))
        {
            transform.GetComponent<MeshRenderer>().materials = Change;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().materials = Original;
        }*/
    }
}
