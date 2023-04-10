using UnityEngine;

public class Icon_Button : MonoBehaviour
{
    public GameObject myWindow;

    public void Window_OnOff()
    {
        //가장 마지막 자식으로 이동
        myWindow.transform.SetAsLastSibling();

        if (myWindow.activeSelf)
        {
            myWindow.SetActive(false);
        }
        else
        {
            myWindow.SetActive(true);
        }
    }
}
