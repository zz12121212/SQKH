using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class setMoney : MonoBehaviour
{
    public  PlayerRecord record;
    public  Text money;

    void Start()
    {
        money = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        SetMoneyUI();
    }

    public void  SetMoneyUI() {
        
       money.text =":"+ record.Money.ToString(); 
    }


}
