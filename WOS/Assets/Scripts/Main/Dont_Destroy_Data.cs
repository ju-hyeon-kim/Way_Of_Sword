using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static Dont_Destroy_Data Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
        DontDestroyOnLoad(this);
    }

    public static Dont_Destroy_Data Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    [Header("-----Managers-----")]
    public Manager_Cams Manager_Cams;
    public Manager_Quest Manager_Quest;
    public Manager_Item Manager_Item;
    public Manager_Gold Manager_Gold;

    [Header("-----Windows-----")]
    public Map_Window Map_Window;
    public ItemData_WindowSet ItemData_WindowSet;
    public Inventory_Window Inventory_Window;
    public NpcTalk_Window NpcTalk_Window;
    public Transform Label_Windows;
    public Battle_Window BattleWindow_ofPlayer;
    public Question_Window Question_Window;
    public Notice_Window Notice_Window;

    [Header("-----Etc-----")]
    public Transform Canvas;
    public Transform Player;
    public ItemAcuisition_Message ItemAcuisition_Message;
    public GameObject GoldLack_Message;
    public GameObject NpcName_Label;

    [HideInInspector]
    public Transform NowPlace_Manager; // ���̵��� ���Ŵ����� �˾Ƽ� ������ ��

    public void Start_Setting(Transform PlaceManager)
    {
        NowPlace_Manager = PlaceManager;

        Manager_SaveLode.Inst.JsonReady();
        Manager_SaveLode.Inst.JsonLoad();

        // �� ���� ���۽� �÷��̾��� ��ġ�� ���� <- ����ī�޶� ���󰡰�
        if (PlaceManager.TryGetComponent<Manager_Village>(out Manager_Village component))
        {
            float x = component.SpawnPoints_Player[0].position.x - Player.position.x;
            float z = component.SpawnPoints_Player[0].position.z - Player.position.z;
            Manager_Cams.MainCam_Controller.transform.position += new Vector3(x, 0, z);
            Manager_Cams.MiniMapCam_Controller.transform.position += new Vector3(x, 0, z);

            Player.position = component.SpawnPoints_Player[0].position;
        }
        Manager_Cams.Start_Setting();
        Manager_Quest.Start_Setting(PlaceManager);
    }
}
