using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Event : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 화면 터치를 하면 발생
    public void OnTabScreen()
    {
        GFunc.LoadScene( GData.SCENE_NAME_TITLE);
    }
}
