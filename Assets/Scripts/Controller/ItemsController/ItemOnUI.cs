using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnUI : MonoBehaviour
{   
    public Items items;
    public Image itemImage;
    public Text slotNum;

    public GameObject itemInSlot;
    
    public void ItemOnClick() {
        bagManager.UpdateItemInFo(items._Info);
    }

    public void SetupSlot(Items item)
    {
        if (item == null) {
            itemInSlot.SetActive(false);
            return;
        }
        items = item;
        itemInSlot.SetActive(true);
        itemImage.sprite = item._image;
        slotNum.text = item._num.ToString();
    }
}
