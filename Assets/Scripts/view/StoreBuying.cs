using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBuying : MonoBehaviour
{
    [SerializeField] private PlayerRecord record ;
    [SerializeField] private Items StorePrefabs;
    [SerializeField] private bag PlayerBag;
    [SerializeField] private int Money;
    [SerializeField] private Text mOney;
    [SerializeField] private Text name;
    [SerializeField] private GameObject money;
    private setMoney set_Money;
    // Start is called before the first frame update

    private void Awake()
    {
        set_Money = money.GetComponent<setMoney>();
        mOney.text = Money.ToString()+"yuan";
        name.text = StorePrefabs._name;
        
}


    public void ClickToBuy() {
        if (record.Money - Money >= 0) {
            record.Money -= Money;
            set_Money.SetMoneyUI();
            if (PlayerBag.itemList.Contains(StorePrefabs))
            {
                StorePrefabs._num += 1;
            }
            else {
                for (int i = 0; i < PlayerBag.itemList.Count; i++) {
                    if (PlayerBag.itemList[i] == null) {
                        PlayerBag.itemList[i] = StorePrefabs;
                        return;
                    }                
                }

            }

        }
        else {
            Debug.Log("NoMoney");
        }


      
    }
}
