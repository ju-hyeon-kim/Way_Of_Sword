using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomTool : MonoBehaviour
{
    public Transform[] slots;
    public GameObject Q;

    [ContextMenu("함수실행")]
    void tool()
    {
        

        for(int i = 0; i < slots.Length; i++ )
        {
            //바인딩
            slots[i].GetComponent<Inven_Slot>().myQuantity_Text = slots[i].GetChild(0).GetChild(0).GetComponent<TMP_Text>();


            //삭제
            //DestroyImmediate(slots[i].GetChild(0).gameObject);

            //생성
            /*GameObject X = Instantiate(Q, slots[i]);
            X.name = "Quantity";
            X.transform.SetAsFirstSibling();
            Vector2 pos = new Vector2(22, 30);
            X.transform.localPosition = pos;*/

            //비활성화
            //slots[i].GetChild(0).gameObject.SetActive(false);
        }
    }
}
