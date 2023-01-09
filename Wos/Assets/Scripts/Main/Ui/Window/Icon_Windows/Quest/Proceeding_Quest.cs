using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceeding_Quest : MonoBehaviour
{
    public Quest_Data Quest_Data;
    public TMP_Text Quest_Name;
    public TMP_Text Quest_Content;
    public GameObject[] Reward_Slots;

    private void Start()
    {
        Quest_Name.text = Quest_Data.Name;
        Quest_Content.text = Quest_Data.Content;

        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < Quest_Data.Reward.Count; i++)
        {
            Reward_Slots[i].transform.GetChild(i).GetComponent<Image>().sprite = Quest_Data.Reward[i].Image;
        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = Quest_Data.Reward.Count; i < Reward_Slots.Length; i++)
        {
            Reward_Slots[i].SetActive(false);
        }
       
    }
}
