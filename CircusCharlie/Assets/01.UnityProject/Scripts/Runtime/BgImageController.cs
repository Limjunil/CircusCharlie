using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgImageController : MonoBehaviour
{

    public bool leftMove = false;
    public bool rightMove = false;

    public GameObject[] bgImage = default;
    private int bgImageCount = default;

    // Start is called before the first frame update
    void Start()
    {

        bgImageCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
