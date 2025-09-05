using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtons : MonoBehaviour
{[Header("Õ®”√")]
    public MonsterBag monsterBag;
    public MonsterList monsterList;
    public GameObject grid;
    public GameObject prefab;
    public GameObject[] m;
 [Header("SetLevelMaterial")]
    public Text originalLevel;
    public Text level;
    public materials Materials;
    public Sure sure;
    [Header("SetSecondShopMaterial")]
    public Text Info;
    public GameObject Sure;
    private void OnEnable()
    {
        SetThese();
    }

    public void SetThese() {
        for (int i = 0; i < monsterBag.itemList.Count; i++)
        {
            GameObject gameObject = Instantiate<GameObject>(prefab);
            gameObject.transform.SetParent(grid.transform);

            if (monsterBag.itemList[i].PrefabNum != -1)
            {
                gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = monsterList.monsterList[monsterBag.itemList[i].PrefabNum].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            }
            if (gameObject.GetComponent<SetSecondShopMaterial>())
            {
                gameObject.GetComponent<SetSecondShopMaterial>().monster = monsterBag.itemList[i];
                gameObject.GetComponent<SetSecondShopMaterial>().Info = Info;
                gameObject.GetComponent<SetSecondShopMaterial>().materials = m;
                gameObject.GetComponent<SetSecondShopMaterial>().sure = Sure;
            }
            if (gameObject.transform.GetComponent<SetLevelMateral>())
            {
                gameObject.transform.GetComponent<SetLevelMateral>().monster = monsterBag.itemList[i];
                gameObject.transform.GetComponent<SetLevelMateral>().originalLevel = originalLevel;
                gameObject.transform.GetComponent<SetLevelMateral>().Level = level;
                gameObject.transform.GetComponent<SetLevelMateral>().Materials = Materials;
                gameObject.transform.GetComponent<SetLevelMateral>().sure = sure;
                for (int j = 0; j < 3; j++)
                {
                    gameObject.transform.GetComponent<SetLevelMateral>().materials[j] = m[j];
                }
            }
        }
    }

}
