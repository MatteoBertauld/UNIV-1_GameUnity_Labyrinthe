using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temps : MonoBehaviour
{

    float time;
    public float TimerInterval=5f;
    float tick;

    void Awake() {
        time = (int)Time.time;
        tick = TimerInterval;
    }


    void Start()
    {
        GetComponent<Text> ().text = "Timer : " + time.ToString();
    }

    void Update()
    {
        GetComponent<Text> ().text = "Timer : " + time.ToString();
        time = (int)Time.time;

        if(time==tick) 
        {
            tick=time+TimerInterval;
            Debug.Log("test");
        }

    }
}
