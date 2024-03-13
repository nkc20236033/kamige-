using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntervalTimer : MonoBehaviour
{
    public bool LoopActive;
    [SerializeField] float interval = 1;
    [SerializeField] UnityEvent doSomething;

    float interval_cnt = 0;

    private void Start()
    {
        interval_cnt = interval;
    }

    void FixedUpdate()
    {
        if (LoopActive)
        {
            if (interval_cnt <= 0)
            {
                doSomething?.Invoke();
                interval_cnt = interval;
            }
            if (interval_cnt > 0) interval_cnt -= Time.deltaTime;
        }
    }
}