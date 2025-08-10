using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordPlayer : MonoBehaviour
{
    public static recordPlayer Inst;
    public static int PlayerType;
    public static int PlayerBlood;
    public static int PlayerMagic;
    public static int PlayerEnergy;
    public static int Money;

    public  int playerEnergy;
    public int playerBlood;
    public int playerMagic;
    void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();

    }

    private void Update()
    {
        playerBlood = PlayerBlood;
        playerMagic = PlayerMagic;
        playerEnergy = PlayerEnergy;
    }
    public static void ChangeMoney(int money) {
        Money += money;
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("PlayerType", PlayerType);
        PlayerPrefs.SetInt("PlayerMagic", PlayerMagic);
        PlayerPrefs.SetInt("PlayerBlood", PlayerBlood);
        PlayerPrefs.SetInt("PlayerEnergy", PlayerEnergy);
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        PlayerType = PlayerPrefs.GetInt("PlayerType", 1);
        PlayerMagic = PlayerPrefs.GetInt("PlayerMagic", 100);
        PlayerBlood= PlayerPrefs.GetInt("PlayerBlood", 100);
        PlayerEnergy = PlayerPrefs.GetInt("PlayerEnergy",100);
        Money = PlayerPrefs.GetInt("Money", 100);
    }
}
