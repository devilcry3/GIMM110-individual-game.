using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayerFinished : MonoBehaviour
{
    float timerLength = 24f; //creates float timerlength of 21f (allows me to make a timer roughly 21 seconds
    public GameObject video; // this represents the game object containing the video


    // Update is called once per frame
    void Update()
    {
        timerLength -= Time.deltaTime; //lowers the time based on game run time
        if (timerLength <= 0.0f ) //if timerLength gets to 0
        {
            TimerEnded(); //execute the TimerEnded method
        }
    }
    void TimerEnded() //when method executes
    {
        Destroy(video); // detroy gameobject associated with video variable
    }
}
