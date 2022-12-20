using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

public class Player_Tuto : MonoBehaviour
{
    public GameObject Skill_Range;
    public GameObject Skill_Point;
    public GameObject Dummy;
    public GameObject Weapon_Hand;
    public GameObject Skill_A;
    public bool PlayerTurn = false;
    public UnityEvent Attack = default;
    public LayerMask Mask_Ground = default;
    public LayerMask Mask_Character = default;
    public LayerMask Mask_SkillRange = default;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;
    public float AttackRange = 2f;
    bool isCombable = false;
    public bool ComboAttack_Success = false;
    int ClickCount = 0;

    Coroutine moveCo = null;
    Coroutine rotCo = null;
    Coroutine skillCo = null;

    private void Start()
    {
        Skill_Range.SetActive(false);
        Skill_Point.SetActive(false);
    }

    void Update()
    {
        //무빙
        if (PlayerTurn)
        {
            if (Input.GetMouseButtonDown(1)) // 현재 스킬 애니메이션이 작동중이라면 동작되면 안됨
            {
                if(Skill_Range.activeSelf == true)
                {
                    Skill_Range.SetActive(false);
                    Skill_Point.SetActive(false);
                    StopCoroutine(skillCo);
                    skillCo = null;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_Ground))
                {
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
            else if (Input.GetMouseButtonDown(0) && !GetComponent<Animator>().GetBool("isC_Attacking"))
            {
                if(skillCo == null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_Character))
                    {
                        if (moveCo != null)
                        {
                            StopCoroutine(moveCo);
                            moveCo = null;
                        }
                        moveCo = StartCoroutine(Attaking(hit.point));
                        if (rotCo != null)
                        {
                            StopCoroutine(rotCo);
                            rotCo = null;
                        }
                        rotCo = StartCoroutine(Rotating(hit.point));
                    }
                }
            }
            //스킬
            else if(Input.GetKeyDown(KeyCode.Q))
            {
                Skill_Range.SetActive(true);
                skillCo = StartCoroutine(Skilling());
                
            }

            if(isCombable)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    ++ClickCount;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_Character))
                    {
                        if (rotCo != null)
                        {
                            StopCoroutine(rotCo);
                            rotCo = null;
                        }
                        rotCo = StartCoroutine(Rotating(hit.point));
                    }
                }
            }
        }
    }

    IEnumerator Rotating(Vector3 pos)
    {
        pos.y = transform.position.y;
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }

        while (Angle > 0.0f)
        {
            float delta = RotSpeed * Time.deltaTime;
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);

            yield return null;
        }
    }

    IEnumerator Moving(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        GetComponent<Animator>().SetBool("Run", true);

        while (dist > 0.0f)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Run", false);
    }

    IEnumerator Attaking(Vector3 pos)
    {
        pos.y = transform.position.y;
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        GetComponent<Animator>().SetBool("Run", true);

        while (dist > AttackRange)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Run", false);
        GetComponent<Animator>().SetTrigger("ComboAttack");
    }

    public void ComboCheck(bool b)
    {
        if(b) // ComboCheckStart
        {
            isCombable = true;
            ClickCount = 0;
        }
        else // ComboCheckEnd
        {
            isCombable = false;
            if(ClickCount == 0)
            {
                GetComponent<Animator>().SetTrigger("ComboFail");
            }
        }
    }

    public void ComboCheckStart()
    {
        ComboCheck(true);
    }

    public void ComboCheckEnd() 
    {
        ComboCheck(false);
    }

    public void Hit_Target()
    {
        Collider[] list = Physics.OverlapSphere(Weapon_Hand.transform.position, 0.7f, Mask_Character);

        foreach(Collider col in list)
        {
            col.GetComponent<Dummy>()?.OnDamage();
        }
    }

    public void OnAttack()
    {
        Attack?.Invoke();
    }

    public void ComboAttackSuccess()
    {
        if(ComboAttack_Success == false)
        {
            ComboAttack_Success = true;
        }
    }

    IEnumerator Skilling()
    {
        while(true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_SkillRange))
            {
                if(Skill_Point.activeSelf == false)
                {
                    Skill_Point.SetActive(true);
                }
                Skill_Point.transform.position = hit.point;
                if (Input.GetMouseButtonDown(0))
                {
                    //클릭지점으로 회전
                    if (rotCo != null)
                    {
                        StopCoroutine(rotCo);
                        rotCo = null;
                    }
                    rotCo = StartCoroutine(Rotating(hit.point));
                    //이동중이라면 이동중지
                    if (moveCo != null)
                    {
                        StopCoroutine(moveCo);
                        moveCo = null;
                    }
                    //클릭지점이 몸에 가려져있으면 돌지 않는다.
                    GetComponent<Animator>().SetTrigger("Skill");
                    Skill_Point.SetActive(false);
                    Skill_Range.SetActive(false);
                    StopCoroutine(skillCo);
                    skillCo = null;
                }
            }
            else
            {
                Skill_Point.SetActive(false);
            }
                yield return null;
        }
    }
}
