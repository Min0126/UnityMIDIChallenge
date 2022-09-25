using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MidiPlayerTK;
using TMPro;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance { get; private set; }

    public float noteSpeed; //the speed of note in the song

    public float playerNoteSpeed; //the note's speed that player want. Default equal song's speed

    public List<KeyCode> currentKeyPressedList = new List<KeyCode>();

    private MidiFilePlayer midiFilePlayer;

    [SerializeField]
    private List<KeyCode> keysCanPressed = new List<KeyCode>();

    [SerializeField]
    private List<AudioClip> buttonSounds = new List<AudioClip>();

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<GameObject> notePrefabs = new List<GameObject>();

    [SerializeField]
    private List<Transform> lanes = new List<Transform>();

    [SerializeField]
    private List<TMP_Text> keyText = new List<TMP_Text>();

    private void Start()
    {
        Instance = this;
        midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        midiFilePlayer.OnEventNotesMidi.AddListener (NoteActions);

        // set initial values
        playerNoteSpeed = midiFilePlayer.MPTK_Speed;
        SetKeyCanPressed();
    }

    private void SetKeyCanPressed()
    {
        foreach (GameObject note in notePrefabs)
        {
            keysCanPressed.Add(note.GetComponent<Note>().noteKeyCode);
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (!SongManager.Instance.currentKeyPressedList.Contains(e.keyCode))
            {
                SongManager.Instance.currentKeyPressedList.Add(e.keyCode);
                for (int i = 0; i < keysCanPressed.Count; i++)
                {
                    if (e.keyCode == keysCanPressed[i])
                    {
                        keyText[i].color = Color.black;
                        audioSource.clip = buttonSounds[i];
                        audioSource.Play();
                    }
                }
            }
        }
        if (e.type == EventType.KeyUp)
        {
            if (SongManager.Instance.currentKeyPressedList.Contains(e.keyCode))
            {
                SongManager.Instance.currentKeyPressedList.Remove(e.keyCode);
                for (int i = 0; i < keysCanPressed.Count; i++)
                {
                    if (e.keyCode == keysCanPressed[i])
                    {
                        keyText[i].color = Color.white;
                    }
                }
            }
        }
    }

    public void NoteActions(List<MPTKEvent> mptkEvents)
    {
        foreach (MPTKEvent note in mptkEvents)
        {
            if (note.Command == MPTKCommand.NoteOn)
            {
                int noteValue = note.Value; // get the note value

                noteSpeed = note.Velocity;

                SpawnNote (noteValue);
            }
        }
    }

    private void SpawnNote(int noteValue)
    {
        for (int i = 0; i < notePrefabs.Count; i++)
        {
            if (noteValue == notePrefabs[i].GetComponent<Note>().noteValue)
            {
                Instantiate(notePrefabs[i],
                lanes[i].position,
                notePrefabs[i].transform.rotation);
            }
        }
    }
}
