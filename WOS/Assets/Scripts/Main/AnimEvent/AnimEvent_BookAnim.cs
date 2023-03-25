using UnityEngine;

public class AnimEvent_BookAnim : MonoBehaviour
{
    public void Plus_PageNum()
    {
        transform.parent.GetComponent<SaveLoad_Window>().Plus_PageNum();
    }

    public void Minus_PageNum()
    {
        transform.parent.GetComponent<SaveLoad_Window>().Minus_PageNum();
    }
}
