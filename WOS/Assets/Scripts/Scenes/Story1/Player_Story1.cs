using System.Collections;
using UnityEngine;

public class Player_Story1 : MonoBehaviour
{
    public Transform cube;

    public TalkWindow_S1 TalkWindow;
    public GameObject WakeUp_Icon;
    public GameObject Weapon_Back;
    
    public bool PlayerTurn_rotdoor = false;
    public LayerMask pickMask = default;
    public Transform Door_Zone;

    bool PlayerTurn = false;
    bool isTalk = true;

    Coroutine moveCo = null;
    Coroutine rotCo = null;

    // Start is called before the first frame update
    void Start()
    {
        Weapon_Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTurn)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, pickMask))
                {
                    cube.transform.position = hit.point;
                    if (moveCo != null)
                    {
                        StopCoroutine(moveCo);
                        moveCo = null;
                    }
                    moveCo = StartCoroutine(Moving(hit.point));
                    if (rotCo != null)
                    {
                        StopCoroutine(rotCo);
                        rotCo = null;
                    }
                    rotCo = StartCoroutine(Rotating(hit.point));
                }
            }
        }

        if (PlayerTurn_rotdoor)
        {
            PlayerTurn_rotdoor = false;
            PlayerTurn = false;
            StartCoroutine(Rotating(Door_Zone.position));
        }
    }
    
    public void Sleep()
    {
        GetComponent<Animator>().SetTrigger("Sleep");
    }

    public void StopMove()
    {
        StopAllCoroutines();
        GetComponent<Animator>().SetBool("Walk", false);
    }

    public void DownPos()
    {
        Vector3 pos = transform.position + (-transform.up * 0.15f);
        StartCoroutine(Moving(pos, 1.0f, false));
    }

    #region AnimEvent
    public void WakeUpIcon_On()
    {
        WakeUp_Icon.SetActive(true);
    }

    public void WakeUp()
    {
        WakeUp_Icon.SetActive(false);
        Vector3 wakeup_pos = transform.position + (transform.right * 0.5f);
        StartCoroutine(Moving(wakeup_pos, 0.5f, false));
        StartCoroutine(Rotating(wakeup_pos, 50.0f));
    }

    public void Talk()
    {
        if(isTalk)
        {
            TalkWindow.gameObject.SetActive(true);
            TalkWindow.StartTalking();
            isTalk = false;
        }
    }

    public void PlayerTurn_SetTrue()
    {
        PlayerTurn = true;
    }
    #endregion

    #region 이동/회전 코루틴
    IEnumerator Moving(Vector3 pos, float movespeed = 1.0f, bool iswalk = true)
    {
        pos.y = transform.position.y;
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        if(iswalk) GetComponent<Animator>().SetBool("Walk", true);

        while (dist > 0.0f)
        {

            float delta = movespeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        if(iswalk) GetComponent<Animator>().SetBool("Walk", false);
    }

    IEnumerator Rotating(Vector3 pos, float rotspeed = 360.0f)
    {
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }

        while (Angle > 0.0f)
        {
            float delta = rotspeed * Time.deltaTime;
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);
            yield return null;
        }
    }
    #endregion
}
