using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class ClickToShow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform oringinalParent;
    public GameObject originalGrid;
    public int originalNum;

    public NewMonster monster;
    public Text InFo;
    public MonsterBag monsterBag;
    public MonsterBag monsterDesk;
    public MonsterList monsterList;
    public SetPetsDesk setPetsDesk;

    private void OnEnable()
    {
      //  originalGrid = gameObject.transform.parent.parent.gameObject;
      //  oringinalParent = transform.parent;
       // originalNum = FindMonsterIndex(transform.parent.gameObject,originalGrid);
        setPetsDesk = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetComponent<SetPetsDesk>();
        InFo = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
    }

    public void ClickShowInFo() {
        if (monster.PrefabNum < 0) { return; }
        InFo.text = monsterList.monsterList[monster.PrefabNum].name + "  Lv." + monster.Level.ToString();
        }

     public void OnBeginDrag(PointerEventData eventData)
    {
        originalGrid = transform.parent.parent.gameObject;
        oringinalParent = transform.parent;
        originalGrid = transform.parent.parent.gameObject;
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
        else if (eventData.pointerCurrentRaycast.gameObject.name != "a")
        {
            transform.SetParent(oringinalParent);
            transform.position = oringinalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

        if (originalGrid.name == "bagPetsGrid") { 
        if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.name == "bagPetsGrid"  ) {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(oringinalParent);
               eventData.pointerCurrentRaycast.gameObject.transform.position = oringinalParent.position;
                ExchangeNewMonster(eventData.pointerCurrentRaycast.gameObject);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        else if(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.name == "grid")
            {

                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(oringinalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.position = oringinalParent.position;
                ExchangeNewMonster(eventData.pointerCurrentRaycast.gameObject);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        else if (originalGrid.name == "grid")
        {
            if (eventData.pointerCurrentRaycast.gameObject == null)
            {
                transform.SetParent(oringinalParent);
                transform.position = oringinalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.name != "a")
            {
                transform.SetParent(oringinalParent);
                transform.position = oringinalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.name == "grid")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(oringinalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.position = oringinalParent.position;
                ExchangeNewMonster(eventData.pointerCurrentRaycast.gameObject);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.name == "bagPetsGrid")
            {

                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(oringinalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.position = oringinalParent.position;
                ExchangeNewMonster(eventData.pointerCurrentRaycast.gameObject);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }



        }
        }

    private int FindNewMonster(NewMonster newMonster, MonsterBag _monsterBag) {
     for (int i = 0; i < _monsterBag.itemList.Count; i++) {
            if (newMonster.Level == _monsterBag.itemList[i].Level && newMonster.PrefabNum == _monsterBag.itemList[i].PrefabNum)
            {
                    return i;
                    }
                }
        return -1;
    }
    private int FindMonsterIndex(GameObject _object, GameObject grid)
    {
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            if (_object == grid.transform.GetChild(i))
            {
                return i;
            }
        }
        return -1;
    }

    private void ExchangeNewMonster(GameObject endObject
        )  {
        MonsterBag StartBag = null;
        MonsterBag EndBag = null;
        GameObject endGrid = endObject.GetComponent<ClickToShow>().originalGrid;
        int EndMonsterNum = endObject.GetComponent<ClickToShow>().originalNum;
        int StartMonsterNum = originalNum;
        if (originalGrid.name == "grid")
        {
            StartBag = monsterDesk;
        }
        else if (originalGrid.name == "bagPetsGrid") {
            StartBag = monsterBag;
        }

        if (endGrid.name == "grid") {
            EndBag = monsterDesk;
        }
        else if (endGrid.name == "bagPetsGrid")
        {
            EndBag = monsterBag;
        }

        float EndBagLevel = EndBag.itemList[EndMonsterNum].Level;
        int EndBagPrefabNum = EndBag.itemList[EndMonsterNum].PrefabNum;
        EndBag.itemList[EndMonsterNum].Level = StartBag.itemList[StartMonsterNum].Level;
        EndBag.itemList[EndMonsterNum].PrefabNum = StartBag.itemList[StartMonsterNum].PrefabNum;
        StartBag.itemList[StartMonsterNum].Level = EndBagLevel;
        StartBag.itemList[StartMonsterNum].PrefabNum = EndBagPrefabNum;
        setPetsDesk.ReSetAll();
    }
}
