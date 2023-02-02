using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    private RectTransform playerRect = default;
    private float cameraPosX = default;

    void Update()
    {
        cameraPosX = Mathf.Clamp(playerRect.anchoredPosition.x - 200, 0, 4800);
        gameObject.GetComponentMust<RectTransform>().anchoredPosition = 
            new Vector2(cameraPosX, 0);
    }
}
