using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int noteValue;

    public int noteScore = 20;

    public KeyCode noteKeyCode;

    private Vector3 spawnPos;

    private string currentKeyPressed;

    private KeyCode[] keyValues;

    [SerializeField]
    private int despawnOffset = 20;

    [SerializeField]
    private Vector3 noteIndicatorPos;

    [SerializeField]
    private float marginOfError = 1;

    void Start()
    {
        spawnPos = transform.position;
    }

    void Update()
    {
        CheckNote (noteIndicatorPos);

        transform
            .Translate(Vector3.left *
            SongManager.Instance.noteSpeed *
            SongManager.Instance.playerNoteSpeed *
            Time.deltaTime);
    }

    private void CheckNote(Vector3 noteIndicatorPos)
    {
        float distance = Mathf.Abs(noteIndicatorPos.y - transform.position.y);
        if (distance <= marginOfError)
        {
            foreach (KeyCode key in SongManager.Instance.currentKeyPressedList)
            {
                if (key == noteKeyCode)
                {
                    ScoreManager.Instance.Hit (noteScore);
                    Destroy (gameObject);
                }
            }
        }
        else
        {
            ScoreManager.Instance.Miss();
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
