using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickplayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        // float x = Input.GetAxis("Horizontal"); //矢印キー（←→）で操作する場合
        // float z = Input.GetAxis("Vertical"); //矢印キー（↑↓）で操作する場合
        float x = joystick.Horizontal;
        
 
        transform.position += new Vector3(x*0.1f, 0, 0);
    }
}
