using UnityEngine;

public class Icon_Button : MonoBehaviour
{
    public GameObject myWindow;

    public void Window_OnOff()
    {
        //���� ������ �ڽ����� �̵�
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
