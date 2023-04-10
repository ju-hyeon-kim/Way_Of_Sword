using TMPro;
using UnityEngine;

public class Quest_Request : MonoBehaviour
{
    public TMP_Text Q_Name;
    public TMP_Text Q_Explanation;
    public GameObject[] Q_Reword;
    public Manager_Quest Manager_Quest;
    public NpcTalk_Window NpcTalk_Window;

    Quest_Data myQD;

    public void Accept_Button() // 수락 버튼
    {
        //Sfx
        ClickSound();

        Manager_Quest.Change_Quest();
        NpcTalk_Window.Lock_or_Unlock_Button(1, true); //퀘스트 신청 버튼 Lock 적용
        gameObject.SetActive(false);
    }

    public void Recept_Button() // 거절 버튼
    {
        //Sfx
        ClickSound();

        gameObject.SetActive(false);
    }

    void ClickSound()
    {
        Manager_Sound.Inst.SfxSource.OnPlay(0);
    }

    public void Input_QuestData(Quest_Data QD) // 퀘스트 데이터 입력
    {
        myQD = QD;

        Q_Name.text = myQD.Name;
        Q_Explanation.text = myQD.Explanation;

        // 퀘스트 데이터의 보상을 보상슬롯에 전달
        for (int i = 0; i < myQD.Reward.Length; i++)
        {
            GameObject obj = Instantiate(myQD.Reward[i], Q_Reword[i].transform) as GameObject;
            obj.transform.SetAsFirstSibling();

        }
        // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
        for (int i = myQD.Reward.Length; i < Q_Reword.Length; i++)
        {
            Q_Reword[i].SetActive(false);
        }
    }
}
