using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomTool : MonoBehaviour
{
    public Transform[] slots;
    public GameObject Q;
    public Image org;

    [ContextMenu("�Լ�����")]
    void tool()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //���ε�
            //slots[i].GetComponent<Inventory_Slot>().Quantity_Text = slots[i].GetChild(0).GetChild(0).GetComponent<TMP_Text>();

            //����
            DestroyImmediate(slots[i].GetChild(0).gameObject);

            //����
            /*GameObject X = Instantiate(Q, slots[i]);
            X.name = "Quantity";
            X.transform.SetAsFirstSibling();
            Vector2 pos = new Vector2(22, 30);
            X.transform.localPosition = pos;*/

            //��Ȱ��ȭ
            //slots[i].GetChild(0).gameObject.SetActive(false);

            //��������
            //Color Ccolor = new Color( 1f, 1f, 1f, 0.04f);
            //slots[i].GetComponent<Image>().color = Ccolor;
            //slots[i].localPosition = org.transform.localPosition;
            //slots[i].GetComponent<Inven_Slot>().myQuantity_Text.fontSize = 15;
        }
    }
}
