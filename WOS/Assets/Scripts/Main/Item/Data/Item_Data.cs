using UnityEngine;

public class Item_Data : ScriptableObject
{
    [Header("-----Item_Data-----")]
    public string Name;
    public int ID;
    public ItemType ItemType;
    public int Price; // �������� ����(1�� ����), Xp�� ����ġ ��ġ, Gold�� �ݾ�
}
