using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class BgImageController : MonoBehaviour
{
    
    public bool leftMove = false;
    public bool rightMove = false;

    public GameObject bgImagePrefab;
    public GameObject bgImageLastPrefab;


    // 생성할 배경화면 배열
    private GameObject[] bgImage = default;
    private int bgImageCount = default;

    private Vector3 bgImagePosition = default;

    private int meterVal = default;


    // Start is called before the first frame update
    void Start()
    {

        bgImageCount = 10;

        bgImagePosition = new Vector3(-2000f, 0f, 0f);

        meterVal = 90;

        bgImage = new GameObject[bgImageCount];

        for (int i = 0; i < bgImageCount-1; i++)
        {
            bgImage[i] = Instantiate(bgImagePrefab, bgImagePosition, 
                Quaternion.identity, gameObject.transform);

            GameObject groundObj_ = bgImage[i].FindChildObj("Ground");
            GameObject meterImageObj = groundObj_.FindChildObj("MeterImage");
            GameObject meterTxtObj = meterImageObj.FindChildObj("MeterTxt");

            GFunc.SetTmpText(meterTxtObj, $"{meterVal}");

            meterVal -= 10;
        }

        bgImage[bgImageCount - 1] = Instantiate(bgImageLastPrefab,
            bgImagePosition, Quaternion.identity, gameObject.transform);

        Vector3 bgImageLocalPos = new Vector3(-40f, -200f, 0f);

        for (int i = 0; i < bgImageCount-1; i++)
        {
            bgImage[i].transform.localPosition = bgImageLocalPos;

            bgImageLocalPos.x += 1279f;
        }

        bgImage[bgImageCount - 1].transform.localPosition = bgImageLocalPos;




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
