using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

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

    // 현재 보너스 점수를 표시할 텍스트
    private GameObject ScoreBonusTxtObj = default;

    GameObject gameClearTxtObj = default;

    // 현재 스테이지 값
    private float stageCnt = default;

    // 현재 보너스 초기 값
    private float bonusScore = default;

    // 점수 값
    private float score = default;


    // 체력
    private float hpCnt = default;

    // 게임 오버 상태 확인
    private bool isGameOver = false;

    // 스테이지를 깼는지 확인
    public bool isWinStage = false;

    // 체력을 깎아야하는지 확인하는 bool
    public bool isHpDown = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        stageCnt = 1f;
        hpCnt = 3f;
        bonusScore = 5000f;
        isGameOver = false;
        isHpDown = false;
        isWinStage = false;
        gameClearTxtObj = default;
        Time.timeScale = 1f;

        // { 출력할 텍스트 오브젝트를 찾는다.
        GameObject uiObjs_ = GFunc.GetRootObj("UiObjs");
        GameObject scoreBoard = uiObjs_.FindChildObj("ScoreBorad");
        GameObject scoreColor3 = scoreBoard.FindChildObj("ScoreColor3");

        gameOverTxtObj = uiObjs_.FindChildObj("GameOver");
        ScoreNowTxtObj = scoreColor3.FindChildObj("ScoreNow");
        ScoreHighTxtObj = scoreColor3.FindChildObj("ScoreHigh");
        HpNowTxtObj = scoreColor3.FindChildObj("HpNow");
        StageNowTxtObj = scoreColor3.FindChildObj("StageNow");
        ScoreBonusTxtObj = scoreColor3.FindChildObj("ScoreBonus");

        if(SceneManager.GetActiveScene().name == GData.SCENE_NAME_PLAY2)
        {
            gameClearTxtObj = uiObjs_.FindChildObj("GameClear");
            gameClearTxtObj.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);

        }

        // } 출력할 텍스트 오브젝트를 찾는다.

        gameOverTxtObj.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
        
        if(SceneManager.GetActiveScene().name == GData.SCENE_NAME_PLAY2)
        {
            score = PlayerPrefs.GetFloat("OneStageNowVal");
            
            SetScoreNowTxt();
        }
        else
        {
            SetScoreNowTxt();
        }

        SetHpCntTxt();

        if(SceneManager.GetActiveScene().name == GData.SCENE_NAME_LOAD2 ||
           SceneManager.GetActiveScene().name == GData.SCENE_NAME_PLAY2 )
        {
            PlusStageNow();
        }
        else
        {
            SetStageNowTxt();
        }

        SetScoreBonusTxt();

        // 최고 점수 초기화
        //PlayerPrefs.SetFloat("bestScore", 0);

        SetBestScoreTxt();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            UpdateBestScore();

            PlayerPrefs.SetFloat("OneStageNowVal", 0);
            gameOverTxtObj.transform.localScale = Vector3.one;
            Time.timeScale = 0f;
        }

        if(isWinStage == true)
        {
            UpdateBestScore();

            if (SceneManager.GetActiveScene().name == GData.SCENE_NAME_PLAY2)
            {
                PlayerPrefs.SetFloat("OneStageNowVal", 0);

                Invoke("OnEnd", 2f);

            }
            else
            {
                                
                Invoke("OnStageNext", 2f);
            }
        }

        if(isHpDown == true)
        {
            MinusHpCnt();

            isHpDown = false;
        }

        SetScoreNowTxt();

        Invoke("MinusBonus", 2f);

        

    }

    // 점수를 획득하는 함수 : Fire 링
    public void GetScoreFire()
    {
        score += 100;

        SetScoreNowTxt();
    }

    // 점수를 획득하는 함수 : Fire 병
    public void GetScoreBott()
    {
        score += 200;

        SetScoreNowTxt();
    }

    // 점수를 획득하는 함수 : Money
    public void GetScoreMoney()
    {
        score += 1000;

        SetScoreNowTxt();
    }

    public void SetScoreNowTxt()
    {
        PlayerPrefs.SetFloat("ScoreNow", score);

        float scoreVal = PlayerPrefs.GetFloat("ScoreNow");

        GFunc.SetTmpText(ScoreNowTxtObj, $"{scoreVal}");
    }

    // 피격 시 hp를 줄이는 함수
    public void MinusHpCnt()
    {
        hpCnt--;
        SetHpCntTxt();
    }

    public void SetHpCntTxt()
    {
        PlayerPrefs.SetFloat("hpCnt", hpCnt);

        float HpVal = PlayerPrefs.GetFloat("hpCnt");

        GFunc.SetTmpText(HpNowTxtObj, $"Hp : {HpVal}");

        if(hpCnt == 0)
        {
            isGameOver = true;
        }

    }

    // 스테이지 클리어 시, 다음 스테이지 표시하는 함수
    public void PlusStageNow()
    {
        stageCnt += 1f;
        SetStageNowTxt();
    }

    public void SetStageNowTxt()
    {
        PlayerPrefs.SetFloat("StageNow", stageCnt);

        float StageNowVal = PlayerPrefs.GetFloat("StageNow");

        GFunc.SetTmpText(StageNowTxtObj, $"stage-0{StageNowVal}");
            
    }


    // 보너스 점수를 표시할 함수

    private void MinusBonus()
    {
        CancelInvoke();
        if(bonusScore == 0) { return; }

        bonusScore -= 10;
        SetScoreBonusTxt();
    }

    public void SetScoreBonusTxt()
    {
        GFunc.SetTmpText(ScoreBonusTxtObj, $"Bonus - {bonusScore}");
    }


    // 최고 점수를 표시하는 함수
    public void UpdateBestScore()
    {
        float bestScoreNow = PlayerPrefs.GetFloat("bestScore");
        float scoreVal = PlayerPrefs.GetFloat("ScoreNow");

        //! 만약 다음 스테이지를 가게 되면 가져갈 전 스테이지 값
        PlayerPrefs.SetFloat("OneStageNowVal", bonusScore + scoreVal);

        if (isWinStage == true)
        {
            // 보너스 점수 가산
            scoreVal += bonusScore; 
        }

        if (bestScoreNow < scoreVal)
        {
            bestScoreNow = scoreVal;

            PlayerPrefs.SetFloat("bestScore", bestScoreNow);
        }

        SetBestScoreTxt();
    }


    public void SetBestScoreTxt()
    {
        float bestScoreNow = PlayerPrefs.GetFloat("bestScore");
        GFunc.SetTmpText(ScoreHighTxtObj, $"HI - {bestScoreNow}");
    }


    //! 다음 스테이지 로딩창 불러오기
    public void OnStageNext()
    {
        GFunc.LoadScene(GData.SCENE_NAME_LOAD2);
    }


    //! 게임 클리어 함수
    public void OnEnd()
    {
        gameClearTxtObj.transform.localScale = Vector3.one;
        Time.timeScale = 0f;
    }
}
