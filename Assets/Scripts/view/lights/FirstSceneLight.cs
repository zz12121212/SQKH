using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class FirstSceneLight : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    private bool morning, noon, night;

    void Update()
    {
        if (_time.hourTen * 10 + _time.hour < 6 && morning == false) 
        {
            globalLight.color = new Color32(50, 50, 50, 255);
            morning = true;
            noon = false;
            night = false;
        }
        else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18 && noon == false)
        { 
            globalLight.color = new Color32(255, 255, 255,255);
            morning = false;
            noon = true;
            night = false;

        }
        else if (_time.hourTen * 10 + _time.hour >= 18 && night ==false) { 
            globalLight.color = new Color32(50, 50, 50, 255);
            morning = false;
            noon = false;
            night = true;

        }
    }
}
