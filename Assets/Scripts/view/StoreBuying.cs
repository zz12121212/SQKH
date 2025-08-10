using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuying : MonoBehaviour
{
    [SerializeField] private Items StorePrefabs;
    [SerializeField] private int Money;
    [SerializeField] private Text mOney;
    [SerializeField] private Text name;

    // Start is called before the first frame update

    private void Awake()
    {
        mOney.text = Money.ToString()+"yuan";
        name.text = StorePrefabs._name;
}


    public void ClickToBuy() {
        if (recordPlayer.Money - Money >= 0) {
            recordPlayer.ChangeMoney(-Money);
            setMoney.SetMoneyUI();  
            StorePrefabs._num += 1;
        }
        else {
            Debug.Log("NoMoney");
        }


      
    }
}
