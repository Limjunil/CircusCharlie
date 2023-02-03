using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnStageNext", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 다음 스테이지로 넘어가는 함수
    public void OnStageNext()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }
}
