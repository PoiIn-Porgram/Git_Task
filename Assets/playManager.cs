using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playManager : MonoBehaviour
{
    public bool confirm = false;
    public GameObject canvas;
    private timeLimitation Canvas;
    public int passedSeconds = 5;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = canvas.GetComponent<timeLimitation>();
    }

    public void Update()
    {
        if (confirm == true)
        {
            Canvas.timePass(passedSeconds);
            confirm = false;
        }

    }
}
