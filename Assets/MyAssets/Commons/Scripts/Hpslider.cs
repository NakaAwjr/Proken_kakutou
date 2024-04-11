using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hpslider : MonoBehaviour
{

    Slider hpSlider;
    public Status status;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        hpSlider = GetComponent<Slider>();


        //スライダーの最大値の設定
        hpSlider.maxValue = status.maxhp;

        //スライダーの現在値の設定
        hpSlider.value = status.hp;


    }
}

