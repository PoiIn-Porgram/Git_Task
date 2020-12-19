using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fuck: MonoBehaviour
{
    public int timeRest = 30;
    public int timePassed = 0;
    public bool start = false;
    public void Update()
    {
        if (start == true)
        {
            timePass(timePassed);
            start = false;
        }
    }
    public void timePass(int timePassed)
    {
        cutDownTime(timePassed);
    }
    public void cutDownTime(int timePassed)
    {
        timePassed--;
        timeRest--;
        if (timePassed > 0)
        {
            new WaitForSeconds(1);
            cutDownTime(timePassed);
        }
    }
}
