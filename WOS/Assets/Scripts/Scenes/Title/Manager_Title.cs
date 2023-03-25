using UnityEngine;

public class Manager_Title : MonoBehaviour
{
    public GameObject NewGame_Window;
    public GameObject Load_Window;

    public void NewGame_Button()
    {
        NewGame_Window.SetActive(true);
    }

    public void Load_Button()
    {
        Load_Window.SetActive(true);
    }
}
