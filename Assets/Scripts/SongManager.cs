using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance { get; private set; }

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float songDelayInSeconds;

    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;

    [SerializeField]
    private string midiFileLocation;

    public float noteTime; //time that note will be on screen

    public float noteSpawnY;

    [SerializeField]
    private float noteTapY;

    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;

    [SerializeField]
    private Lane[] lanes;

    private void Start()
    {
        Instance = this;
        ReadFromFile();
    }

    private void ReadFromFile()
    {
        midiFile =
            MidiFile
                .Read(Application.streamingAssetsPath + "/" + midiFileLocation);
        GetDataFromMidi();
    }

    private void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes)
        {
            lane.GetComponent<Lane>().SetTimeStamps(array);
        }

        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    private void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return (double) Instance.audioSource.timeSamples /
        Instance.audioSource.clip.frequency;
    }
}
