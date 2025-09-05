using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemOnWorld : MonoBehaviour
{public GameObject _this;
    public Items thisItem;
    public bag thisBag;
    public bag toolsBag;
   public bool isGetting = false;
    public GameObject UI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGetting)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                isGetting = true;
                AddNewItem();
            }
            if (Input.GetKeyDown(KeyCode.Q)&&UI!=null) {
                UI.SetActive(true);
            }
        }
    }

    public void AddNewItem()
    {
        if (toolsBag.itemList != null && toolsBag.itemList.Contains(thisItem))
        {
            for (int i = 0; i < toolsBag.itemList.Count; i++)
            {
                if (toolsBag.itemList[i] == thisItem)
                {
                    toolsBag.itemList[i]._num += 1;
                    foreach (Transform child in GameObject.FindGameObjectWithTag("UI").transform) { 
                    if(child.tag == "tools")
                        {
                            child.gameObject.SetActive(false);
                            child.gameObject.SetActive(true);

                        }
                    }
                    Destroy(_this);
                    break;
                }
            }
        }
        else 
        { 
            if (!thisBag.itemList.Contains(thisItem))
        {
                bool Added = false;
            for (int i = 0; i < thisBag.itemList.Count; i++)
            {
                if (thisBag.itemList[i] == null)
                    {
                        if (thisItem._num <= 0) 
                        {
                            thisItem._num = 1;
                        }
                        thisBag.itemList[i] = thisItem;
                        Added = true;
                        Destroy(_this);
                        break;
                    }
                }
                if (Added == false) { return; }
            }
        else 
        {
            thisItem._num += 1;
                Destroy(_this);
            }

        }

    }
}
