using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelMateral : MonoBehaviour
{
    public MonsterList monsterList;
    public NewMonster monster;
    public Text originalLevel;
    public Text Level;
    public GameObject[] materials;
    public materials Materials;
    public Sure sure;

    public void ClickToShow()
    {
        originalLevel.text = "Lv."+monster.Level.ToString();
        Level.text = "Lv."+(monster.Level + 1).ToString();
        sure.monster = monster;
        sure.set = this;
        for (int i = 0; i < 3; i++) {
            if (monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i] != null) {
                materials[i].transform.GetChild(0).GetComponent<Image>().sprite = monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i]._image;
                materials[i].transform.GetChild(1).GetComponent<Text>().text = GetThingsNumToAddLevel(1).ToString();
                Materials.UsedMaterials[i] = monsterList.monsterList[monster.PrefabNum].transform.GetChild(0).GetComponent<Monster>().things[i];
                Materials.MaterialsNum[i] = GetThingsNumToAddLevel(1);
            }
 
        }

    }


    public int GetThingsNumToAddLevel(int AddLevel) {
        float monsterLevel = monster.Level;
        float AddItemNum = monsterLevel + AddLevel - monster.Level;
        int addItemNum = (int)(AddItemNum * monster.Level);
        if (addItemNum < 1) {
            addItemNum = 1;
        }
        return addItemNum;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }


}
