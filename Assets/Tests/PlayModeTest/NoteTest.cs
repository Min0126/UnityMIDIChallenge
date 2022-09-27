using System.Collections;
using System.Collections.Generic;
using MidiPlayerTK;
using Moq;
using NUnit.Framework;
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
    public IEnumerator CheckNoteTest()
    {
        GameObject gameObject = new GameObject();
        Note note = gameObject.AddComponent<Note>();

        var scoreManagerMock = new Mock<IScoreManagerInterface>();
        scoreManagerMock.Setup(mock => mock.Hit(20));

        gameObject.transform.position = new Vector3(0, 0.5f, 0);
        Vector3 noteIndicatorPos = new Vector3(0, 1, 0);

        float marginOfError = 1;
        List<KeyCode> currentKeyPressedList = new List<KeyCode>();
        currentKeyPressedList.Add(KeyCode.A);
        KeyCode noteKeyCode = KeyCode.A;

        note
            .CheckNote(noteIndicatorPos,
            marginOfError,
            currentKeyPressedList,
            noteKeyCode,
            scoreManagerMock.Object);

        yield return null;

        Assert.That(gameObject == null);
    }
}
