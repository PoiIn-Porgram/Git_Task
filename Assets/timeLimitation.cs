using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class timeLimitation : MonoBehaviour
{
    public int timeRest = 30;
    private int onesPlace, tensPlace;

    [Serializable]
    public struct placeHolder
    {
        public GameObject numPlace;
        public GameObject[] placeArray;
    }
    public placeHolder[] PlaceHoldersArray;

    public void Start()
    {
        PlaceHoldersArray[0].placeArray = GameObject.FindGameObjectsWithTag("numPlace");
        PlaceHoldersArray[1].placeArray = GameObject.FindGameObjectsWithTag("numPlace2");
        foreach (placeHolder PlaceHolder in PlaceHoldersArray)
        {
            for (int i = 0; i < 10; i++)
            {
                PlaceHolder.placeArray[i].SetActive(false);
            }
        }
        onesPlace = timeRest % 10;
        tensPlace = timeRest / 10;
        timeShow();
    }
    public void timePass(int passedSecond)
    {

        StartCoroutine(cutDownTime(passedSecond));

    }
    private IEnumerator cutDownTime(int passedSecond)
    {
        timeRest--;
        timeShow();
        passedSecond--;
        if (passedSecond > 0)
        {
            yield return new WaitForSeconds(1);
            timePass(passedSecond);
        }
        yield return null;
    }
    private void timeShow()
    {
        PlaceHoldersArray[0].placeArray[onesPlace].SetActive(false);
        PlaceHoldersArray[1].placeArray[tensPlace].SetActive(false);
        onesPlace = timeRest % 10;
        tensPlace = timeRest / 10;
        PlaceHoldersArray[0].placeArray[onesPlace].SetActive(true);
        PlaceHoldersArray[1].placeArray[tensPlace].SetActive(true);
    }

}


