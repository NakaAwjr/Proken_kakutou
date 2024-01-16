using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public float maxhp = 100;
    public float hp = 10;

    public void Damage(float damage)
    {
        hp -= damage;
    }
}
