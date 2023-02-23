using UnityEngine;

public class GoTitle_Window : MonoBehaviour
{
    public void Yes_Button()
    {
        Manager_SceneChange.Inst.ChangeScene("Title");
    }
}
