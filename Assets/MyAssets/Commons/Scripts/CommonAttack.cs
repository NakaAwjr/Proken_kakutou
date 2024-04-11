using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public abstract class CommonAttack : MonoBehaviour
{
    protected PlayerController _playerController;

    protected virtual void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    public virtual void Attack1()
    {
        Debug.Log("CommonAttack");
    }
    public virtual void Attack2()
    {
        Debug.Log("CommonAttack");
    }
    public virtual void Attack3()
    {
        Debug.Log("CommonAttack");
    }
    public virtual void Attack4()
    {
        Debug.Log("CommonAttack");
    }
    public virtual void Attack5()
    {
        Debug.Log("CommonAttack");
    }
}
