using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RToReadPets : MonoBehaviour
{
    public GameObject prefab;
    public GameObject grid;
    public MonsterBag monsterBag;
    public MonsterList monsterList;

    private void OnEnable()
    {   for (int i = 0; i < monsterBag.itemList.Count; i++)
        {
            GameObject gameObject = Instantiate<GameObject>(prefab);
            gameObject.transform.SetParent(grid.transform);
            if (monsterBag.itemList[i].PrefabNum != -1)
            {
                gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
                gameObject.GetComponent<Image>().sprite = monsterList.monsterList[monsterBag.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < grid.transform.childCount; i++) {
            Destroy(grid.transform.GetChild(i).gameObject);
        }
    }

}
