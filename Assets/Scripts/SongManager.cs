using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using MidiPlayerTK;
using UnityEngine;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance { get; private set; }

    // [SerializeField]
    // private AudioSource audioSource;
    // [SerializeField]
    // private float songDelayInSeconds;
    // public double marginOfError; // in seconds
    // public int inputDelayInMilliseconds;
    // [SerializeField]
    // private string midiFileLocation;
    // public float noteTime; //time that note will be on screen
    // public float noteSpawnY;
    // [SerializeField]
    // private float noteTapY;
    // public float noteDespawnY
    // {
    //     get
    //     {
    //         return noteTapY - (noteSpawnY - noteTapY);
    //     }
    // }
    // public static MidiFile midiFile;
    private MidiFilePlayer midiFilePlayer;

    [SerializeField]
    private List<GameObject> notePrefabs = new List<GameObject>();

    [SerializeField]
    private List<int> noteValues = new List<int>();

    [SerializeField]
    private Transform noteSpawnPosition;

    // [SerializeField]
    // private Lane[] lanes;
    private void Start()
    {
        Instance = this;
        midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        midiFilePlayer.OnEventNotesMidi.AddListener (NoteActions);
        // ReadFromFile();
    }

    public void NoteActions(List<MPTKEvent> mptkEvents)
    {
        foreach (MPTKEvent note in mptkEvents)
        {
            if (note.Command == MPTKCommand.NoteOn)
            {
                // if the note is being played
                int noteValue = note.Value; // get the note value

                string noteLabel = HelperNoteLabel.LabelFromMidi(noteValue); // get the note label
                SpawnNote (noteValue);
                // char noteOctave = noteLabel[1]; // get the octave of the note
                // GameObject octaveModel = GameObject.Find("octave" + noteOctave); // get the correct octave gameobject
                // float volume = note.Velocity; // get the note velocity

                // long duration = note.Duration; // get the note duration

                // Debug.Log($"note label : {noteLabel} note value : {noteValue}");
            }
        }
    }

    private void SpawnNote(int noteValue)
    {
        for (int i = 0; i < noteValues.Count; i++)
        {
            if (noteValue == noteValues[i])
            {
                Instantiate(notePrefabs[i],
                noteSpawnPosition.position,
                notePrefabs[i].transform.rotation);
            }
        }
    }
    // private void ReadFromFile()
    // {
    //     midiFile =
    //         MidiFile
    //             .Read(Application.streamingAssetsPath + "/" + midiFileLocation);
    //     GetDataFromMidi();
    // }

    // private void GetDataFromMidi()
    // {
    //     // var notes = midiFile.GetNotes();
    //     var notes = midiFile.Notes;
    //     var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
    //     notes.CopyTo(array, 0);

    //     foreach (var lane in lanes)
    //     {
    //         lane.GetComponent<Lane>().SetTimeStamps(array);
    //     }

    //     Invoke(nameof(StartSong), songDelayInSeconds);
    // }

    // private void StartSong()
    // {
    //     audioSource.Play();
    // }

    // public static double GetAudioSourceTime()
    // {
    //     return (double) Instance.audioSource.timeSamples /
    //     Instance.audioSource.clip.frequency;
    // }
}
