using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class NoteTest
{
    [UnityTest]
    public IEnumerator NoteMove()
    {
        //*** When test have to comment Update() method ***
        // in real one have 3rd party library dependencies
        GameObject gameObject = new GameObject();
        Note note = gameObject.AddComponent<Note>();
        gameObject.transform.position = new Vector3(0, 0, 0);

        float noteSpeed = 80;
        float playerNoteSpeed = 0.2f;
        note.NoteMove (noteSpeed, playerNoteSpeed);

        yield return new WaitForSeconds(1);

        // note prefabs has been rotated.So move down equals move left
        Assert.That(gameObject.transform.position.x < 0);
    }

}
