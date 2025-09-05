using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BagRead : MonoBehaviour
{
    public Text text;
    public Sprite image;
    public FightRecord record;
    public GameObject[] Images;
    public Items[] items;
    public bag BagToRead;
    public MonsterBag monsterBag;
    public MonsterList monsterList;
    public GameObject Pet;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (gameObject.name == "pill")
        {
            for (int i = 0; i < monsterBag.itemList.Count; i++)
            {
                if (monsterBag.itemList[i].PrefabNum == -1)
                {
                    gameObject.GetComponent<Button>().enabled = true;
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadMedicine() {
        int count = 0; 
        for (int i = 0; i < BagToRead.itemList.Count; i++) {
            if (BagToRead.itemList[i] != null && BagToRead.itemList[i].medicine == true) {
                Images[count].transform.Find("Image").GetComponent<Image>().sprite = BagToRead.itemList[i]._image;
                Images[count].transform.Find("Num").GetComponent<Text>().color = new Color(1, 1, 1, 1);
                if (BagToRead.itemList[i]._num < 10)
                {
                    Images[count].transform.Find("Num").GetComponent<Text>().text = "0" + BagToRead.itemList[i]._num.ToString();
                }
                else
                {
                    Images[count].transform.Find("Num").GetComponent<Text>().text = BagToRead.itemList[i]._num.ToString();
                }

                items[count] = BagToRead.itemList[i];
                count++;
            }
            if (count >= 4) { return; }
        }
    }

    public void ReadPill()
    {

        int count = 0;
        for (int i = 0; i < BagToRead.itemList.Count; i++)
        {
            if (BagToRead.itemList[i] != null && BagToRead.itemList[i].pill == true)
            {
                Images[count].transform.Find("Image").GetComponent<Image>().sprite = BagToRead.itemList[i]._image;
                Images[count].transform.Find("Num").GetComponent<Text>().color = new Color(1,1,1,1);
                if (BagToRead.itemList[i]._num < 10) 
                { 
                    Images[count].transform.Find("Num").GetComponent<Text>().text = "0"+BagToRead.itemList[i]._num.ToString(); 
                }
                else{
                    Images[count].transform.Find("Num").GetComponent<Text>().text =  BagToRead.itemList[i]._num.ToString();
                }
               
                items[count] = BagToRead.itemList[i];
                count++;
            }
            if (count >= 4) { return; }
        }
    }

    public void RefreshMedicUI() {
        for (int i = 0; i < items.Length; i++) {
            items[i] = null;
            Images[i].transform.Find("Image").GetComponent<Image>().sprite = image;
            Images[i].transform.Find("Num").GetComponent<Text>().color = new Color(1, 1, 1, 0);
            Images[i].transform.Find("Num").GetComponent<Text>().text = "00";
        }
        ReadMedicine();
    }
    public void RefreshPillUI()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = null;
            Images[i].transform.Find("Image").GetComponent<Image>().sprite = image;
            Images[i].transform.Find("Num").GetComponent<Text>().color = new Color(1, 1, 1, 0);
            Images[i].transform.Find("Num").GetComponent<Text>().text = "00";
        }
        ReadPill();
    }

    public void UseMedic(int objectNum) {
        int changeBlood = items[objectNum].prefab.GetComponent<Medic>().blood;
        float beforeBlood = Pet.transform.GetChild(0).GetChild(0).GetComponent<Monster>().Blood;
       //   int changeMagic = items[objectNum].prefab.GetComponent<Medic>().Magic;
       Pet.transform.GetChild(0).GetChild(0).GetComponent<Monster>().GetHealed(changeBlood);
        float changedBlood = Pet.transform.GetChild(0).GetChild(0).GetComponent<Monster>().Blood - beforeBlood;
        for (int i = 0; i < BagToRead.itemList.Count; i++) {
            if (BagToRead.itemList[i] == items[objectNum]) {
                BagToRead.itemList[i]._num -= 1;
                if (BagToRead.itemList[i]._num < 1)
                {
                    BagToRead.itemList[i]._num = 1;
                    BagToRead.itemList.Remove(BagToRead.itemList[i]);
                    BagToRead.itemList.Add(null);
                }
            }
        }
        RefreshMedicUI();
        GameObject.Find("blood").transform.GetChild(0).GetComponent<BloodBar>().ChangeFillCount( changedBlood/Pet.transform.GetChild(0).GetChild(0).GetComponent<Monster>().MaxBlood);
    }

    public void UsePill(int objectNum)
    {
        bool canHave = items[objectNum].prefab.GetComponent<Pill>().canHave();
        if (canHave == false) {
            RefreshItemNum(objectNum);
            return;
        }
        for (int i = 0; i < 8; i++) {
            if (monsterBag.itemList[i].PrefabNum == -1) {
                monsterBag.itemList[i].Level = record.EnemyLevel;
                monsterBag.itemList[i].PrefabNum = record.Enemy;
                break;
            }
        }
    RefreshItemNum(objectNum);
    text.GetComponent<Animator>().SetBool("start", true);
        
    }


    private void RefreshItemNum(int objectNum)
    {

        for (int i = 0; i < monsterBag.itemList.Count; i++)
        {
            if (BagToRead.itemList[i] == items[objectNum])
            {
                BagToRead.itemList[i]._num -= 1;
                if (BagToRead.itemList[i]._num < 1)
                {
                    BagToRead.itemList[i]._num = 1;
                    BagToRead.itemList.Remove(BagToRead.itemList[i]);
                    BagToRead.itemList.Add(null);
                }
            }
        }
        RefreshPillUI();
    }
}
