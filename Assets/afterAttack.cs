using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class afterAttack : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Attack1")) {
            animator.SetBool("Attack1", false);    
        }
        if (stateInfo.IsName("Attack2"))
        {
            animator.SetBool("Attack2", false);
        }
        if (stateInfo.IsName("Attack3"))
        {
            animator.SetBool("Attack3", false);
        }
        if (stateInfo.IsName("Hurt"))
        {
            animator.SetBool("Hurt", false);
        }
        if (stateInfo.IsName("miss"))
        {
            animator.SetBool("Miss", false);
        }
        if (stateInfo.IsName("die"))
        {
            animator.SetBool("Die", false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("die"))
        {
            SceneManager.LoadScene("firstScene");
        }
   
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
