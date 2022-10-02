using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Interaction;
using System;
using TMPro;

public class LaneNote : MonoBehaviour
{
    //Note
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    [Range(1, 9)] public int noteRestrictionOctave;

    public KeyCode input;
    public GameObject notePrefab;

    public List<double> timeStamps = new List<double>();
    
    int spawnIndex = 0;
    int inputIndex = 0;

    //ButtonNote
    private SpriteRenderer SpriteRender;

    public Color colorNote;
    public float colorValue;

    public TextMeshProUGUI TextNote;
    private bool active = false;
    private GameObject note;


    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction && note.Octave == noteRestrictionOctave)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000);
            }
        }
    } 

    void Update()
    {

        //SpriteRender.color = colorNote;
        
        string textkey = input.ToString();
        TextNote.text = textkey;

        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTimetempo)
            { 
                Instantiate(notePrefab, transform);
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                StartCoroutine(toPressed());

                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {             
                    if (active)
                    {
                        GamePlay.gameP.NoteHit();
                        Destroy(note);
                    }
                    inputIndex++;
                }
                else
                {
                    //print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (Input.GetKeyUp(input))
            {

            }
            if (timeStamp + marginOfError <= audioTime)
            {
                inputIndex++;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
    IEnumerator toPressed()
    {
        TextNote.color = Color.black;

        SpriteRender.color = new Color(SpriteRender.color.r, SpriteRender.color.g - colorValue, SpriteRender.color.b);
        yield return new WaitForSeconds(0.1f);
        SpriteRender.color = colorNote;

        TextNote.color = Color.white;
    }
}
