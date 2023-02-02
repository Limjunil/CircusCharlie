using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Move : MonoBehaviour
{
    // 링이 이동할 힘
    private float moveForce = default;

    Vector3 moveVelocy = Vector3.zero;

    private Rigidbody2D ringRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        moveForce = 11f;

        moveVelocy = Vector3.zero;

        ringRigidbody = gameObject.GetComponentMust<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveVelocy = new Vector3(-0.1f, 0f, 0f);

        transform.position += moveVelocy * moveForce * Time.deltaTime;
    }

    //! 화면 밖으로 가면 꺼지게 하는 함수

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FalseDoIt")
        {
            gameObject.SetActive(false);

        }
    }

}
