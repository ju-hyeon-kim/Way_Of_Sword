using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_3D : MonoBehaviour
{
    public GameObject myItem2D;
    public GameObject myName_Label;

    ItemName_Label myLabel;

    public void OnDrop()
    {
        // Drop�� ���߿� �ѷ����� ȿ��
        // ��ݷ��� 1�� ���� -> �� �������� Mass���� ����
        GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);

        // �̸� �� ���� -> ��ġ�� ����, �̸� ����(����)
        GameObject Obj = Instantiate(myName_Label, Dont_Destroy_Data.Inst.Rabel_Windows) as GameObject;
        myLabel = Obj.GetComponent<ItemName_Label>();
        myLabel.myNameZone = this.transform;
        string myName = myItem2D.GetComponent<Item_2D>().myData.Name;
        myLabel.NameSetting(myName);
    }

    private void OnCollisionEnter(Collision target) // ��� �� ���� ����� ��
    {
        if (target.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other) // �÷��̾��� ������� ����� ��
    {
        if(other.gameObject.name == "DropZone")
        {
            myLabel.gameObject.SetActive(true);
            //myLabel.Drop_Possible();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DropZone")
        {
            myLabel.gameObject.SetActive(false);
            //myLabel.Drop_Impossible();
        }
    }
}
