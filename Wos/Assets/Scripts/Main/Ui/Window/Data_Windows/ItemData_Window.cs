using UnityEngine;
using UnityEngine.EventSystems;


public class ItemData_Window : MonoBehaviour
{
    Vector2 Pos = Vector2.zero;
    private void Start()
    {
        //사이즈에 맞게 포지션 조정
        float posX = GetComponent<RectTransform>().sizeDelta.x;
        float posY = GetComponent<RectTransform>().sizeDelta.y;
        Pos = new Vector2((posX * 0.5f) + 0.1f, (posY * 0.5f) + 0.1f);
    }

    public virtual void Data_Setting(Item_2D item2D) { }

    public void Updating_Position(PointerEventData eventData)
    {
        this.transform.position = eventData.position + Pos;
    }
}
