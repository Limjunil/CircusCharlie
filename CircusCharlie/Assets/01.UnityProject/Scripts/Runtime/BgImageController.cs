using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BgImageController : MonoBehaviour
{
    
    public bool leftMove = false;
    public bool rightMove = false;

    public GameObject bgImagePrefab;

    // 생성할 배경화면 배열
    private GameObject[] bgImage = default;
    private int bgImageCount = default;

    private Vector3 bgImagePosition = default;

    // Start is called before the first frame update
    void Start()
    {

        bgImageCount = 5;

        bgImagePosition = new Vector3(-3000f, 0f, 0f);

        
        bgImage = new GameObject[bgImageCount];

        for (int i = 0; i < bgImageCount; i++)
        {
            bgImage[i] = Instantiate(bgImagePrefab, bgImagePosition, 
                Quaternion.identity, gameObject.transform);

        }

        Vector3 bgImageLocalPos = new Vector3(-2400f, -200f, 0f);

        for (int i = 0; i < bgImageCount; i++)
        {
            bgImage[i].transform.localPosition = bgImageLocalPos;

            bgImageLocalPos.x += 1200f;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
