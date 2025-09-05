using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartTime : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerPrefs.SetInt("Year", 1);
        PlayerPrefs.SetInt("counter", 1);
        PlayerPrefs.SetInt("Month", 1);
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.SetInt("Hour", 0);
        PlayerPrefs.SetInt("HourTen", 0);
        PlayerPrefs.SetInt("Minute", 0);
        PlayerPrefs.SetInt("MinuteTen", 0);
        PlayerPrefs.Save();
    }
}
