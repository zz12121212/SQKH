using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class setMoney : MonoBehaviour
{
    public static setMoney Instance;
    public static Text money;

    void Start()
    {
        money = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetMoneyUI();
    }

    public static void  SetMoneyUI() {
        
       money.text =":"+ recordPlayer.Money.ToString(); 
    }


}
