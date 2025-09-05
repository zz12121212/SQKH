using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThireStoreButton : MonoBehaviour
{
    public Items item;
    public ThiredStoreRead storeRead;
    public ThirdStoreSure sure;

    public void OnClicked() {
        storeRead.SetSlider(item._num,item.Money);
        sure.storeButton = this;
    }
}
