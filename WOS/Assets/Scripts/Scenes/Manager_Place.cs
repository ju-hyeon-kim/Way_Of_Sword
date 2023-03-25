using UnityEngine;

public class Manager_Place : MonoBehaviour
{
    [Header("-----Manager_Place-----")]
    public Transform[] Guide_Tartgets;

    private void Start()
    {
        Dont_Destroy_Data.Inst.LodeData();
        Start_ofChild();
    }

    public virtual void Start_ofChild() { }
}
