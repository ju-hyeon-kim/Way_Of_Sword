public class SwordIcon_Window : Icon_Window
{
    public ObeSlot_inSword[] ObeSlots;

    public void StartSetting()
    {
        for (int i = 0; i < ObeSlots.Length; i++)
        {
            ObeSlots[i].StartSetting();
        }
    }
}
