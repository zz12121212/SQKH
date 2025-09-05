using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackRead : MonoBehaviour
{
    public Button[] buttons = new Button[3];
    //public System.Action[] actions;
    public FightRecord record;
    public MonsterList monster;
    public UnityEngine.Events.UnityAction[] actions = new UnityEngine.Events.UnityAction[3];
    public GameObject Pet, Enemy;
    GameObject enemy;
    private void Read() {
        buttons[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = monster.monsterList[record.Pet.PrefabNum].transform.GetChild(0).GetComponent<Monster>().Attack1Type;
        buttons[1].gameObject.transform.GetChild(0).GetComponent<Text>().text = monster.monsterList[record.Pet.PrefabNum].transform.GetChild(0).GetComponent<Monster>().Attack2Type;
        buttons[2].gameObject.transform.GetChild(0).GetComponent<Text>().text = monster.monsterList[record.Pet.PrefabNum].transform.GetChild(0).GetComponent<Monster>().Attack3Type;
    }

    public void ClickToRead() {
        enemy = Enemy.transform.GetChild(0).gameObject;
        GameObject pet = Pet.transform.GetChild(0).gameObject;
        enemy.transform.GetChild(0).GetComponent<Monster>().Enemy = pet.transform.GetChild(0).GetComponent<Monster>();
        pet.transform.GetChild(0).GetComponent<Monster>().Enemy = enemy.transform.GetChild(0).GetComponent<Monster>();

        actions[0] = () => pet.transform.GetChild(0).GetComponent<Monster>().Attack_1();
        actions[0] += () => Turn();
        actions[1] = () => pet.transform.GetChild(0).GetComponent<Monster>().Attack_2();
        actions[1] += () => Turn();
        actions[2] = () => pet.transform.GetChild(0).GetComponent<Monster>().Attack_3();
        actions[2] += () => Turn();
        for (int i = 0; i < 3; i++) {
            int a = i;
            buttons[a].onClick.RemoveAllListeners(); 
            buttons[a].onClick.AddListener(() => actions[a]?.Invoke());
        }
    Read();
    }

    public void Turn() {
        for (int i = 0; i < buttons.Length; i++)
        {
                 buttons[i].interactable = false;
        }
        //Animator PetAnim = Pet.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        //StartCoroutine(PlayAnimWait(PetAnim));
        //Enemy.transform.GetChild(0).GetChild(0).GetComponent<Monster>().RandomAttack();
        StartCoroutine(PlayAnimWait());

    }

    IEnumerator PlayAnimWait()
    {

        yield return new WaitForSeconds(1.5f);
        Enemy.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Monster>().RandomAttack().Invoke();
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }


    }

    IEnumerator PlayAnimWait(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1f)
        {
            yield return new WaitForFixedUpdate(); // µÈ´ý FixedUpdate ºó¼ÌÐø
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }
    }

}
