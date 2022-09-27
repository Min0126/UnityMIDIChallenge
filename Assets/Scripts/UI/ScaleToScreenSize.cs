using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToScreenSize : MonoBehaviour
{
    public float height { get; private set; }

    public float width { get; private set; }

    [SerializeField]
    public bool scaleOnlyWidth;

    void Start()
    {
        Camera mainCamera = Camera.main;
        height = mainCamera.orthographicSize * 2;
        width = height * mainCamera.aspect;
    }

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

    public void ScaleToScreen(float width, float height)
    {
        transform.localScale = new Vector3(width, height, 1);
    }
}
