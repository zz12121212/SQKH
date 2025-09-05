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
    //���playerBag��û�п�λ�ã�û�е���UI
    //����п�λ�ã�monsterbag.Remove,Player.Add���߼�_num
    //ˢ��UI
    }


    IEnumerator SetAndWait()
    {
        NoPlaceUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        NoPlaceUI.SetActive(false);
    }
}
