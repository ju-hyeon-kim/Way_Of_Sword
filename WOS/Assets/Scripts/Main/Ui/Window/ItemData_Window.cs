using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Public_Set
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Type;
    public TMP_Text Price;
}

[System.Serializable]
public struct Equipment_Set
{
    public TMP_Text Strengthem;
    public TMP_Text AP;
    public TMP_Text Explanation_Text;
}

[System.Serializable]
public struct Obe_Set
{
    public TMP_Text Strengthem;
    public TMP_Text Obe_Skill;
    public TMP_Text Skill_Name;
    public TMP_Text Skill_Explanation;
}

public class ItemData_Window : MonoBehaviour // �̱���
{
    #region �̱��� ���� + Awake()
    private static ItemData_Window Instence = null;

    private void Awake()
    {
        if(Instence == null)
        {
            Instence = this;
        }
    }

    public static ItemData_Window Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion
    public GameObject[] Type_Sets;

    // ���� Set
    public Public_Set Public_Set;

    // ��� Set
    public Equipment_Set Equipment_Set;

    // ���� Set
    public Obe_Set Obe_Set;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
