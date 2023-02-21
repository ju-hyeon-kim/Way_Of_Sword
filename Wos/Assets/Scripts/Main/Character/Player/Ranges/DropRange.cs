using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRange : MonoBehaviour
{
    public List<Item_3D> DropItems = new List<Item_3D>();

    public void Pickup_Item()
    {
        if(DropItems.Count > 0) //드랍된 아이템이 있을때만 실행
        {
            //아이템을 인벤토리에 넣기
            Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(DropItems[0].myItem2D);

            //아이템을 얻었다고 메시지에서 표시
            Dont_Destroy_Data.Inst.Message_Window.Get_Item(DropItems[0].myItem2D);

            //3D모델 삭제 -> 2D 모델은 인벤토리에 생성됨
            DropItems[0].Pickup();

            //리스트에서 삭제
            DropItems.RemoveAt(0);
        }
    }
}
