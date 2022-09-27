using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class SongManagerTest
{
    [UnityTest]
    public IEnumerator SetKeyCanPressed()
    {
        GameObject midiGameObject = new GameObject();
        MidiFilePlayer midiFilePlayer =
            midiGameObject.AddComponent<MidiFilePlayer>();

        GameObject songManagerGameObject = new GameObject();
        SongManager songManager =
            songManagerGameObject.AddComponent<SongManager>();

        List<GameObject> notePrefabs = new List<GameObject>();

        List<KeyCode> keysCanPressed = new List<KeyCode>();

        var AnotePrefab =
            AssetDatabase
                .LoadAssetAtPath
                <GameObject>("Assets/Prefabs/Notes/ANote.prefab");

        notePrefabs.Add (AnotePrefab);

        songManager.SetKeyCanPressed (notePrefabs, keysCanPressed);

        yield return null;

        Assert.AreEqual(notePrefabs.Count, keysCanPressed.Count);
    }

    [UnityTest]
    public IEnumerator SpawnNoteTest()
    {
        GameObject midiGameObject = new GameObject();
        MidiFilePlayer midiFilePlayer =
            midiGameObject.AddComponent<MidiFilePlayer>();

        GameObject songManagerGameObject = new GameObject();
        SongManager songManager =
            songManagerGameObject.AddComponent<SongManager>();

        List<GameObject> notePrefabs = new List<GameObject>();

        List<Transform> lanes = new List<Transform>();
        GameObject lanePos = new GameObject();
        lanePos.transform.position = new Vector3(0, 0, 0);
        lanes.Add(lanePos.transform);

        var AnotePrefab =
            AssetDatabase
                .LoadAssetAtPath
                <GameObject>("Assets/Prefabs/Notes/ANote.prefab");

        notePrefabs.Add (AnotePrefab);

        var noteObjectsBefore = Object.FindObjectsOfType<Note>();

        songManager
            .SpawnNote(notePrefabs[0].GetComponent<Note>().noteValue,
            notePrefabs,
            lanes);

        yield return null;

        var noteObjectsAfter = Object.FindObjectsOfType<Note>();

        Assert.That(noteObjectsBefore.Length < noteObjectsAfter.Length);
    }
}
