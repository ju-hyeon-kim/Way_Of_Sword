using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillData_Window : MonoBehaviour
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Skill_Explanation;

    Vector2 Pos = Vector2.zero;

    private void Start()
    {
        //사이즈에 맞게 포지션 조정
        float posX = GetComponent<RectTransform>().sizeDelta.x;
        float posY = GetComponent<RectTransform>().sizeDelta.y;
        Pos = new Vector2((posX * 0.5f) + 0.1f, (posY * 0.5f) + 0.1f);
    }

    public void Data_Setting(Skill_2D Skill)
    {
        Image.sprite = Skill.GetComponent<Image>().sprite;
        Name.text = Skill.myData.Name;
        Skill_Explanation.text = Skill.myData.Explanation;
    }

    public void Updating_Position(PointerEventData eventData)
    {
        this.transform.position = eventData.position + Pos;
    }
}