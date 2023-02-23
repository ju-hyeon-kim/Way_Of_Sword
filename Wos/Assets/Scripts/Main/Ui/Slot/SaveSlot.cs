using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    public GameObject NoneSave;
    public SaveReport SaveReport;

    public void OnSave()
    {
        NoneSave.SetActive(false);
        SaveReport.OnSave();
        SaveReport.gameObject.SetActive(true);
    }
}
