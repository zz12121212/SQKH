using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Date_Weather : MonoBehaviour
{
    public  int year =1;
    private int counter = 0;
    private int month =1 , day =1, hourTen =0, hour =0 ,minuteTen ,minute;
    private string[] season;
    private float elapsedSeconds = 0f;

    public Text TheTime;
    public Text TheSeason;
    // Start is called before the first frame update
    private void Start()
    {
        season = new string[] {"春" ,"夏", "秋","冬" };
        year = _time.year;
        counter = _time.counter;
        month = _time.month;
        day = _time.day;
        hour = _time.hour;
        hourTen = _time.hourTen;
        minute = _time.minute;
        minuteTen = _time.minuteTen;
    }

    private void Update()
    {
        TheTime.text ="时间：" +_time.hourTen + _time.hour + ":" + _time.minuteTen +_time.minute;
        TheSeason.text = season[_time.counter]+"第" + _time.month +"月 第" + _time.day+ "日";
    }


    
    }

