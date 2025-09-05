using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Date_Weather : MonoBehaviour
{
    private string[] season;
    private float elapsedSeconds = 0f;

    public Text TheTime;
    public Text TheSeason;
    public Image seasonImg;
    public Image DayImg;

    public Sprite[] seasons;
    public Sprite[] DayTimesImg;
    private bool[] seasonsBool = new bool[4];
    private bool[] dayTimeBool = new bool[3];

    // Start is called before the first frame update
    private void Start()
    {
        season = new string[] {"春" ,"夏", "秋","冬" };

    }

    private void Update()
    {
        TheTime.text = "时间：" + _time.hourTen + _time.hour + ":" + _time.minuteTen + _time.minute;
        TheSeason.text = season[_time.counter-1]+"第" + _time.month +"月 第" + _time.day+ "日";

        for (int i = 0; i < 4; i++)
        {
            if (_time.counter == i + 1 && seasonsBool[i] == false)
            {
                seasonImg.sprite = seasons[i];
                SetOneBoolTrue(seasonsBool, i);
            }

            if (_time.hourTen * 10 + _time.hour < 6 && dayTimeBool[0] == false)
            {
                DayImg.sprite = DayTimesImg[0];
                SetOneBoolTrue(dayTimeBool, 0);
            }
            else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18 && dayTimeBool[1] == false)
            {
                DayImg.sprite = DayTimesImg[1];
                SetOneBoolTrue(dayTimeBool, 1);
            }
            else if (_time.hourTen * 10 + _time.hour >= 18 && dayTimeBool[2] == false)
            {
                DayImg.sprite = DayTimesImg[2];
                SetOneBoolTrue(dayTimeBool, 2);
            }
        }

    }

    private void SetOneBoolTrue( bool[] bools ,int TrueIndex) {
        for (int i = 0; i < bools.Length; i++) {
            if (i == TrueIndex) { bools[i] = true; }
            else { bools[i] = false; }
        }
    }
    
    }

