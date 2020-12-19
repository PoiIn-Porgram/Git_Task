using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public int passedTime = 5;
    public bool comfirm = false;
    public GameObject canvas;
    
    void Update()
    {
        if (comfirm == true)
        {
            comfirm = false;
            canvas.GetComponent<timeLimitation>().timePass(passedTime);
        }
    }
}
