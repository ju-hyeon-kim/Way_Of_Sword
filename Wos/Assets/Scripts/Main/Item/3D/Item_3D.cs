using UnityEngine;

public class Item_3D : MonoBehaviour
{
    public Item_2D myItem2D;
    public GameObject myName_Label;

    ItemName_Label myLabel;
    DropRange DropZone;
    bool isOnGround = false;

    public void OnDrop(Transform Unactive_Area) // Drop�� ���߿� �ѷ����� ȿ��
    {
        // ��ݷ��� 1�� ���� -> �� �������� Mass���� ����
        GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);

        // �̸� �� ���� -> ��ġ�� ����, �̸� ����(����)
        GameObject Obj = Instantiate(myName_Label, Dont_Destroy_Data.Inst.NowPlace_Manager.GetComponent<Manager_Dungeon>().Unactive_Area) as GameObject;
        myLabel = Obj.GetComponent<ItemName_Label>();
        myLabel.myNameZone = this.transform;
        string myName = myItem2D.GetComponent<Item_2D>().myData.Name;
        myLabel.NameSetting(myName);
    }

    private void OnCollisionEnter(Collision target) // ��� �� ���� ����� ��
    {
        if (target.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other) // �÷��̾��� ������� ����� ��
    {
        if (isOnGround)
        {
            if (other.gameObject.name == "DropRange")
            {
                myLabel.transform.SetParent(Dont_Destroy_Data.Inst.Label_Windows);
                DropZone = other.GetComponent<DropRange>();
                DropZone.DropItems.Add(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOnGround)
        {
            if (other.gameObject.name == "DropRange")
            {
                myLabel.transform.SetParent(Dont_Destroy_Data.Inst.NowPlace_Manager.GetComponent<Manager_Dungeon>().Unactive_Area);
                DropZone = other.GetComponent<DropRange>();
                DropZone.DropItems.Remove(this);
            }
        }
    }

    public void Pickup()
    {
        Destroy(myLabel.gameObject);
        Destroy(this.gameObject);
    }
}
