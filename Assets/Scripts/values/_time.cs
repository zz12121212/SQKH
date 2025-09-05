using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _time:MonoBehaviour{
    public static _time Instance;
    private float elapsedSeconds = 0f;
    public static int year , counter ,month, day, hour,hourTen, minute,minuteTen;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadTimeData();
    }

    private void Update()
    {
  
            elapsedSeconds += Time.deltaTime;

            if (elapsedSeconds >= 0.5f)
            {
                elapsedSeconds = 0f;
                minute += 1;
            }
            if (minute == 10)
            {
                minuteTen++;
                minute = 0;
                SaveTimeData();
            }
            if (minuteTen == 6)
            {
                hour++;
                minuteTen = 0;
            
            }
            if (hour == 10)
            {
                hour = 0;
                hourTen++;
            }
            if (hourTen == 2 & hour == 4)
            {
                hourTen = 0;
                hour = 0;
                day++;
            }
            if (day == 28)
            {
                day = 1;
                month++;
            }
            if (month == 3)
            {
                month = 1;
                counter++;
            }
            if (counter == 5)
            {
                counter = 0;
                year++;
            }
    }
    
    


    public static void SaveTimeData()
    {
        PlayerPrefs.SetInt("Year", year);
        PlayerPrefs.SetInt("counter", counter);
        PlayerPrefs.SetInt("Month", month);
        PlayerPrefs.SetInt("Day", day);
        PlayerPrefs.SetInt("Hour", hour);
        PlayerPrefs.SetInt("HourTen", hourTen);
        PlayerPrefs.SetInt("Minute", minute);
        PlayerPrefs.SetInt("MinuteTen", minuteTen);
        PlayerPrefs.Save(); 
    }

    public static void LoadTimeData()
    {
        year = PlayerPrefs.GetInt("Year", 1);
       counter =  PlayerPrefs.GetInt("counter", 1);
        month = PlayerPrefs.GetInt("Month", 1); 
        day = PlayerPrefs.GetInt("Day", 1); 
        hour = PlayerPrefs.GetInt("Hour", 0);
        hourTen = PlayerPrefs.GetInt("HourTen", 0);
        minute = PlayerPrefs.GetInt("Minute", 0);
        minuteTen = PlayerPrefs.GetInt("MinuteTen", 0);
    }


}
