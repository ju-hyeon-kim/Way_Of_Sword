using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Story : MonoBehaviour
{
    public GameObject ItemLabel_Window;
    public Material[] Change;
    public Material[] Original;
    public LayerMask PickMask;
    public Sword_Zone Sword_Zone;
    public Player_Story Player;

    public bool PlayerTurn = false;

    private void Start()
    {
        ItemLabel_Window.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(PlayerTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, PickMask))
            {
                transform.GetComponent<MeshRenderer>().materials = Change;
                ItemLabel_Window.gameObject.SetActive(true);
                ItemLabel_Window.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(transform.position);

                if(Input.GetMouseButtonDown(0) && Sword_Zone.InPlayer)
                {
                    gameObject.SetActive(false);
                    ItemLabel_Window.gameObject.SetActive(false);
                    Sword_Zone.gameObject.SetActive(false);
                    Player.Weapon_Back.SetActive(true);
                }
            }
            else
            {
                transform.GetComponent<MeshRenderer>().materials = Original;
                ItemLabel_Window.gameObject.SetActive(false);
            }
        }
    }
}
