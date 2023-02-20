using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Data : MonoBehaviour
{
    public bool Quest_isStart = false; // true�� �ٲ�� ����: ü���� ����Ʈ �Լ� �ߵ� �� & �Ϸ� �������� ��
    public int Quest_Number;
    public string Name;
    [Multiline]
    public string Explanation;
    public GameObject[] Reward;

    public virtual void Start_Questing(){}

    public virtual bool isCounting() // ī��Ʈ�� ���� ����Ʈ�� ���� �ʴ� ����Ʈ ����
    {
        return true; // �ڽĿ��� ������
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
