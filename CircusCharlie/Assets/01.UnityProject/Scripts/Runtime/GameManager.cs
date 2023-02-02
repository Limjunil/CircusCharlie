using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 게임 오버시 활성화할 텍스트 게임 오브젝트
    private GameObject gameOverTxtObj = default;

    // 실시간 따고 있는 점수를 표시할 텍스트
    private GameObject ScoreNowTxtObj = default;

    // 최고 점수를 표시할 텍스트
    private GameObject ScoreHighTxtObj = default;

    // 현재 체력을 표시할 텍스트
    private GameObject HpNowTxtObj = default;

    // 현재 스테이지를 표시할 텍스트
    private GameObject StageNowTxtObj = default;

    // 현재 스테이지 값
    private int stageCnt = default;


    // 점수 값
    private int score = default;

    // 체력
    private int hpCnt = default;

    // 게임 오버 상태 확인
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        stageCnt = 1;
        hpCnt = 3;
        isGameOver = false;

        // { 출력할 텍스트 오브젝트를 찾는다.
        GameObject uiObjs_ = GFunc.GetRootObj("UiObjs");
        GameObject scoreBoard = uiObjs_.FindChildObj("ScoreBorad");
        GameObject scoreColor3 = scoreBoard.FindChildObj("ScoreColor3");

        gameOverTxtObj = uiObjs_.FindChildObj("GameOver");
        ScoreNowTxtObj = scoreColor3.FindChildObj("ScoreNow");
        ScoreHighTxtObj = scoreColor3.FindChildObj("ScoreHigh");
        HpNowTxtObj = scoreColor3.FindChildObj("HpNow");
        StageNowTxtObj = scoreColor3.FindChildObj("StageNow");
        // } 출력할 텍스트 오브젝트를 찾는다.

        gameOverTxtObj.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        SetScoreNowTxt();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            
        }
    }

    // 점수를 획득하는 함수
    public void GetScore()
    {
        score += 100;

    }

    public void SetScoreNowTxt()
    {
        GFunc.SetTmpText(ScoreNowTxtObj, $"{score}");
    }
}
