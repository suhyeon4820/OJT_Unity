using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float timeToNextAnim;
    [SerializeField] private int numberOfAnim;
    private bool isAnim;
    int nextAnimNum;

    private bool isPlayerMove = false;
    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
    }

    void Start()
    {
        ResetIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerMove)
        {
            RandomPetAnim();
        }
        else
        {
            // 이동
        }
        
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
}
