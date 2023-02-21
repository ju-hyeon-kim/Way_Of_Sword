using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Dungeon : Manager_Place
{
    [Header("-----Manager_Dungeon-----")]
    public Battle_Window BattleWindow_ofMonster;
    public BossEmergence BossEmergence;
    public Animator BossZone_Door;
    public Animator Boss_AppearEvent;
    public Transform Unactive_Area;
}
