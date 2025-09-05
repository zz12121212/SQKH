using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chosePetButton : MonoBehaviour
{
    public FightRecord record;
    public MonsterBag monsterBag;
    public GameObject grid;

    private void OnEnable()
    {
        grid = GameObject.FindGameObjectWithTag("Put");
    }
    public void ClickToChoose() {
        if (gameObject.transform.GetChild(0).GetComponent<Image>().color.a == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < grid.transform.childCount; i++)
            {
                if (grid.transform.GetChild(i).gameObject == gameObject)
                {
                    record.Pet = monsterBag.itemList[i];
                    SceneManager.LoadScene("FightScene");
                    return;
                }
            }

         //   StartCoroutine (Wait());

        }
    }

    IEnumerator Wait() {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FightScene");
    }

    private void FindTheGameObject()
    {
        
    }
}
