using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CountTime : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timeCounter;

    public float timeCount = 0f;

    [SerializeField] private DamageRocket dm;

    void Update()
    {
        if (dm.countTime == true)
        {
            timeCount = timeCount + Time.deltaTime;

            TimeSpan time = TimeSpan.FromSeconds(timeCount);

            timeCounter.text = "Time Spent: " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();

        }

    }






}
