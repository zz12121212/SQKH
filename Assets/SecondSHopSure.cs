using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSHopSure : MonoBehaviour
{
    //public bag StoreBag;
    public bag PlayerBag;
    public MonsterBag monsterBag;
    public Items[] items;
    public int[] nums;
    public NewMonster monster;
    public SetButtons setButtons;
    public GameObject grid;
    public GameObject HaveSomeItemsInStore;
    // Start is called before the first frame update



    public void OnClicked()
    {
        monsterBag.itemList.Find(item => item == monster).PrefabNum = -1;
        monsterBag.itemList.Find(item => item == monster).Level = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) continue;
            if (PlayerBag.itemList.Contains(items[i]))
            {
                items[i]._num += nums[i];
                continue;
                }
            bool Added = false;
            for (int j = 0; j < PlayerBag.itemList.Count; j++)
            {
                if (PlayerBag.itemList[j] == null)
                {
                    PlayerBag.itemList[j] = items[i];
                    Added = true;
                    break;
                }
            }
            if (Added == false)
            {
               // StoreBag.itemList.Add(items[i]);
                StartCoroutine(SetActiveWaitSomeTime());
                gameObject.SetActive(false);
            }
        }
        for (int i = grid.transform.childCount; i > 0; i--) {
            grid.transform.GetChild(i-1).GetComponent<SetSecondShopMaterial>().DestroyThis();
        }
        setButtons.SetThese();
        gameObject.SetActive(false);
    }

    public IEnumerator SetActiveWaitSomeTime() {
        HaveSomeItemsInStore.SetActive(true);
        yield return new WaitForSeconds(1f);
        HaveSomeItemsInStore.SetActive(false);
    }
}
