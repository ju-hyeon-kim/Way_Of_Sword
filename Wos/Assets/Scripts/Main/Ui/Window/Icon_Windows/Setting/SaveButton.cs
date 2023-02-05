using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public SaveLode_Window SaveLode_Window;

    public void OnSave()
    {
        Manager_SaveLode.Inst.JsonSave();
        int SlotNum = SaveLode_Window.Now_PageNum;
        SaveLode_Window.SaveSlots[SlotNum-1].GetComponent<SaveSlot>().OnSave();
    }
}
