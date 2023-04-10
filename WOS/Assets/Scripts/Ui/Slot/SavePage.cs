using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SavePage : MonoBehaviour
{
    public GameObject SaveisExists;
    public GameObject SaveisNone;
    public TMP_Text Time;
    public TMP_Text Level;
    public TMP_Text Place;
    public TMP_Text NowQuest;

    public int pagenum;

    private void Start()
    {
        if(Manager_SaveLode.Inst.isSaveFile_Exists(pagenum))  //�ش� �������� ��ϵ� ���̺������� �ִٸ� -> ��ϵ� ������ UI�� �����ֱ�
        {
            SaveData savedata = Manager_SaveLode.Inst.Get_SaveData(pagenum);
            Time.text = savedata.Time;
            Level.text = savedata.Level.ToString();
            Place.text = SearchPlace(savedata.Place);
            NowQuest.text = savedata.QuestName;
        }
    }

    public void OnSave()
    {
        WritePage();
        SaveisExists.SetActive(true);
        SaveisNone.SetActive(false);
    }

    void WritePage()
    {
        Time.text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        Level.text = Dont_Destroy_Data.Inst.Player.GetComponent<Player_Stat>().Level.ToString();
        Place.text = SearchPlace(SceneManager.GetActiveScene().name);
        NowQuest.text = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Name;
    }

    string SearchPlace(string place)
    {
        switch (place)
        {
            case "Village":
                place = "����";
                break;
            case "Guild":
                place = "���谡 ���";
                break;
            case "Forest":
                place = "������ ��";
                break;
        }
        return place;
    }
}
