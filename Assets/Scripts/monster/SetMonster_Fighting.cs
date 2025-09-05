using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetMonster_Fighting : MonoBehaviour
{
    public FightRecord record;
    public GameObject Pet;
    public GameObject Enemy;
    public MonsterList monster;
    // Start is called before the first frame update
    void Start()
    {
        if (Pet.transform.childCount != 0) {
            for (int i = Pet.transform.childCount -1; i >= 0; i--)
            { 
            Destroy(Pet.transform.GetChild(i).gameObject);
            }
        }
        if (Enemy.transform.childCount != 0)
        {
            for (int i = Enemy.transform.childCount-1; i >= 0; i--)
            {
                Destroy(Enemy.transform.GetChild(i).gameObject);
            }
        }
        GameObject enemy = Instantiate<GameObject>(monster.monsterList[record.Enemy]);
        enemy.transform.parent = Enemy.transform;
        enemy.transform.localPosition = new Vector3(0,0,0);
        if (enemy.transform.GetChild(0).GetComponent<Monster>().prefabNum == 0)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1);
            enemy.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }
        else if (enemy.transform.GetChild(0).GetComponent<Monster>().prefabNum == 1)
        {
            enemy.transform.localScale = new Vector3(1, 1, 1); 
            enemy.transform.GetChild(0).localScale = new Vector3(0.16f, 0.16f, 0.16f);
        }
            GameObject pet =  Instantiate<GameObject>(monster.monsterList[record.Pet.PrefabNum]);
        pet.transform.parent = Pet.transform;
        pet.transform.localPosition = new Vector3(0,0,0);
        pet.transform.localScale = new Vector3(1, 1, 1);
        pet.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        enemy.transform.GetChild(0).GetComponent<Monster>().SetLevel(record.EnemyLevel);
        pet.transform.GetChild(0).GetComponent<Monster>().SetLevel(record.Pet.Level);

    }

}
