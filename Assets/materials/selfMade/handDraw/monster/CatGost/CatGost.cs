using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatGost : Monster
{

    private void OnEnable()
    {
        SetLevel(Level);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        record.Enemy = prefabNum;
        record.EnemyLevel = Level;
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {

            SceneManager.LoadScene("SelectPets");
        }
    }

    public override void Attack_1()
    {
        anim.SetBool("Attack1", true);
        Enemy.GetHurt(Level * Attack1Multi);
    }
    public override void Attack_2()
    {
        anim.SetBool("Attack2", true);
        Enemy.GetHurt(Level * Attack2Multi);

    }
    public override void Attack_3()
    {
        anim.SetBool("Attack3", true);
        Enemy.GetHurt(Level * Attack3Multi);
    }






}