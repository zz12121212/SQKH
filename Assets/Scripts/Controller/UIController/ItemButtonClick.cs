using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemButtonClick : MonoBehaviour
{
    public string InFo;
    public Text InFoText;

    private void Start()
    {
        InFoText = GameObject.FindWithTag("UI").transform.Find("PressR").Find("up").Find("bag").Find("introduce").Find("Text").GetComponent<Text>();
    }

    public void ClickToInFo() {
        if (InFoText.transform.parent.parent.gameObject.activeSelf == false) { return; }
        InFoText.text = InFo;
    }



    
}
