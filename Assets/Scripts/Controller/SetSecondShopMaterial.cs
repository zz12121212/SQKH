using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSecondShopMaterial : MonoBehaviour
{
    public MonsterList monsterList;
    public NewMonster monster;
    public Text Info;
    public GameObject[] materials = new GameObject[3];
    public GameObject sure;
    public void ClickTheButton() {
        SecondSHopSure Sure = sure.GetComponent<SecondSHopSure>();
        Info.text = monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).name+" Lv."+monster.Level.ToString();
        Sure.monster = monster;
        for (int i = 0; i < 3; i++)
        {
            if (monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i] != null)
                materials[i].transform.GetChild(0).GetComponent<Image>().sprite = monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i]._image;
                materials[i].transform.GetChild(1).GetComponent<Text>().text = "*"+MaterialNum((int)monster.Level).ToString();
                Sure.items[i] = monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i];
                Sure.nums[i] = MaterialNum((int)monster.Level);
        }
        sure.SetActive(true); 
       // if (Sure.StoreBag.itemList.Count == 0) { }
      //  else if (Sure.StoreBag.itemList.Count > 0) { sure.SetActive(false);
        //    StartCoroutine(Sure.SetActiveWaitSomeTime());
       // }

    }


    private int MaterialNum(int Level) {
        return (int)(Level * 1.5);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        DestroyThis();
    }
}
