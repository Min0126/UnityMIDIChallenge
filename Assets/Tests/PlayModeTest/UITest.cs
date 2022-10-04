using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class UITest
{
    [UnityTest]
    public IEnumerator WidthTest()
    {
        var mainCameraPrefab =
            AssetDatabase
                .LoadAssetAtPath
                <GameObject>("Assets/Prefabs/Main Camera.prefab");
        mainCameraPrefab = GameObject.Instantiate(mainCameraPrefab);
        Camera mainCamera = Camera.main;

        GameObject gameObject = new GameObject();
        ScaleToScreenSize scaleToScreenSize =
            gameObject.AddComponent<ScaleToScreenSize>();

        yield return null;

        Assert
            .AreEqual(mainCamera.orthographicSize * 2 * mainCamera.aspect,
            scaleToScreenSize.width);
    }

    [UnityTest]
    public IEnumerator HeightTest()
    {
        var mainCameraPrefab =
            AssetDatabase
                .LoadAssetAtPath
                <GameObject>("Assets/Prefabs/Main Camera.prefab");
        mainCameraPrefab = GameObject.Instantiate(mainCameraPrefab);
        Camera mainCamera = Camera.main;

        GameObject gameObject = new GameObject();
        ScaleToScreenSize scaleToScreenSize =
            gameObject.AddComponent<ScaleToScreenSize>();

        yield return null;

        Assert
            .AreEqual(mainCamera.orthographicSize * 2, scaleToScreenSize.height);
    }

    [UnityTest]
    public IEnumerator ScaleToScreenTest()
    {
        var mainCameraPrefab =
            AssetDatabase
                .LoadAssetAtPath
                <GameObject>("Assets/Prefabs/Main Camera.prefab");
        mainCameraPrefab = GameObject.Instantiate(mainCameraPrefab);

        GameObject gameObject = new GameObject();
        ScaleToScreenSize scaleToScreenSize =
            gameObject.AddComponent<ScaleToScreenSize>();

        scaleToScreenSize
            .ScaleToScreen(scaleToScreenSize.width, scaleToScreenSize.height);

        yield return null;

        Assert
            .That(gameObject.transform.localScale.x ==
            scaleToScreenSize.width &&
            gameObject.transform.localScale.y == scaleToScreenSize.height);
    }
}
