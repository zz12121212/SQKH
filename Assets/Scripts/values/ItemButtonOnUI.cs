using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonOnUI : MonoBehaviour
{
    public Items item;
    public GameObject choice;
    public bool haveChoice = false;

    public void CallOutPutAndEat() {
        GameObject _choice;
        if (haveChoice) { return; }
        if (transform.parent.parent.name == "grid") { return; }
        for (int i = 0; i < transform.parent.childCount; i++) { 
        if(transform.parent.GetChild(i).tag == "choice"){
                _choice = transform.parent.GetChild(i).gameObject;
                _choice.SetActive(true);
            }
        }
      
        haveChoice = true;
    }
}
