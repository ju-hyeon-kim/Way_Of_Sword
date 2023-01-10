using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceeding_Quest : MonoBehaviour
{
    public Transform NowQuest_P; //NowQuest�� �θ�
    public Quest_Data NowQuest;

    public TMP_Text Quest_Name;
    public TMP_Text Quest_Explanation;
    public TMP_Text Quest_Progress;
    public GameObject[] Reward_Slots;

    public Quest_SubWindow Quest_SubWindow;

    private void Awake()
    {
        Quest_Name.text = NowQuest.Name;
        Quest_Explanation.text = NowQuest.Explanation;

        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < NowQuest.Reward.Count; i++)
        {
            Reward_Slots[i].transform.GetChild(i).GetComponent<Image>().sprite = NowQuest.Reward[i].Image;
        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = NowQuest.Reward.Count; i < Reward_Slots.Length; i++)
        {
            Reward_Slots[i].SetActive(false);
        }
        // ���� ������� ����
        Conect_SubWindow();

        Instantiate(NowQuest, NowQuest_P);
    }

    void Conect_SubWindow()
    {
        Quest_SubWindow.Name.text = NowQuest.Name;
        Quest_SubWindow.Explanation.text = NowQuest.Explanation;
        Quest_SubWindow.Progress.text = Quest_Progress.text;
    }
}
