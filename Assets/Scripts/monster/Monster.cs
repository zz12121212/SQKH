using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public abstract class Monster : MonoBehaviour {

    [Header("填写数值")]
    public int TopLevel;
    public int MinLevel;
    public float Blood;
    public float MaxBlood;
    public int Attack1Multi;
    [Multiline(7)]
    public string Attack1Type;
    public int Attack2Multi;
    [Multiline(7)]
    public string Attack2Type;
    public int Attack3Multi;
    [Multiline(7)]
    public string Attack3Type;
    public int AgilityMulti;
    public Animator anim;
    public FightRecord record;
    public int prefabNum;
    public Text text;

    [Header("掉落物品")]
    public Items[] things = new Items[3];

    [Header("自由生成/外部设置")]
    public Monster Enemy;
    public float Level = 0;



    public abstract void Attack_1();
    public abstract void Attack_2();
    public abstract void Attack_3();

    public void RandomLevel() {
        Level = Random.Range(MinLevel, TopLevel);
        text.text = gameObject.name + "  Lv." + Level.ToString();
    }

    public void GetHurt(float HurtBlood)
    {
        Miss();
        Blood -= HurtBlood;
        if (gameObject.transform.parent.parent.name == "Pet")
        {
            GameObject.Find("blood").transform.GetChild(0).GetComponent<BloodBar>().ChangeFillCount(-HurtBlood / MaxBlood);
        }
        else if (gameObject.transform.parent.parent.name == "Enemy") { 
            GameObject.Find("EnemyBlood").transform.GetChild(0).GetComponent<BloodBar>().ChangeFillCount(-HurtBlood / MaxBlood);
        }
        IfDead();
        anim.SetBool("Hurt", true);
    }

    public System.Action RandomAttack() {
        int randomIndex = Random.Range(0, 3);
        //如果参数是整数（如 int），上限是不包含的（即最大生成 2）。 3.0 内的浮点数）。
        //如果参数是浮点数（如 float），上限是包含的（可能生成 3.0 内的浮点数）。
        switch (randomIndex)
        {
            case 0: return () => Attack_1();
            case 1: return () => Attack_2();
            case 2: return () => Attack_3();
            default: return () => Debug.LogError("Invalid attack index!");
        }//返回 Lambda 包装的方法，确保 this 正确。
    }

    public void Miss() {
        float Agility = Level * AgilityMulti;
        if (Agility > Enemy.Level * Enemy.AgilityMulti) {
            int a = Random.Range(0, 3);
            if (a == 0)
            {
                anim.SetBool("Miss", true);
                return;
            }
        }
    }

    public void GetHealed(int changeBlood) {
        if (Blood + changeBlood >= MaxBlood) { Blood = MaxBlood; }
        else { Blood += changeBlood; }
    }

    public void IfDead(){
        if (Blood <= 0) {
            Enemy.Level += Level / Enemy.Level;
            anim.SetBool("Die",true);
            return;
        }
    }

    public void SetLevel(float level) {
        if (level != 0) { 
            Level = level;
            int ShowLevel = (int)Level;
            gameObject.transform.parent.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = gameObject.name + "  Lv." + ShowLevel.ToString();
        }
        else { RandomLevel(); }
    }
}
