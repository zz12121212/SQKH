using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReFreshTools : MonoBehaviour
{
    public GameObject _other;
    public bag toolsBag;


   
    private void OnEnable()
    {   int a = 0;
        GameObject _gameObject;
      
        for (int i = 0; i < toolsBag.itemList.Count; i++) {
            if (toolsBag.itemList[i]._num > 0) {
                _gameObject = Instantiate(_other);
                _gameObject.SetActive(true);
                _gameObject.transform.Find("num").GetComponent<Text>().text = toolsBag.itemList[i]._num.ToString();
                _gameObject.transform.Find("iii").GetComponent<Image>().sprite = toolsBag.itemList[i]._image;
                _gameObject.GetComponent<ItemButtonOnUI>().item = toolsBag.itemList[i];
                _gameObject.transform.SetParent( transform.GetChild(a));
                _gameObject.transform.position = _gameObject.transform.parent.position;
                _gameObject = null;
                a++;
            }
            else if (toolsBag.itemList[i]._num <= 0) {
                toolsBag.itemList[i]._num = 1;
                toolsBag.itemList.Remove(toolsBag.itemList[i]);
            }
        }
        for (int i = 0; i <transform.childCount; i++)
        {
            if (!GetChildWithTag(transform.GetChild(i).gameObject, "other")) {
                _gameObject = Instantiate(_other);
                _gameObject.SetActive(false);
                _gameObject.transform.SetParent(transform.GetChild(i));
            };
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(GetChildWithTag(transform.GetChild(i).gameObject, "other"));
        }
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
