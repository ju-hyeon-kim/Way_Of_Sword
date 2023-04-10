using UnityEngine;

public class Exit_Button : MonoBehaviour
{
    public GameObject myWindow;
    public void Exit_Window()
    {
        Manager_Sound.Inst.SfxSource.OnPlay(0);
        myWindow.SetActive(false);
    }
}
