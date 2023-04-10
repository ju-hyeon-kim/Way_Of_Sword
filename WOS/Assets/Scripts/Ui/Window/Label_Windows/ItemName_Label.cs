using TMPro;
using UnityEngine;

public class ItemName_Label : MonoBehaviour
{
    public Transform myNameZone = null;
    bool isSetting = false;

    void Update()
    {
        if (isSetting)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(myNameZone.position);
            transform.position = pos;
        }
    }

    public void NameSetting(string name)
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = name;
        isSetting = true;
    }
}
