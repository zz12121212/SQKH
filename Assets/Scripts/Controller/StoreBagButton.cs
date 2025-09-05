using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBagButton : MonoBehaviour
{
    public bag PlayerBag;
    public bag StoreBag;
    public Items item;
    public GameObject NoPlaceUI;
    public void IfClicked() {
        if (PlayerBag.itemList.Contains(item)) 
        {
            StoreBag.itemList.Remove(item);
        }
        
        
        bool HaveNull = false;
        int num = -1;
        for (int i = 0; i < PlayerBag.itemList.Count; i++)
        {
            if (PlayerBag.itemList[i] == null) 
            { 
                HaveNull = true;
                num = i;
                break; 
            }
        }
        if (HaveNull == false) 
        {
            StartCoroutine(SetAndWait());
            return;
        }
        if (HaveNull == true) {
            StoreBag.itemList.Remove(item);
          
            PlayerBag.itemList[num] = item;
        }
    //检查playerBag有没有空位置，没有弹出UI
    //如果有空位置，monsterbag.Remove,Player.Add或者加_num
    //刷新UI
    }


    IEnumerator SetAndWait()
    {
        NoPlaceUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        NoPlaceUI.SetActive(false);
    }
}
