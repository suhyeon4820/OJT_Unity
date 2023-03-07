using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem playerInput;
    private CharacterController controller;

    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] Transform spawnWeaponTransform;

    private Animator animator;
    PoolingManager poolingManager;

    private void Awake()
    {
        playerInput = new InputSystem();
        controller = GetComponent<CharacterController>();

        animator = transform.GetChild(0).GetComponent<Animator>();
        poolingManager = GetComponent<PoolingManager>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }


    void Update()
    {
        PlayerMove();
        PlayerAttack();
        ReturnPlayerTransform();
    }

    public Vector3 ReturnPlayerTransform()
    {
        Vector3 playerTransform = transform.position;
        return playerTransform;
    }

    void PlayerMove()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 movementValue = new Vector3(movementInput.x, 0f, movementInput.y);
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(movementValue * Time.deltaTime * playerSpeed);

        if (movementValue != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            gameObject.transform.forward = movementValue;
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void PlayerAttack()
    {
        if(playerInput.Player.Attack.triggered)
        {
            // pooling
            StartCoroutine(Fire());
            animator.SetTrigger("Attack");
        }
        
    }
    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.5f);
        poolingManager.PoolingArrow();
    }
}
