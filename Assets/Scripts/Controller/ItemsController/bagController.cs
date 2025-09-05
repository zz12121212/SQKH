using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagController : MonoBehaviour
{
    public bag TheBag;
    public GameObject UIPrefab;
    public GameObject grid;
    private GameObject TheItem;
    private Text InFoText;
   
   
    // Start is called before the first frame update

    private void OnEnable()
    {
        InFoText =GameObject.FindWithTag("UI").transform.Find("PressR").Find("up").Find("bag").Find("introduce").Find("Text").GetComponent<Text>();
        InFoText.text = " ";
        resetTheBag(TheBag);

    }

    private void OnDisable()
    {
        InFoText.text = " ";
        for (int i = 0; i < grid.transform.childCount; i++) {
            Transform child = grid.transform.GetChild(i);
            child.gameObject.SetActive(false); 
            Destroy(child.gameObject); 
        }
    }

    private void SetAButton(GameObject _UIprefab,Items item) {
       _UIprefab.transform.Find("other").GetComponent<ItemButtonClick>().InFo = item._Info;
        GameObject _other = _UIprefab.transform.Find("other").gameObject;
        GameObject _num = _UIprefab.transform.Find("other").Find("num").gameObject;
        GameObject _image = _UIprefab.transform.Find("other").Find("iii").gameObject;
        _other.SetActive(true);
        _num.GetComponent<Text>().text = item._num.ToString();
        _image.GetComponent<Image>().sprite = item._image;
        _other.GetComponent<ItemButtonOnUI>().item = item;
    }

    public void resetTheBag(bag TheBag) {
        for (int i = 0; i <TheBag.itemList.Count ; i++)
        {  if (TheBag.itemList[i] != null && TheBag.itemList[i]._num <= 0)
            {
                TheBag.itemList[i]._num = 1;
                TheBag.itemList.Remove(TheBag.itemList[i]);
                TheBag.itemList.Add(null);
                continue;
            }
             else if (TheBag.itemList[i] != null)
            {
                TheItem = Instantiate(UIPrefab);
                SetAButton(TheItem, TheBag.itemList[i]);
                TheItem.transform.SetParent(grid.transform);
                TheItem = null;
                continue;
            }
            else
            {
                TheItem = Instantiate(UIPrefab);
                TheItem.transform.SetParent(grid.transform);
                TheItem = null;
                continue;
            }
           
        }
    }
}
