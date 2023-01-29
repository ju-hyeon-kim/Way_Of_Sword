using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemName_Label : MonoBehaviour
{
    public Transform myNameZone = null;
    public Color DropPossible_Color;
    Color Org_Color;
    bool isSetting = false;

    void Update()
    {
        if(isSetting)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(myNameZone.position);
            transform.position = pos;
        }
    }

    public void NameSetting(string name)
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = name;
        isSetting = true;
        Org_Color = GetComponent<Image>().color;
    }

    public void Drop_Possible()
    {
        GetComponent<Image>().color = DropPossible_Color;
    }

    public void Drop_Impossible()
    {
        GetComponent<Image>().color = Org_Color;
    }
}
