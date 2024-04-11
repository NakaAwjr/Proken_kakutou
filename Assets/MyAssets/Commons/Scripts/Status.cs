using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public float maxhp = 100;
    public float hp = 100;

    public void Damage(float damage)
    {
        hp -= damage;
    }
    public float Perhp
    {
        get
        {
            float value = (float)hp / (float)maxhp;
            return Mathf.Clamp(value, 0, 1);
        }
    }
}
