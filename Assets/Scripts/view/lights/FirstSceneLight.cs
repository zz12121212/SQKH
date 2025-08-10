using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirstSceneLight : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (_time.hourTen * 10 + _time.hour < 6) { globalLight.color = new Color32(50, 50, 50, 255); }
        else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18) { globalLight.color = new Color32(255, 255, 255,255); }
        else if (_time.hourTen * 10 + _time.hour >= 18) { globalLight.color = new Color32(50, 50, 50, 255); }
    }
}
