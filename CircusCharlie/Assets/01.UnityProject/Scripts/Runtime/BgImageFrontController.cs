using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class BgImageFrontController : MonoBehaviour
{
    
    public bool leftMove2 = false;
    public bool rightMove2 = false;

    public GameObject bgImageFrontPrefab;
    public GameObject bgImageLastFrontPrefab;


    // 생성할 배경화면 배열
    private GameObject[] bgImage2 = default;
    private int bgImageCount2 = default;

    private Vector3 bgImagePosition2 = default;


    // Start is called before the first frame update
    void Start()
    {

        bgImageCount2 = 10;

        bgImagePosition2 = new Vector3(-2000f, 0f, 0f);


        bgImage2 = new GameObject[bgImageCount2];

        for (int i = 0; i < bgImageCount2-1; i++)
        {
            bgImage2[i] = Instantiate(bgImageFrontPrefab, bgImagePosition2, 
                Quaternion.identity, gameObject.transform);

            GameObject groundObj_ = bgImage2[i].FindChildObj("Ground");
        }

        bgImage2[bgImageCount2 - 1] = Instantiate(bgImageLastFrontPrefab,
            bgImagePosition2, Quaternion.identity, gameObject.transform);

        Vector3 bgImageLocalPos = new Vector3(-40f, -200f, 0f);

        for (int i = 0; i < bgImageCount2-1; i++)
        {
            bgImage2[i].transform.localPosition = bgImageLocalPos;

            bgImageLocalPos.x += 1279f;
        }

        bgImage2[bgImageCount2 - 1].transform.localPosition = bgImageLocalPos;




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
