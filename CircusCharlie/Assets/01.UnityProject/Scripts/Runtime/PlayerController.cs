using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{

    // 플레이어가 피격시 나올 소리
    // public AudioClip

    // 플레이어의 점프 힘
    public float jumpForce = default;

    // 플레이어의 좌우 이동 힘
    public float moveForce = default;

    // 플레이어가 바닥에 닿았는지 확인
    private bool isGround = false;
    private bool isRunning = false;

    // 게임 오버 확인
    private bool isGameOver = false;

    public bool leftMove = false;
    public bool rightMove = false;
    public bool upMove = false;

    private int jumpChk = default;

    Vector3 moveVelocity = Vector3.zero;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 15f;
        moveForce = 50f;
        isGround = false;
        isRunning = false;
        isGameOver = false;
        leftMove = false;
        rightMove = false;
        upMove = false;
        jumpChk = 0;

        moveVelocity = Vector3.zero;

        playerRigidbody = gameObject.GetComponentMust<Rigidbody2D>();
        animator = gameObject.GetComponentMust<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true) { return; }

        if(leftMove == true)
        {
            moveVelocity = new Vector3(-0.1f, 0f, 0f);
            transform.position += moveVelocity * moveForce * Time.deltaTime;
            animator.SetBool("Running", isRunning);
        }

        if(rightMove == true)
        {
            moveVelocity = new Vector3(0.1f, 0f, 0f);
            transform.position += moveVelocity * moveForce * Time.deltaTime;
            animator.SetBool("Running", isRunning);

        }

        if(upMove == true)
        {
            if(jumpChk == 0)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                jumpChk++;
            }

            if(jumpChk == 1)
            {
                return;
            }

        }

    }


    //! 피격되었을 때 발동하는 함수
    private void Hit()
    {
    }   // Hit()

    //! 피격이 3번 되었을 때 게임을 끝내는 함수
    private void GameOverNow()
    {

    }   // GameOverNow()


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            jumpChk = 0;
            GFunc.Log("ssss");
        }
    }


}
