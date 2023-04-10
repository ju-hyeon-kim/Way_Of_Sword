using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sfx : Player_Battle
{
    [Header("-----Player_Sfx-----")]
    public FootStep FootStep;
    public PlayerVoice PlayerVoice;

    public void FootStepL() //AnimEvent
    {
        FootStep.SoundFootStepL();
    }

    public void FootStepR() //AnimEvent
    {
        FootStep.SoundFootStepR();
    }

    public void AttackVoice()
    {
        PlayerVoice.PlaySound(0);
    }

    public void DamageVoice()
    {
        PlayerVoice.PlaySound(1);
    }

    public void DieVoice()
    {
        PlayerVoice.PlaySound(2);
    }
}
