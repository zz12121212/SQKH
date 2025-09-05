using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiredStoreRead : MonoBehaviour
{
    public bag PlayerBag;
    public GameObject grid;
    public Slider slider;
    public float currentValue;
    public Text Max;
    public Text Now;
    public Text Money;
    public int MoneyMulti = 0;
    public Sprite nullimg;
    private void OnEnable()
    { currentValue = slider.value;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        SetButtons();
    }

    public void SetButtons() {
        for (int i = 0; i < PlayerBag.itemList.Count; i++)
        {
            grid.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = nullimg;
        }
       
        for (int i = 0; i < PlayerBag.itemList.Count; i++)
        {
            if (PlayerBag.itemList[i] == null) { continue; }
            grid.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = PlayerBag.itemList[i]._image;
            grid.transform.GetChild(i).GetComponent<ThireStoreButton>().item = PlayerBag.itemList[i];
            grid.transform.GetChild(i).GetComponent<ThireStoreButton>().storeRead = this;
        }
    }

    public void OnSliderValueChanged(float newValue) 
    {
        currentValue = newValue;
        Money.text = (currentValue * MoneyMulti).ToString();
    }

    public void SetSlider(int max,int moneyMulti) {
        Max.text = max.ToString();
        slider.maxValue = max;
        MoneyMulti = moneyMulti;
    }
}
