using UnityEngine;

[CreateAssetMenu(fileName = "Item_Data", menuName = "ScriptableObjects/Item_Data", order = 1)]
public class Item_Data : ScriptableObject
{
    public string Name;
    public int ID;
    public ItemType ItemType;
    public int Price; // �������� ����(1�� ����), Xp�� ����ġ ��ġ, Gold�� �ݾ�
}
