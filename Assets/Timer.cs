using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;
    
    // Start is called before the first frame update void Start ()
    void Start()
    {
        currentTime = 0;
    }
    
    // Update is called once per frame void Update()
    void Update()
    {
        if (stopwatchActive == true) {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds (currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }
    public void StartStopwatch() {
        stopwatchActive = true;
    }
    public void StopStopwatch() {
        stopwatchActive = false;
    }

    // start stopwatch when game started
    void OnEnable()
    {
        StartStopwatch();
    }
}
