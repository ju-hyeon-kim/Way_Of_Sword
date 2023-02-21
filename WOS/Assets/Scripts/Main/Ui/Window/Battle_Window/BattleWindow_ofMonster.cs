using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindow_ofMonster : Battle_Window
{
    [Header("-----BattleWindow_ofMonster-----")]
    public BossEmergence BossEmergence;
    public HpBar_Boss HpBar_Boss;
    public List<GameObject> HpBar_List;
}
