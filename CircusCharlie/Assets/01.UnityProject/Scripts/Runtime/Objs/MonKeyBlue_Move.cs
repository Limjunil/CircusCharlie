using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonKeyBlue_Move : MonoBehaviour
{

    public GameObject monkeyBlue = default;
    Monkey_Move monkey_;

    // Start is called before the first frame update
    void Start()
    {

        monkey_ = monkeyBlue.GetComponentMust<Monkey_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            monkey_.upMove = true;
        }
    }
}
