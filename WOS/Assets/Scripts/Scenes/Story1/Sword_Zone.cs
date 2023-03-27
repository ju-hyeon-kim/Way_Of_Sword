using UnityEngine;

public class Sword_Zone : MonoBehaviour
{
    public Gm_Message Gm_Message;
    public Item_Story Sword;

    private void OnTriggerEnter(Collider obj)
    {
        Gm_Message.ShowMessage(1);
        Sword.CanPickUp(true);
    }

    private void OnTriggerExit(Collider obj)
    {
        Gm_Message.ShowMessage(0);
        Sword.CanPickUp(false);
    }
}
