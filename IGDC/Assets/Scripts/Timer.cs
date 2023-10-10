using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float totTime = 300; 
    [SerializeField] Image timerImage;
    float timer;
    public static bool hasTimerDrained;
    // Start is called before the first frame update
    void Start()
    {
        hasTimerDrained = false;
        timer = totTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        if(timer <= 0)
        {
            hasTimerDrained = true;
        }
    }

    public void CountDown()
    {
        timer-=Time.deltaTime;
        timer = Mathf.Clamp(timer,0,totTime);
        timerImage.fillAmount = timer/totTime;
    }
}
