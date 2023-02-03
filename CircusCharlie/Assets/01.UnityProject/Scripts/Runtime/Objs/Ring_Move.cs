using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ring_Move : MonoBehaviour
{
    // 링이 이동할 힘
    private float moveForce = default;

    // 점프 힘
    public float jumpForce = default;

    public bool upMove = false;

    public int jumpCnt = default;

    Vector3 moveVelocy = Vector3.zero;

    private Rigidbody2D ringRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        upMove = false;
        jumpCnt = 0;

        moveForce = 11f;

        jumpForce = 10.1f;

        moveVelocy = Vector3.zero;

        ringRigidbody = gameObject.GetComponentMust<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        moveVelocy = new Vector3(-0.1f, 0f, 0f);

        transform.position += moveVelocy * moveForce * Time.deltaTime;

        if(upMove == true)
        {
            if(jumpCnt == 0)
            {
                ringRigidbody.velocity = Vector2.zero;
                ringRigidbody.gravityScale = 1f;
                ringRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpCnt++;
            }
        }

    }

    //! 화면 밖으로 가면 꺼지게 하는 함수

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FalseDoIt")
        {
            gameObject.SetActive(false);

        }
        

        if(collision.tag == "Ground")
        {
            if(jumpCnt == 1)
            {
                ringRigidbody.gravityScale = 0;
                jumpCnt = 0;

                upMove = false;
            }


        }
    }


}
