using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWeather : MonoBehaviour
{
    public Image WeatherImg;
    public Sprite[] WeatherImgs;
    private int Day;
    public GameObject rain;
    private void Start()
    {
     WeatherImg.sprite = WeatherImgs[RandomWeatherNum()];
        Day = _time.day;
    }
    void Update()
    {
        if (_time.day != Day) {
            WeatherImg.sprite = WeatherImgs[RandomWeatherNum()];
            Day = _time.day;
        }
    }

    private int RandomWeatherNum(){
      int num =  Random.Range(0, 11);
        if (num <= 8)
        {
            return 0;
        }
        else if (num == 9)
        {
            return 1;
        }
        else {
            rain.SetActive(true);
            rain.GetComponent<ParticleSystem>().Play();
            return 2;
        }
}
}
