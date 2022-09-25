using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;

    // public KeyCode input;

    // public GameObject notePrefab;

    // private List<Note> notes = new List<Note>();

    // public List<double> timeStamps = new List<double>(); // time that player need to press the input key

    // private int spawnIndex = 0;

    // private int inputIndex = 0;

    // // Start is called before the first frame update
    // void Start()
    // {
    // }

    // public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    // {
    //     foreach (var note in array)
    //     {
    //         if (note.NoteName == noteRestriction)
    //         {
    //             var metricTimeSpan =
    //                 TimeConverter
    //                     .ConvertTo<MetricTimeSpan>(note.Time,
    //                     SongManager.midiFile.GetTempoMap());
    //             timeStamps
    //                 .Add((double) metricTimeSpan.Minutes * 60f +
    //                 (double) metricTimeSpan.Seconds +
    //                 (double) metricTimeSpan.Milliseconds / 1000f);
    //         }
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (spawnIndex < timeStamps.Count)
    //     {
    //         if (
    //             SongManager.GetAudioSourceTime() >=
    //             timeStamps[spawnIndex] - SongManager.Instance.noteTime
    //         )
    //         {
    //             var noteInstance = Instantiate(notePrefab, transform);
    //             notes.Add(noteInstance.GetComponent<Note>());

    //             noteInstance.GetComponent<Note>().assignedTime =
    //                 (float) timeStamps[spawnIndex];
    //             spawnIndex++;
    //         }
    //     }

    //     if (inputIndex < timeStamps.Count)
    //     {
    //         double timeStamp = timeStamps[inputIndex];
    //         double marginOfError = SongManager.Instance.marginOfError;
    //         double audioTime =
    //             SongManager.GetAudioSourceTime() -
    //             (SongManager.Instance.inputDelayInMilliseconds / 1000f);

    //         if (Input.GetKeyDown(input))
    //         {
    //             if ((audioTime - timeStamp) < marginOfError)
    //             {
    //                 Hit();
    //                 Debug.Log($"Player hit {inputIndex} note");
    //                 Destroy(notes[inputIndex].gameObject);
    //                 inputIndex++;
    //             }
    //             else
    //             {
    //                 Debug.Log($"Player Inaccurately Pressed on {inputIndex}!");
    //             }
    //         }
    //         if (timeStamp + marginOfError <= audioTime)
    //         {
    //             Miss();
    //             Debug.Log($"Player Miss the Note on {inputIndex}");
    //             inputIndex++;
    //         }
    //     }
    // }

    // private void Hit()
    // {
    //     ScoreManager.Instance.Hit();
    // }

    // private void Miss()
    // {
    //     ScoreManager.Instance.Miss();
    // }
}
