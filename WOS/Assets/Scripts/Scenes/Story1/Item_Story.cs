using JetBrains.Annotations;
using UnityEngine;

public class Item_Story : MonoBehaviour
{
    public GameObject ItemLabel_Window;
    public Material[] Change;
    public Material[] Original;
    public Sword_Zone Sword_Zone;

    public void CanPickUp(bool b)
    {
        if(b)
        {
            GetComponent<MeshRenderer>().materials = Change;
        }
        else
        {
            GetComponent<MeshRenderer>().materials = Original;
        }
        
        ItemLabel_Window.gameObject.SetActive(b);
    }
}
