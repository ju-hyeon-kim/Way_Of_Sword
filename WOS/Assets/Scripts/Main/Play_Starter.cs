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
            if (Instense == null) // ó����
            {
                Instense = FindObjectOfType<Play_Starter>(); // ������ ��ũ��Ʈ�� ���� ������Ʈ Ž��
                if (Instense == null) // ������ ��ũ��Ʈ�� ���� ������Ʈ�� ����
                {
                    GameObject PS = new GameObject(); // ������Ʈ�� ���� ����
                    PS.name = "Play_Starter";
                    Instense = PS.AddComponent<Play_Starter>(); // �ش� ������Ʈ�� ���� ��ũ��Ʈ�� ���ε� ���ְ� ���� �ν��Ͻ��� ��

                    //DDD ����
                    GameObject DDD = Instantiate(Resources.Load("Dont_Destroy_Data")) as GameObject;
                    DDD.name = "Dont_Destroy_Data";

                    //�ش� ��ũ��Ʈ�� ���ε��� ������Ʈ�� �θ� DDD�� ����
                    PS.transform.parent = DDD.transform;
                }
            }
            return Instense; // �ν��Ͻ� ��ȯ
        }
    }

    public void Start_Call(Transform PlaceManager)
    {
        transform.parent.GetComponent<Dont_Destroy_Data>().Start_Setting(PlaceManager);
    }
}
