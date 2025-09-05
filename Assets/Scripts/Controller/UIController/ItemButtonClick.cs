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
        if (gameObject.transform.parent.CompareTag("tools")) { return; }
        InFoText = GameObject.FindWithTag("InFo").GetComponent<Text>();
    }

    public void ClickToInFo()
    {
        if (gameObject.transform.parent.CompareTag("tools")) { return; }
        if (InFoText.transform.parent.parent.gameObject.activeSelf == false) { return; }
        InFoText.text = InFo;
    }



    
}
