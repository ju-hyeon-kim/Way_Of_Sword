using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent_BookAnim : MonoBehaviour
{
    public void Plus_PageNum()
    {
        transform.parent.GetComponent<SaveLode_Window>().Plus_PageNum();
    }

    public void Minus_PageNum()
    {
        transform.parent.GetComponent<SaveLode_Window>().Minus_PageNum();
    }
}
