using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStoreBagItems : MonoBehaviour
{
    public bag StoreBag;
    public GameObject Prefab;
    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < StoreBag.itemList.Count; i++) {
            if (StoreBag.itemList[i] == null) { StoreBag.itemList.Remove(StoreBag.itemList[i]);i -=1 ; continue; }
            GameObject gameObject = Instantiate<GameObject>(Prefab);
            gameObject.transform.SetParent(gameObject.transform);
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = StoreBag.itemList[i]._image;
            gameObject.transform.GetChild(1).GetComponent<Text>().text = StoreBag.itemList[i]._num.ToString();
            gameObject.GetComponent<StoreBagButton>().item = StoreBag.itemList[i];
        }
    }
}
