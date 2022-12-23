using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_test : MonoBehaviour
{
    public Material[] Change;
    public Material[] Original;
    public LayerMask PickMask;

    private void Update()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, PickMask))
            {
                transform.GetComponent<MeshRenderer>().materials = Change;
            }
            else
            {
                transform.GetComponent<MeshRenderer>().materials = Original;
            }
    }
}
