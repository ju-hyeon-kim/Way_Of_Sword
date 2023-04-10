using UnityEngine;

public class MiniMap_Icon : MonoBehaviour
{
    public Transform myTarget;

    private void Start()
    {
        Vector3 pos = new Vector3(myTarget.position.x, 0.0f, myTarget.position.z);
        transform.position = pos;
    }
}
