using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{public GameObject _this;
    public Items thisItem;
    public bag thisBag;
   public bool isGetting = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGetting)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                isGetting = true;
                AddNewItem();
                Destroy(_this);
            }
        }
    }

    public void AddNewItem()
    {

        if (!thisBag.itemList.Contains(thisItem))
        {
            for (int i = 0; i < thisBag.itemList.Count; i++) {
                if (thisBag.itemList[i] != null) { }
                else { thisBag.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else {
            thisItem._num += 1;
        }
        bagManager.ReFreshItem();
    }

 
}
