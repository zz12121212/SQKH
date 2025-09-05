using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatPrefabs : MonoBehaviour
{
    public int count = 0;
    public GameObject itemsGrid;
    public Collider2D collider;
    public GameObject[] Monsters;
    private bool morning, noon, night;
    [Header("Ôç")]
    public GameObject[] MorningMonsters; 

    [Header("ÖÐ")]
    public GameObject[] NoonMonsters;

    [Header("Íí")]
    public GameObject[] NightMonsters;

    System.Random rdm = new System.Random();

    float RandomFloat(float min, float max) {
        return (float)(rdm.NextDouble() * (max - min) + min);
    }
    void Update()
    {
        if (_time.hourTen * 10 + _time.hour < 6 && morning == false)
        {
            DeletMonsters();
            ResetMonsters();
            morning = true;
            noon = false;
            night = false;
        }
        else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18 && noon == false)
        {
            DeletMonsters();
            ResetMonsters();
            morning = false;
            noon = true;
            night = false;
        }
        else if (_time.hourTen * 10 + _time.hour >= 18 && night == false)
        {
            DeletMonsters();
            ResetMonsters();
            morning = false;
            noon = false;
            night = true;
        }
    }



    public  void ResetMonsters()
    {
        if (itemsGrid)
        {
            count = 0;
            if (_time.hourTen * 10 + _time.hour < 6)
            {
                for (int i = 0; i < Random.Range(2, 5); i++)
                {
                    GameObject grid = itemsGrid.transform.GetChild(Random.Range(2, 38)).GetChild(Random.Range(5, 12)).gameObject;
                    if (grid.transform.childCount == 0)
                    {
                        GameObject MonsterPrefab = Instantiate<GameObject>(MorningMonsters[Random.Range(0, MorningMonsters.Length)]);
                        MonsterPrefab.transform.SetParent(grid.transform);
                        MonsterPrefab.transform.position = grid.transform.position;
                        Monsters[count] = MonsterPrefab;
                        count++;
                    }
                }
            }
            else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18)
            {
                for (int i = 0; i < Random.Range(5, 10); i++)
                {
                    GameObject grid = itemsGrid.transform.GetChild(Random.Range(2, 38)).GetChild(Random.Range(5, 12)).gameObject;
                    if (grid.transform.childCount == 0)
                    {
                        GameObject MonsterPrefab = Instantiate<GameObject>(NoonMonsters[Random.Range(0, NoonMonsters.Length)]);
                        MonsterPrefab.transform.SetParent(grid.transform);
                        MonsterPrefab.transform.position = grid.transform.position;
                        Monsters[count] = MonsterPrefab;
                        count++;
                    }
                }
            }
            else if (_time.hourTen * 10 + _time.hour >= 18)
            {
                for (int i = 0; i < Random.Range(5, 8); i++)
                {
                    GameObject grid = itemsGrid.transform.GetChild(Random.Range(2, 38)).GetChild(Random.Range(5, 12)).gameObject;
                    if (grid.transform.childCount == 0)
                    {
                        GameObject MonsterPrefab = Instantiate<GameObject>(NightMonsters[Random.Range(0, NightMonsters.Length)]);
                        MonsterPrefab.transform.SetParent(grid.transform);
                        MonsterPrefab.transform.position = grid.transform.position;
                        Monsters[count] = MonsterPrefab;
                        count++;
                    }
                }
            }
        }
        else if(collider)
        {
            count = 0;
            Bounds bounds = collider.bounds;
            if (_time.hourTen * 10 + _time.hour < 6)
            {
                for (int i = 0; i < Random.Range(5, 10); i++)
                {
                    float x =RandomFloat(bounds.min.x, bounds.max.x);
                    float y = RandomFloat(bounds.min.y, bounds.max.y);
                    GameObject MonsterPrefab = Instantiate<GameObject>(MorningMonsters[Random.Range(0, MorningMonsters.Length)]);
                    MonsterPrefab.transform.SetParent(collider.gameObject.transform);
                    MonsterPrefab.transform.position = new Vector3(x, y, 0);
                    Monsters[count] = MonsterPrefab;
                    count++;
                }
            }
            else if (_time.hourTen * 10 + _time.hour >= 6 && _time.hourTen * 10 + _time.hour < 18)
            {
                for (int i = 0; i < Random.Range(5, 10); i++)
                {
                    float x = RandomFloat(bounds.min.x, bounds.max.x);
                    float y = RandomFloat(bounds.min.y, bounds.max.y);
                    GameObject MonsterPrefab = Instantiate<GameObject>(NoonMonsters[Random.Range(0, MorningMonsters.Length)]);
                    MonsterPrefab.transform.SetParent(collider.gameObject.transform);
                    MonsterPrefab.transform.position = new Vector3(x, y, 0);
                    Monsters[count] = MonsterPrefab;
                    count++;
                }
            }
            else if (_time.hourTen * 10 + _time.hour >= 18)
            {
                for (int i = 0; i < Random.Range(5, 10); i++)
                {
                    float x = RandomFloat(bounds.min.x, bounds.max.x);
                    float y = RandomFloat(bounds.min.y, bounds.max.y);
                    GameObject MonsterPrefab = Instantiate<GameObject>(NightMonsters[Random.Range(0, MorningMonsters.Length)]);
                    MonsterPrefab.transform.SetParent(collider.gameObject.transform);
                    MonsterPrefab.transform.position = new Vector3(x, y, 0);
                    Monsters[count] = MonsterPrefab;
                    count++;
                }
            }
        }

    }


    public void DeletMonsters()
    {
        if (itemsGrid)
        {
            if (count == 0) { return; }
            for (int i = 0; i < count; i++)
            {
                Destroy(Monsters[i]);
            }
        }
        else{
        for(int i = collider.gameObject.transform.childCount; i > 0; i--)
            {
                Destroy(collider.gameObject.transform.GetChild(i - 1).gameObject);
            }
        }

    }
    
}
