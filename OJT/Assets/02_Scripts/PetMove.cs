using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    private float petRadius = 1f;
    // 애니메이션
    private Animator animator;
    private int numberOfAnim = 3;
    private bool isAnim;
    int nextAnimNum;

    GameObject targetPlayer;
    float moveSpeed = 2f;
    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
    }

    void Start()
    {
        ResetIdle();
    }

    public void SetPlayerObj(GameObject playr)
    {
        targetPlayer = playr;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceFromPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);
        //Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer <= 3f)
        {
            RandomPetAnim();
            animator.SetBool("Move", false);
        }
        else
        {
            // 이동
            animator.SetBool("Move", true);
            MovePet();
        }
    }
    void MovePet()
    {
        // 이동, 회전
        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, moveSpeed * Time.fixedDeltaTime);
        transform.LookAt(targetPlayer.transform);
    }

    void RandomPetAnim()
    {
        if (!isAnim)
        {
            // 현재 플레이 되고 있는 애니메이션의 진행 정도 - 0 ~ 1사이
            // blendtree라 계속 숫자가 카운트되고 있어 나머지로 계산해야함
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.02)
            {
                isAnim = true;
                nextAnimNum = Random.Range(1, numberOfAnim + 1);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }
        animator.SetFloat("PetRandomAnim", nextAnimNum, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        isAnim = false;
        nextAnimNum = 0;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, petRadius);
    }
}
