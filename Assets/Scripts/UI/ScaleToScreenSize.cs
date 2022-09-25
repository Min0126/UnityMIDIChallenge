using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToScreenSize : MonoBehaviour
{
    private float height;

    private float width;

    private float screenRatio;

    private Camera mainCamera;

    [SerializeField]
    private bool scaleOnlyWidth;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        height = mainCamera.orthographicSize * 2;
        width = height * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (!scaleOnlyWidth)
        {
            ScaleToScreen (width, height);
        }
        else
        {
            ScaleToScreen(width, transform.localScale.y);
        }
    }

    private void ScaleToScreen(float width, float height)
    {
        transform.localScale = new Vector3(width, height, 1);
    }
}
