using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagManager : MonoBehaviour
{
    static bagManager instance;

    public bag MyBag;
    public GameObject Grid;
    //public ItemOnUI itemUIPrefab;
    public GameObject emptySlot;
    public Text itenInFo;

    public List<GameObject> slots = new List<GameObject>();
    private void Awake()
    {
            if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        ReFreshItem();
        instance.itenInFo.text = "  ";
    }

    public static void UpdateItemInFo(string _ItemInFo) {
        instance.itenInFo.text = _ItemInFo;
    }

 /*  public static void CreatNewItem( Items item) {
        ItemOnUI newItem = Instantiate(instance.itemUIPrefab, instance.Grid.transform.position,Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.Grid.transform);
        newItem.items = item;
        newItem.itemImage.sprite = item._image;
        newItem.slotNum.text = item._num.ToString();
    }*/

    public static void ReFreshItem() {
        for (int i = 0; i <instance.Grid.transform.childCount; i++)
        {
            if (instance.Grid.transform.childCount == 0)
                break;
            Destroy(instance.Grid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.MyBag.itemList.Count;  i++) {
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.Grid.transform);
            instance.slots[i].GetComponent<ItemOnUI>().SetupSlot(instance.MyBag.itemList[i]);

           // instance.slots[i].GetComponent<UI_ground>()._object = instance.MyBag.itemList[i].prefab;
        }
    }
}
