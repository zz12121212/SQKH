using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    public Button[] Buttons;
    public GameObject Pet;
    public GameObject Monster;

    private Animator PetAnim;
    private Animator MonsterAnim;

    private static AttackController instance;
    private AttackController() { }
    public static AttackController getInstance() {
    if(instance == null)
        {
            instance = new AttackController();
        }
        return instance;
    }

    public void Turn() {
        //   for (int i = 0; i < Buttons.Length; i++) {
        //       Buttons[i].enabled = false;
        //  }
        PetAnim = Pet.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        StartCoroutine(PlayAnimWait(PetAnim));
        Monster.transform.GetChild(0).GetChild(0).GetComponent<Monster>().RandomAttack();
        StartCoroutine(PlayAnimWait(Monster.transform.GetChild(0).GetChild(0).GetComponent<Animator>()));
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].enabled = true;
        }
    }

    IEnumerator PlayAnimWait(Animator animator)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.normalizedTime < 1f)
        {
            yield return new WaitForEndOfFrame();
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        }
    }


}
