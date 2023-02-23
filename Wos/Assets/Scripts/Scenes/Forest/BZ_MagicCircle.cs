using UnityEngine;

public class BZ_MagicCircle : MonoBehaviour
{
    public Manager_Forest myManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myManager.Spawn_BeatleKing();
            myManager.BossZone_Door.SetBool("Open", true);
            gameObject.SetActive(false);
        }
    }
}
