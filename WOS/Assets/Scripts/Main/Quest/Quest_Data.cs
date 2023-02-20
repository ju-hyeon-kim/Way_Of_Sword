using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Data : MonoBehaviour
{
    public bool Quest_isStart = false; // true로 바뀌는 시점: 체인지 퀘스트 함수 발동 시 & 완료 보고했을 때
    public int Quest_Number;
    public string Name;
    [Multiline]
    public string Explanation;
    public GameObject[] Reward;

    public virtual void Start_Questing(){}

    public virtual bool isCounting() // 카운트를 세는 퀘스트와 세지 않는 퀘스트 구분
    {
        return true; // 자식에서 재정의
    }

    public virtual int Now_Count()
    {
        return 0;
    }

    public virtual int Max_Count()
    {
        return 0;
    }

    public virtual void Add_Count(){}

    
}
