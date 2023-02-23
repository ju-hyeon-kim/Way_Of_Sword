using UnityEngine;

public class Item_3D : MonoBehaviour
{
    public Item_2D myItem2D;
    public GameObject myName_Label;

    ItemName_Label myLabel;
    DropRange DropZone;
    bool isOnGround = false;

    public void OnDrop(Transform Unactive_Area) // Drop시 공중에 뿌려지는 효과
    {
        // 충격량은 1로 고정 -> 각 아이템의 Mass값을 변경
        GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);

        // 이름 라벨 생성 -> 위치값 전달, 이름 전달(세팅)
        GameObject Obj = Instantiate(myName_Label, Dont_Destroy_Data.Inst.NowPlace_Manager.GetComponent<Manager_Dungeon>().Unactive_Area) as GameObject;
        myLabel = Obj.GetComponent<ItemName_Label>();
        myLabel.myNameZone = this.transform;
        string myName = myItem2D.GetComponent<Item_2D>().myData.Name;
        myLabel.NameSetting(myName);
    }

    private void OnCollisionEnter(Collision target) // 드랍 시 땅에 닿았을 때
    {
        if (target.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other) // 플레이어의 드랍존에 닿았을 때
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
