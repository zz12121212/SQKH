using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eatAndPut : MonoBehaviour
{
    public Items item;
    public GameObject put,eat,close;
    public bag toolsBag;
    public GameObject _Put;

    private void OnEnable()
    {
        item = GetChildWithTag(transform.parent.gameObject, "other").GetComponent<ItemButtonOnUI>().item;
        if (item.canEat == true) {
            eat.GetComponent<Button>().enabled = true;
            eat.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        if (item.canPut == true)
        {
            put.GetComponent<Button>().enabled = true;
            put.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    private void OnDisable()
    {

            eat.GetComponent<Button>().enabled = false;
            eat.GetComponent<Image>().color = new Color32(140,140,140,255);
    
            put.GetComponent<Button>().enabled = false;
            put.GetComponent<Image>().color = new Color32(140, 140, 140, 255);
        
    }

    public void ToPut()
    {
        GameObject ui = GameObject.FindWithTag("UI");
        _Put.GetComponent<put>().item = item;
        if (ui != null) ui.SetActive(false);
        _Put.SetActive(true);
        GetChildWithTag(transform.parent.gameObject, "other").GetComponent<ItemButtonOnUI>().haveChoice = false;
        gameObject.SetActive(false);
    }

        public void ToEat() {
  
    }


    public void ToClose() {
        GetChildWithTag(transform.parent.gameObject, "other").GetComponent<ItemButtonOnUI>().haveChoice = false;
        gameObject.SetActive(false);
    }

    private GameObject GetChildWithTag(GameObject gameObject, string tag)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == tag)
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }
}


