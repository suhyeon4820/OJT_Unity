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
            // �̵�
        }
        
    }

    void RandomPetAnim()
    {
        if (!isAnim)
        {
            // ���� �÷��� �ǰ� �ִ� �ִϸ��̼��� ���� ���� - 0 ~ 1����
            // blendtree�� ��� ���ڰ� ī��Ʈ�ǰ� �־� �������� ����ؾ���
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
