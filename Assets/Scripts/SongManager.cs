using System.Collections;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    public static SongManager SongManagerInstance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private NoteLane[] noteLanes;
    [SerializeField] private float songDelayInSeconds;
    [SerializeField] private double marginOfError;
    [SerializeField] private float noteTime;
    [SerializeField] private float noteSpawnY;
    [SerializeField] private float noteTapY;
    private float noteDespawnY;
    [SerializeField] private int inputDelayinMilliseconds;

    [SerializeField] private string fileLocation;
    public static MidiFile midiFile;

    private void Awake()
    {
        SongManagerInstance = this;
    }

    void Start()
    {
        noteDespawnY = noteTapY - (noteSpawnY - noteTapY);
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }
    
    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                byte[] results = webRequest.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    
    private void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in noteLanes)
        {
            lane.SetTimeStamps(array);
        }

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    
    private void StartSong()
    {
        audioSource.Play();
    }
    
    public bool SongIsPlaying()
    {
        return audioSource.isPlaying;
    }
    
    public static double GetAudioSourceTime()
    {
        return (double)SongManagerInstance.audioSource.timeSamples / SongManagerInstance.audioSource.clip.frequency;
    }

    public double GetMarginOfError()
    {
        return marginOfError;
    }

    public int GetInputDelayTime()
    {
        return inputDelayinMilliseconds;
    }

    public float GetNoteTime()
    {
        return noteTime;
    }
    
    public float GetNoteSpawnY()
    {
        return noteSpawnY;
    }
    
    public float GetNoteDespawnY()
    {
        return noteDespawnY;
    }

    public float GetSongDelayInSeconds()
    {
        return songDelayInSeconds;
    }
    
}
