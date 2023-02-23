using UnityEngine;

public class Mp_Interface : Xp_Interface
{
    [Header("-----Mp_Interface-----")]
    public Mp_Set Mp_Set;

    protected void UseMp(float skillmp)
    {
        Mp_Set.UseMp(skillmp);
    }
}
