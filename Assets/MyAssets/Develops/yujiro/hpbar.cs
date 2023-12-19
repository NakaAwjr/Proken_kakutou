using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpbar : MonoBehaviour

{

    int maxHp = 10;
    int Hp;
    public Slider slider;

    void Start()
    {

        slider.value = 1;
        Hp = maxHp;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (Input.GetKey(KeyCode.D))
        {

            Hp = Hp - 1;

            slider.value = (float)Hp / (float)maxHp; ;

        }
    }
}
