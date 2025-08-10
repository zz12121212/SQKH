using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirstStoreLight : MonoBehaviour
{

    public GameObject lights;
    public GameObject globalLight;



    // Update is called once per frame
    void Update()
    {
        if (_time.hourTen * 10 + _time.hour <= 6) { 
            globalLight.GetComponent<Light2D>().color = new Color32(48, 41, 41, 255);
            for (int i = 0; i < lights.transform.childCount; i++) {
                lights.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (_time.hourTen * 10 + _time.hour > 6 && _time.hourTen * 10 + _time.hour <= 18) {
            globalLight.GetComponent<Light2D>().color = new Color(1, 1, 1, 1);
            for (int i = 0; i < lights.transform.childCount; i++)
            {
                lights.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            globalLight.GetComponent<Light2D>().color = new Color32(48, 41, 41, 255);
            for (int i = 0; i < lights.transform.childCount; i++)
            {
                lights.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
