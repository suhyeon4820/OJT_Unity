using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRandomAnim : StateMachineBehaviour
{
    [SerializeField] private float timeToNextAnim;
    [SerializeField] private int numberOfAnim;
    private bool isAnim;
    private float idleTime;
    int nextAnimNum;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!isAnim)
        {
            idleTime += Time.deltaTime;
            if(idleTime > timeToNextAnim && stateInfo.normalizedTime%1<0.02f)
            {
                isAnim = true;
                nextAnimNum = Random.Range(1, numberOfAnim + 1);
            }
        }
        else if(stateInfo.normalizedTime % 1>0.98)
        {
            ResetIdle();
        }
        animator.SetFloat("PetRandomAnim", nextAnimNum, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        isAnim = false;
        idleTime = 0;
        nextAnimNum = 0;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
