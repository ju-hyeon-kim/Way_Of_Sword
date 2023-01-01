using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillData_Window : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static SkillData_Window Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static SkillData_Window Inst
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

    public Image Image;
    public TMP_Text Name;
    public TMP_Text Skill_Explanation;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}