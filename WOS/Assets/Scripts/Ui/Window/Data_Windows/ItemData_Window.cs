using UnityEngine;
using UnityEngine.EventSystems;


public class ItemData_Window : MonoBehaviour
{
    public RectTransform myCanvas;

    Vector2 Pos = Vector2.zero;
    Vector2 upPos = Vector2.zero;
    Vector2 downPos = Vector2.zero;

    private void Start()
    {
        //����� �°� ������ ����
        float posX = GetComponent<RectTransform>().sizeDelta.x;
        float posY = GetComponent<RectTransform>().sizeDelta.y;
        upPos = new Vector2(-((posX * 0.5f) + 0.1f), (posY * 0.5f) + 0.1f);
        downPos = new Vector2(upPos.x, -upPos.y);
    }

    public void Data_Setting(Item_2D item2D)
    {
        if (item2D.transform.position.y > myCanvas.sizeDelta.y * 0.5f)//�������� ��ġ�� ĵ������ �߾Ӱ��μ��� ���̺��� ���ٸ�
        {
            Pos = downPos;
        }
        else
        {
            Pos = upPos;
        }
        DataSetting_ofChild(item2D);
    }

    public void Updating_Position(PointerEventData eventData)
    {
        this.transform.position = eventData.position + Pos;
    }

    public virtual void DataSetting_ofChild(Item_2D item2D) { }
}
