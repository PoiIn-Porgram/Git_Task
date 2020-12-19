using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class timelimitationaha : MonoBehaviour
{
    public int timeRest = 50;
    public int passedSeconds = 5;

    public bool confirm = false;
    private int tensNum=0, OnesNum=0;
    [Serializable]
    public struct numbers
    {
        public GameObject numPlace;
        public GameObject[] placeArray;
    }
    public numbers[] numArray;
 
    private void Start()
    {
        numArray[0].placeArray = GameObject.FindGameObjectsWithTag("onesPlace");
        numArray[1].placeArray = GameObject.FindGameObjectsWithTag("tensPlace");
        foreach(numbers numbers in numArray)
        {
            foreach(GameObject num in numbers.placeArray)
            {
                num.SetActive(false);
            }
        }
        showTime();
    }

    public void Update()
    {
        if(confirm==true)
        {
 
            timePass(passedSeconds);
            confirm = false;
        }

    }
    public void timePass(int passedSecond)
    {
        StartCoroutine(cutDownTime(passedSecond));
    }

    new IEnumerator cutDownTime(int passedSecond)
    {
        timeRest--;
        showTime();
        passedSecond--;
        if (passedSecond>0)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(cutDownTime(passedSecond));
        }
        yield return null;
    }
    void showTime()
    {
        numArray[0].placeArray[OnesNum].SetActive(false);
        numArray[1].placeArray[tensNum].SetActive(false);
        OnesNum = timeRest % 10;
        tensNum = (timeRest / 10)-1;
        numArray[0].placeArray[OnesNum].SetActive(true);
        numArray[1].placeArray[tensNum].SetActive(true);
    }



}
