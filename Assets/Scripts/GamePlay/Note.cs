using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Vector3 spawnPos;

    [SerializeField]
    private int despawnOffset = 20;

    [SerializeField]
    private Vector3 noteIndicatorPos;

    public int noteValue;

    private float timeSpawned;

    float timeElapsed;

    public int noteScore = 20;

    [SerializeField]
    private float marginOfError = 1;

    private string currentKeyPressed;

    private KeyCode[] keyValues;

    [SerializeField]
    private KeyCode noteKeyCode;

    // List<KeyCode> currentKeyPressedList = new List<KeyCode>();
    // public float assignedTime; // time that player suppose to tap the note
    // // Start is called before the first frame update
    void Start()
    {
        // timeSpawned = SongManager.Instance.audioTime;
        timeElapsed = 0;
        spawnPos = transform.position;
        // keyValues = (KeyCode[]) System.Enum.GetValues(typeof (KeyCode));

        // keys = new bool[keyValues.Length];
    }

    // // Update is called once per frame
    void Update()
    {
        CheckNote (noteIndicatorPos);

        transform
            .Translate(Vector3.left *
            SongManager.Instance.noteSpeed *
            SongManager.Instance.songSpeed *
            Time.deltaTime);
        //////////////////////////////////////////////////////
        // double timeSinceSpawned =
        //     SongManager.GetAudioSourceTime() - timeSpawned;
        // float timeRatio =
        //     ((float) timeSinceSpawned / (SongManager.Instance.noteTime * 2));
        // double timeSinceSpawned = SongManager.Instance.audioTime - timeSpawned;
        // float timeRatio =
        //     ((float) timeSinceSpawned / (SongManager.Instance.noteTime));
        //////////////////////////////////////////////////////////////////
        // timeElapsed = SongManager.Instance.audioTime - timeSpawned;
        // float timeRatio = timeElapsed / SongManager.Instance.noteTime;

        // Vector3 despawnPos =
        //     new Vector3(spawnPos.x, spawnPos.y - despawnOffset, spawnPos.z);

        // if (timeElapsed < SongManager.Instance.noteTime)
        // {
        //     transform.position +=
        //         Vector3
        //             .Lerp(Vector3.down * spawnPos.y,
        //             Vector3.down * despawnPos.y,
        //             timeRatio);

        // Debug.Log($"timeElapsed: {timeElapsed} name:{gameObject.name}");
        // timeElapsed += Time.deltaTime * SongManager.Instance.noteSpeed;
        // }
        // else
        // {
        //     Destroy (gameObject);
        // }

        // transform.position = Vector3.Lerp(spawnPos, despawnPos, timeRatio);
    }

    // void OnGUI()
    // {
    //     Event e = Event.current;
    //     if (e.type == EventType.KeyDown)
    //     {
    //         if (!SongManager.Instance.currentKeyPressedList.Contains(e.keyCode))
    //         {
    //             SongManager.Instance.currentKeyPressedList.Add(e.keyCode);
    //         }
    //         // foreach (KeyCode key in keyValues)
    //         // {
    //         //     if (e.keyCode == key && !currentKeyPressedList.Contains(key))
    //         //     {
    //         //         currentKeyPressedList.Add (key);
    //         //     }
    //         // }
    //     }
    //     if (e.type == EventType.KeyUp)
    //     {
    //         if (SongManager.Instance.currentKeyPressedList.Contains(e.keyCode))
    //         {
    //             SongManager.Instance.currentKeyPressedList.Remove(e.keyCode);
    //         }
    //         // foreach (KeyCode key in keyValues)
    //         // {
    //         //     if (e.keyCode == key && currentKeyPressedList.Contains(key))
    //         //     {
    //         //         currentKeyPressedList.Remove (key);
    //         //     }
    //         // }
    //     }
    // }
    // void OnGUI()
    // {
    //     Event e = Event.current;
    //     List<Event> keyPressed = new List<Event>();
    //     if (e.isKey)
    //     {
    //         keyPressed.Add(e);
    //         currentKeyPressed = e.keyCode.ToString();
    //     }
    //     currentKeyPressed = e.keyCode.ToString();
    //     Debug.Log (currentKeyPressed);
    // }
    private void CheckNote(Vector3 noteIndicatorPos)
    {
        float distance = Mathf.Abs(noteIndicatorPos.y - transform.position.y);
        if (distance <= marginOfError)
        {
            foreach (KeyCode key in SongManager.Instance.currentKeyPressedList)
            {
                if (key == noteKeyCode)
                {
                    // int noteScore = other.gameObject.GetComponent<Note>().noteScore;
                    // ScoreManager.Instance.totalScore += noteScore;
                    ScoreManager.Instance.Hit (noteScore);
                    Destroy (gameObject);

                    // Debug
                    //     .Log($"Player pressed {currentKeyPressed} on " +
                    //     gameObject.name);
                }
                // if (currentKeyPressed == gameObject.name[0].ToString())
                // {
                //     // int noteScore = other.gameObject.GetComponent<Note>().noteScore;
                //     // ScoreManager.Instance.totalScore += noteScore;
                //     ScoreManager.Instance.Hit (noteScore);
                //     Destroy (gameObject);

                //     // Debug
                //     //     .Log($"Player pressed {currentKeyPressed} on " +
                //     //     gameObject.name);
                //     return;
                // }
            }
        }
        else
        {
            ScoreManager.Instance.Miss();
            // Debug.Log($"Player miss");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DespawnLine"))
        {
            Destroy (gameObject);
        }
    }
}
