using UnityEngine;
using UnityEngine.EventSystems;

public class ObeSlot_inSword : Item_Slot
{
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;
    public int SlotNum;
    public Obe_2D myObe;

    public void StartSetting() // SwordIcon_Window�� Start()���� �����
    {
        if (this.transform.childCount > 0) // �ڽ��� �ִٸ�
        {
            // ��ų���Կ� ��ų ����
            myObe = this.transform.GetChild(0).GetComponent<Obe_2D>();
            Obe_Data ObeData = myObe.myData as Obe_Data;

            GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
            obj.transform.SetAsFirstSibling();
            mySkill_Slot.Save_nowSkill();

            // ���������� ������ Equipped_Obes(������ �����)�� ����
            Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = myObe.transform;

            // ��ų ������ '������� ����'�� ����
            mySkill_Slot.isEmpty = false;
        }
    }

    public override void OnDrop_ofChild(PointerEventData eventData) // DragDrop���� ���긦 �޾��� ��
    {
        myObe = eventData.pointerDrag.GetComponent<Obe_2D>();
        Receive_Obe();
    }

    public void ReceiveObe_fromWeapon(Obe_2D Obe2D) // Weapon�� �������� ���긦 �޾��� ��
    {
        myObe = Obe2D;
        Receive_Obe();
    }

    void Receive_Obe()
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        myObe.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        // �������� ������ 0��° �ڽ����� ����
        myObe.transform.SetAsFirstSibling();

        // ��ų���Կ� ��ų ����
        Obe_Data ObeData = myObe.myData as Obe_Data;
        GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
        obj.transform.SetAsFirstSibling();
        mySkill_Slot.Save_nowSkill();

        // ���������� ������ Equipped_Obes(������ �����)�� ����
        Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = myObe.transform;

        // ��ų ������ '������� ����'�� ����
        mySkill_Slot.isEmpty = false;
    }

    public override void isNone_Item() // ���� ��������
    {
        //�ش� ���Կ� ����� ��ų ���� -> ���Ŀ� ������Ʈ Ǯ�� ���� �ʿ�
        mySkill_Slot.isNone_Skill();
        isEmpty = true;
    }

    public void Unequipment_Weapon()
    {
        Destroy(myObe.gameObject);
        myObe = null;
        isNone_Item();
        isEmpty = true;
    }
}
