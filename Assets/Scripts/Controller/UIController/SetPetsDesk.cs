using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPetsDesk : MonoBehaviour
{
    public MonsterBag monsterBag;
    public MonsterList monster;
    public MonsterBag monsterDesk;
    public GameObject BagGrid;
    public GameObject DeskGrid;
    public GameObject BagPrefab;
    public GameObject DeskPrefab;
    public Sprite sprite;
    private void OnEnable()
    {
        //Bag
        for (int i = 0; i < monsterBag.itemList.Count; i++) {
            GameObject gameObject = Instantiate<GameObject>(BagPrefab);
            gameObject.transform.SetParent(BagGrid.transform);
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().monster =monsterBag.itemList[i];
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalNum = i;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalGrid= BagGrid;
            if (monsterBag.itemList[i].PrefabNum != -1)
            {
                
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = monster.monsterList[monsterBag.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
        }
        //Desk
        for (int i = 0; i < monsterDesk.itemList.Count; i++)
        {
            GameObject gameObject = Instantiate<GameObject>(DeskPrefab);
            gameObject.transform.SetParent(DeskGrid.transform);
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().monster = monsterDesk.itemList[i];
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalNum = i;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalGrid = DeskGrid;
            if (monsterDesk.itemList[i].PrefabNum != -1)
            {
                
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = monster.monsterList[monsterDesk.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    private void OnDisable()
    {
        //Bag
        for (int i = BagGrid.transform.childCount-1; i >= 0; i--)
        {
            Destroy(BagGrid.transform.GetChild(i).gameObject);
        }
        //Desk
        for (int i = DeskGrid.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(DeskGrid.transform.GetChild(i).gameObject);
        }
    }

    public void ReSetAll() {
      
        for (int i = 0; i < monsterBag.itemList.Count; i++)
        {

            GameObject gameObject = BagGrid.transform.GetChild(i).gameObject;
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().monster = monsterBag.itemList[i];
           gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalNum = i;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalGrid = BagGrid;
            if (monsterBag.itemList[i].PrefabNum != -1)
            {
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = monster.monsterList[monsterBag.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
        }
        //Desk
        for (int i = 0; i < monsterDesk.itemList.Count; i++)
        {
            GameObject gameObject = DeskGrid.transform.GetChild(i).gameObject;
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().monster = monsterDesk.itemList[i];
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalNum = i;
            gameObject.transform.GetChild(0).GetComponent<ClickToShow>().originalGrid = DeskGrid;
            if (monsterDesk.itemList[i].PrefabNum != -1)
            {
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = monster.monsterList[monsterDesk.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
        }
    }





}
