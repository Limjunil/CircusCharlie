using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //! 버튼을 누르면 게임이 꺼지는 함수
    public void OnExitButton()
    {
        GFunc.QuitThisGame();
    }
}
