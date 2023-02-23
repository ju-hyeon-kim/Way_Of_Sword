using UnityEngine;

public class Exit_Button : MonoBehaviour
{
    public GameObject myWindow;
    public void Exit_Window()
    {
        myWindow.SetActive(false);
    }
}
