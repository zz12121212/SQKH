using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButtonOtherDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public Transform oringinalParent;
    public bag PlayerBag;
    public bag toolsBag;
    private bag TheBagBefore;
    private int bagCount;
    public GameObject grid;
    public GameObject otherPrefab;
    private void Start()
    {
        grid = GameObject.FindWithTag("UI").transform.Find("PressR").Find("up").Find("bag").Find("Items").Find("grid").gameObject;
        bagCount = PlayerBag.itemList.Count;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.parent.gameObject.CompareTag("bag")) { TheBagBefore = PlayerBag; }
        else if (transform.parent.parent.gameObject.CompareTag("tools")) { TheBagBefore = toolsBag; }
        
        oringinalParent = transform.parent;
        transform.SetParent(GameObject.FindWithTag("UI").transform);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            transform.SetParent(oringinalParent);
            transform.position = oringinalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("rubbish")) {
            if (TheBagBefore == PlayerBag)
            {
                TheBagBefore.itemList.Find(item => item == gameObject.GetComponent<ItemButtonOnUI>().item)._num = 1;
                TheBagBefore.itemList.Remove(TheBagBefore.itemList.Find(item => item == gameObject.GetComponent<ItemButtonOnUI>().item));
                TheBagBefore.itemList.Add(null);
                GameObject other = Instantiate<GameObject>(otherPrefab);
                other.transform.SetParent(oringinalParent);
                other.transform.position = oringinalParent.transform.position;
                Destroy(gameObject);
                return;
            }
            else if (TheBagBefore == toolsBag) {
                TheBagBefore.itemList.Find(item => item == gameObject.GetComponent<ItemButtonOnUI>().item)._num = 1;
                TheBagBefore.itemList.Remove(TheBagBefore.itemList.Find(item => item == gameObject.GetComponent<ItemButtonOnUI>().item));
                GameObject other = Instantiate<GameObject>(otherPrefab);
                other.GetComponent<ItemButtonOnUI>().item = null;
                other.transform.Find("num").GetComponent<Text>().text = "00";
                other.transform.SetParent(oringinalParent);
                other.transform.position = oringinalParent.transform.position;
                other.SetActive(false);
                Destroy(gameObject);
                return;
            }
        }
        if (!eventData.pointerCurrentRaycast.gameObject.CompareTag("slot") && !eventData.pointerCurrentRaycast.gameObject.CompareTag("tools"))
        {
            transform.SetParent(oringinalParent);
            transform.position = oringinalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "iii" && eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.gameObject.tag == "slot") //移动到背包里有物体的位置
        {
            if (TheBagBefore == toolsBag)
            {
                for (int i = 0; i < PlayerBag.itemList.Count; i++)
                {
                    if (PlayerBag.itemList[i] == null)
                    {
                        PlayerBag.itemList[i] = GetComponent<ItemButtonOnUI>().item;
                        break;
                    }
                }
                toolsBag.itemList.Remove(GetComponent<ItemButtonOnUI>().item);
                SameItemsTo(PlayerBag);
            }
             TheBagBefore = PlayerBag;
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = oringinalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(oringinalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            return;
        }

        else if (eventData.pointerCurrentRaycast.gameObject.tag == "slot")//移动到背包里没有放置物体的位置
        {
            if (TheBagBefore == toolsBag)
            {
                for (int i = 0; i < PlayerBag.itemList.Count; i++) {
                    if (PlayerBag.itemList[i] == null) {
                        PlayerBag.itemList[i] = GetComponent<ItemButtonOnUI>().item;
                        break;
                    }
                }  
                toolsBag.itemList.Remove(GetComponent<ItemButtonOnUI>().item);
                SameItemsTo(PlayerBag);
            }
            TheBagBefore = PlayerBag;
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            GetChildWithTag(eventData.pointerCurrentRaycast.gameObject, "other").transform.position = oringinalParent.position;
            GetChildWithTag(eventData.pointerCurrentRaycast.gameObject, "other").transform.SetParent(oringinalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.tag == "tools")//移动到工具栏，方便使用
        {
            if (TheBagBefore == PlayerBag)
            {
                toolsBag.itemList.Add(GetComponent<ItemButtonOnUI>().item);
                PlayerBag.itemList.Remove(GetComponent<ItemButtonOnUI>().item);
                ResetBagCount(PlayerBag);
            }
            TheBagBefore = toolsBag;
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

            GetChildWithTag(eventData.pointerCurrentRaycast.gameObject, "other").transform.position = oringinalParent.position;
            GetChildWithTag(eventData.pointerCurrentRaycast.gameObject, "other").transform.SetParent(oringinalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "iii" && eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.gameObject.tag == "tools")
        {
            if (toolsBag.itemList.Count == 5)
            {
                transform.SetParent(oringinalParent);
                transform.position = oringinalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;

            }
            if (TheBagBefore == PlayerBag)
            {
                toolsBag.itemList.Add(GetComponent<ItemButtonOnUI>().item);
                PlayerBag.itemList.Remove(GetComponent<ItemButtonOnUI>().item);
                ResetBagCount(PlayerBag);
            }
            TheBagBefore = toolsBag;
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = oringinalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(oringinalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            transform.SetParent(oringinalParent);
            transform.position = oringinalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void ResetBagCount(bag PlayerBag)
    {
        if (PlayerBag.itemList.Count > bagCount)
        {
           PlayerBag.itemList.RemoveRange(bagCount, PlayerBag.itemList.Count - bagCount);
        }
        else if (PlayerBag.itemList.Count < bagCount)
        {
                  while (PlayerBag.itemList.Count < bagCount)
        {
            PlayerBag.itemList.Add(null);
        }
        }

    }

    public void SameItemsTo(bag _bag)
    {
        if (_bag == null || _bag.itemList == null) return;
        for (int i = _bag.itemList.Count - 1; i >= 0; i--)
        {
            Items currentItem = _bag.itemList[i];
            if (currentItem == null) continue;
            for (int j = i - 1; j >= 0; j--)
            {
                Items otherItem = _bag.itemList[j];
                if (otherItem == null) continue;
                if (currentItem._name == otherItem._name)
                {
                    otherItem._num += currentItem._num;
                    _bag.itemList.RemoveAt(i);
                    break;
                }
            }
        }
        ResetBagCount(_bag);
        grid.transform.parent.parent.Find("introduce").Find("Text").GetComponent<Text>().text = " ";
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            Transform child = grid.transform.GetChild(i);
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }
        grid.transform.parent.parent.GetComponent<bagController>().resetTheBag(_bag);
    }

    private GameObject GetChildWithTag(GameObject gameObject,string tag) {
       for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == tag)
            {
                return gameObject.transform.GetChild(i).gameObject;
                         }
          }
        return null;
    }
}
