using UnityEngine;
using UnityEngine.UI;

public class HP_of_Dummy : MonoBehaviour
{
    public Transform myHpZone;
    public Image HP_Bar;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(myHpZone.position);
        transform.position = pos;
    }
}
