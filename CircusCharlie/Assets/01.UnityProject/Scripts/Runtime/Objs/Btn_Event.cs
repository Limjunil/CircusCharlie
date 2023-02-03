using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Event : MonoBehaviour
{
    GameObject Player = default;
    GameObject MainObjs = default;
    PlayerController playerController = default;


    // Start is called before the first frame update
    void Start()
    {
        GameObject GameObjs = GFunc.GetRootObj(GData.GAME_OBJS);

        MainObjs = GameObjs.FindChildObj(GData.MAIN_OBJS);
        Player = MainObjs.FindChildObj(GData.PLAYER_OBJS);

        playerController = Player.GetComponentMust<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! 왼쪽 방향 버튼을 눌렀을 때 발동하는 함수
    public void LeftBtnDown()
    {
        playerController.leftMove = true;
    }
    
    //! 왼쪽 방향 버튼을 땠을 때 발동하는 함수
    public void LeftBtnUp()
    {
        playerController.leftMove = false;
    }
    
    //! 오른쪽 방향 버튼을 눌렀을 때 발동하는 함수
    public void RightBtnDown()
    {
        playerController.rightMove = true;
    }

    //! 오른쪽 방향 버튼을 땠을 때 발동하는 함수
    public void RightBtnUp()
    {
        playerController.rightMove = false;
    }

    //! 점프 버튼을 눌렀을 때 발동하는 함
    public void UpBtnDown()
    {
        playerController.upMove = true;
    }

    //! 점프 버튼을 땠을 때 발동하는 함수
    public void UpBtnUp()
    {
        playerController.upMove = false;

    }
}
