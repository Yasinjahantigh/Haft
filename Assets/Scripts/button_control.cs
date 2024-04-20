using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Unity.Burst.CompilerServices;
using System.Threading;

public class button_control : MonoBehaviour
{
    Image im;
    rostam_code ros;
    public GameObject rostam;
    float wait = 100 ;
    float pr = 100;
    // Start is called before the first frame update
    void Start()
    {
        ros = rostam.GetComponent<rostam_code>();
        im = GetComponent<Image>();
        im.fillAmount = 0.2f;
        wait = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) || ros.hit == true && ros.can_hit == true)
        {
            im.fillAmount = 0;
            pr = 0;
        }
        if (pr < wait)
        {
            pr += 1;
            //Thread.Sleep(100);
        }
        im.fillAmount = pr/wait;
        //pr = pr +1;
    }
}
