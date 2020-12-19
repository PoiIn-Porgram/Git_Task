using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeLimitation : MonoBehaviour
{
    public int timeRest = 30;
    public int timePassed = 4;
    public bool begin = false;
    public int tenplace;
    public int oneplace;

    [Serializable]
    public struct num
    {
        public GameObject numPlace;
        public GameObject[] numPicture;
    }

    public num[] numshow;

    void Start()
    {
        tenplace = timeRest / 10;
        oneplace = timeRest % 10;
        numshow[0].numPicture = GameObject.FindGameObjectsWithTag("tenplace");
        numshow[1].numPicture = GameObject.FindGameObjectsWithTag("oneplace");
        foreach (num num in numshow)
        {
            foreach (GameObject numbers in num.numPicture)
            {
                numbers.SetActive(false);
            }
        }
        timeShow();
    }

    public void timeShow()
    {
        numshow[0].numPicture[tenplace].SetActive(false);
        numshow[1].numPicture[oneplace].SetActive(false);
        tenplace = timeRest / 10;
        oneplace = timeRest % 10;
        numshow[0].numPicture[tenplace].SetActive(true);
        numshow[1].numPicture[oneplace].SetActive(true);
    }

    new IEnumerator cutDownTime(int timePassed)
    {
        timePassed--;
        timeRest--;
        timeShow();
        if (timePassed > 0)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(cutDownTime(timePassed));
        }

        yield return null;
    }

    void timePass(int timePassed)
    {
        StartCoroutine(cutDownTime(timePassed));
    }

    // Update is called once per frame
    void Update()
    {
        if (begin == true)
        {
            timePass(timePassed);
            begin = false;
        }
    }
}