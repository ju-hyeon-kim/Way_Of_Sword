using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Play_Starter : MonoBehaviour
{
    static Play_Starter Instense = null;

    public static Play_Starter Inst
    {
        get
        {
            if (Instense == null) // 처음에
            {
                Instense = FindObjectOfType<Play_Starter>(); // 동일한 스크립트를 가진 오브젝트 탐색
                if (Instense == null) // 동일한 스크립트를 가진 오브젝트가 없다
                {
                    GameObject PS = new GameObject(); // 오브젝트를 씬에 생성
                    PS.name = "Play_Starter";
                    Instense = PS.AddComponent<Play_Starter>(); // 해당 오브젝트에 현재 스크립트를 바인딩 해주고 나의 인스턴스가 됨

                    //DDD 생성
                    GameObject DDD = Instantiate(Resources.Load("Dont_Destroy_Data")) as GameObject;
                    DDD.name = "Dont_Destroy_Data";

                    //해당 스크립트가 바인딩된 오브젝트의 부모를 DDD로 설정
                    PS.transform.parent = DDD.transform;
                }
            }
            return Instense; // 인스턴스 반환
        }
    }

    public void Start_Call(Transform PlaceManager)
    {
        transform.parent.GetComponent<Dont_Destroy_Data>().Start_Setting(PlaceManager);
    }
}
