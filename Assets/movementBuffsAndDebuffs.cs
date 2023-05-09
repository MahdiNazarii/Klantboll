using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBuffsAndDebuffs : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public float animationOgSpeed = 1.1F;
 
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        if (animator.GetBool("iceDebuff"))
        {
            animator.speed = 0;
            animator.transform.root.GetComponent<DefaultBehaviour>().enabled = false;
        }

       else if(animator.GetBool("slowDebuff"))
        {
            animator.speed = 0.45F;
            Debug.Log(animator.speed);
        }

        else
        {
           animator.speed = animationOgSpeed;
           animator.transform.root.GetComponent<DefaultBehaviour>().enabled = true;
           //Debug.Log(animator.speed);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
 
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
