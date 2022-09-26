using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class NoteTest
{
    [UnityTest]
    public IEnumerator NoteMoveTest()
    {
        GameObject gameObject = new GameObject();
        Note note = gameObject.AddComponent<Note>();

        GameObject midiGameObject = new GameObject();
        MidiFilePlayer midiFilePlayer =
            midiGameObject.AddComponent<MidiFilePlayer>();

        GameObject songManagerGameObject = new GameObject();
        SongManager songManager =
            songManagerGameObject.AddComponent<SongManager>();

        gameObject.transform.position = new Vector3(0, 0, 0);

        float noteSpeed = 80;
        float playerNoteSpeed = 0.2f;
        note.NoteMove (noteSpeed, playerNoteSpeed);

        yield return new WaitForSeconds(1);

        // note prefabs has been rotated.So move down equals move left
        Assert.That(gameObject.transform.position.x < 0);
    }

    [UnityTest]
    public IEnumerator ScoreManagerHitTest()
    {
        ScoreManager scoreManager = new ScoreManager();

        int startTotalScore = scoreManager.totalScore;
        int score = 20;
        scoreManager.Hit (score);

        yield return null;

        Assert.That(startTotalScore < scoreManager.totalScore);
    }

    [UnityTest]
    public IEnumerator CheckNoteTest()
    {
        GameObject gameObject = new GameObject();
        Note note = gameObject.AddComponent<Note>();

        var canvasPrefab =
            AssetDatabase
                .LoadAssetAtPath<GameObject>("Assets/Prefabs/Canvas.prefab");
        canvasPrefab = GameObject.Instantiate(canvasPrefab);

        GameObject scoreManagerGameObject = new GameObject();
        ScoreManager scoreManager = gameObject.AddComponent<ScoreManager>();
        scoreManager.scoreText =
            canvasPrefab.GetComponentInChildren<TMP_Text>();

        gameObject.transform.position = new Vector3(0, 0.5f, 0);
        Vector3 noteIndicatorPos = new Vector3(0, 1, 0);

        float marginOfError = 1;
        List<KeyCode> currentKeyPressedList = new List<KeyCode>();
        currentKeyPressedList.Add(KeyCode.A);
        KeyCode noteKeyCode = KeyCode.A;

        note.CheckNote (
            noteIndicatorPos,
            marginOfError,
            currentKeyPressedList,
            noteKeyCode
        );

        yield return new WaitForSeconds(1);

        Assert.That(scoreManager.totalScore > 0);
    }
}
