﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshPro timeText;
    private float time;
    private float TimeLimit = 300f; //second

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.GetComponent<TextMeshPro>();
        time = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            timeText.text = "시간초과";
            Debug.Log("게임오버 - 타임아웃");
        }
        else
        {
            time -= Time.deltaTime; // 1/현재 프레임 (화면/s)
            if (time < 10)
            {
                timeText.text = "타이머 : " + $"{time:N2}";
            }
            else
            {
                timeText.text = "타이머 : " + Mathf.Floor(time).ToString();
            }

        }
    }
}
