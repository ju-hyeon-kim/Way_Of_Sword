using UnityEngine;

public class NewGame_Window : MonoBehaviour
{
    public void Yes_Button()
    {
        Manager_SceneChange.Inst.ChangeScene("Story1");
    }
}
