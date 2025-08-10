using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public GameObject tools;
    public GameObject UI;
    public Items item;
    public GameObject objectPrefab;
    private GameObject curGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnBeginDrag(BaseEventData data) {
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    }
    public void OnDrag(BaseEventData data) {
        if (curGameObject == null) { return; }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranslateScreenToWorld(pointerEventData.position);
    }
  
    public void OnEndDrag(BaseEventData data) {
        if (curGameObject == null) { return; }
        PointerEventData pointerEventData = data as PointerEventData;
        Collider2D[] col = Physics2D.OverlapPointAll(TranslateScreenToWorld(pointerEventData.position));
        foreach (Collider2D c in col) {
            if (c.tag == "Land" && c.transform.childCount == 0) {
                curGameObject.transform.parent = c.transform;
                curGameObject.transform.localPosition = Vector3.zero;
                curGameObject = null;
                item._num -= 1;
                transform.parent.gameObject.SetActive(false);
                UI.SetActive(true);
                break;
            }
        }
        if (curGameObject != null) {
            GameObject.Destroy(curGameObject);
            curGameObject = null;
        }
    }

    public static Vector3 TranslateScreenToWorld(Vector3 position) {
        Vector3 caremaTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(caremaTranslatePos.x, caremaTranslatePos.y, 0);
    }
}
