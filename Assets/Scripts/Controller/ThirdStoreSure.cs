using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThirdStoreSure : MonoBehaviour
{
    public ThiredStoreRead storeRead;
    public ThireStoreButton storeButton;
    public PlayerRecord playerRecord;
    public Text nowMoney;
    private void OnEnable()
    {
        nowMoney.text = ":" + playerRecord.Money.ToString();
    }
    public void IfClicked() {
        storeButton.item._num -= (int)storeRead.currentValue;
        playerRecord.Money += (int)storeRead.currentValue * storeButton.item.Money;
        if (storeButton.item._num <= 0)
        {
            storeButton.item._num = 1;
            storeRead.PlayerBag.itemList.Remove(storeButton.item);
            storeRead.PlayerBag.itemList.Add(null);
            storeRead.SetButtons();
            nowMoney.text = ":" + playerRecord.Money.ToString();
        }
        else {
            storeRead.SetButtons();
            nowMoney.text = ":"+playerRecord.Money.ToString();
        }
    }
}
