using System;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Interaction;

public class NoteLane : MonoBehaviour
{
    [SerializeField] private ScriptableNote musicNote;
    
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private List<Note> noteLists = new List<Note>();
    [SerializeField] private List<double> timeStamps = new List<double>();
    
    private int spawnIndex;
    private int inputIndex;
    
    void Update()
    {
        SpawnNote();
        InputCheck();
    }
    
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == musicNote.GetNoteRestriction() && note.Octave == musicNote.GetOctaveNumber())
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    private void SpawnNote()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.SongManagerInstance.GetNoteTime())
            {
                var note = Instantiate(notePrefab, transform);
                Note noteComponent = note.GetComponent<Note>();
                noteLists.Add(noteComponent);
                noteComponent.AssignedValue(musicNote.GetColor(), (float)timeStamps[spawnIndex]);
                spawnIndex++;
            }
        }
    }
    
    private void InputCheck()
    {
        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.SongManagerInstance.GetMarginOfError();
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.SongManagerInstance.GetInputDelayTime() / 1000.0);

            if (Input.GetKeyDown(musicNote.GetKeyCode()))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    Destroy(noteLists[inputIndex].gameObject);
                    inputIndex++;
                }
            }

            if (timeStamp + marginOfError <= audioTime)
            {
                inputIndex++;
            }
        }
    }
    
    private void Hit()
    {
        UIManager.UpdateScore(musicNote.GetScorePoint());
    }
}
