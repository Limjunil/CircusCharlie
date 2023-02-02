using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public bool isHit = false;
    public bool isWin = false;

    private int jumpChk = default;

    Vector3 moveVelocity = Vector3.zero;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 13f;
        moveForce = 50f;
        isGround = false;
        isRunning = false;
        isGameOver = false;
        leftMove = false;
        rightMove = false;
        upMove = false;
        isHit = false;
        isWin = false;
        jumpChk = 0;


        moveVelocity = Vector3.zero;

        playerRigidbody = gameObject.GetComponentMust<Rigidbody2D>();
        animator = gameObject.GetComponentMust<Animator>();
        gameManager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGameOver == true) { return; }

        if (isHit == true) { return; }

        if(leftMove == true)
        {
            moveVelocity = new Vector3(-0.1f, 0f, 0f);
            transform.position += moveVelocity * moveForce * Time.deltaTime;

            isRunning = true;
            animator.SetBool("Running", isRunning);
        }
        

        if(rightMove == true)
        {
            moveVelocity = new Vector3(0.1f, 0f, 0f);
            transform.position += moveVelocity * moveForce * Time.deltaTime;
            
            isRunning = true;
            animator.SetBool("Running", isRunning);

        }

        if(leftMove == false && rightMove == false)
        {
            isRunning = false;
            animator.SetBool("Running", isRunning);

        }

        if (upMove == true || Input.GetKeyDown(KeyCode.Q))
        {
            if(jumpChk == 0)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                isGround = true;
                jumpChk++;
                animator.SetBool("Ground", isGround);


            }

            if (jumpChk == 1)
            {
                return;
            }

        }

    }


    //! 피격되었을 때 발동하는 함수
    private void Hit()
    {
        isHit = false;

        RectTransform playerPos = GetComponent<RectTransform>();
        playerPos.anchoredPosition = new Vector3(200f, 400f, 0f);

        animator.SetTrigger("StartNow");
    }   // Hit()



    //! 불에 맞으면 발동
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RingFire")
        {
            if (isHit == true) { return; }

            animator.SetTrigger("Hit");
            isHit = true;
            gameManager.isHpDown = true;


            Invoke("Hit", 2f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Win"))
        {
            isWin = true;
            animator.SetBool("Win", isWin);
        }

        if(collision.collider.CompareTag("Ground"))
        {
            jumpChk = 0;
            isGround = false;
            animator.SetBool("Ground", isGround);
        }
    }



}
