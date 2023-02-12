using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Property : MonoBehaviour
{
    Animator _anim = null;
    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = GetComponent<Animator>();
            }
            return _anim;
        }
    }

    Rigidbody _rigid = null;
    protected Rigidbody myRigid
    {
        get
        {
            if (_rigid == null)
            {
                _rigid = GetComponent<Rigidbody>();
            }
            return _rigid;
        }
    }

    Collider _coll = null;
    protected Collider myColl
    {
        get
        {
            if (_coll == null)
            {
                _coll = GetComponent<Collider>();
            }
            return _coll;
        }
    }

    Character_Stat _stat = null;
    protected Character_Stat myStat
    {
        get
        {
            if (_stat == null)
            {
                _stat = GetComponent<Character_Stat>();
            }
            return _stat;
        }
    }
}
