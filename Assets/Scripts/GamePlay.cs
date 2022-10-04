using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
    public static GamePlay gameP;

    public float Tempo;

    bool Startsong = false;

    public TextMeshProUGUI ScoreText;

    public int Scorepoint;
    int currentScore;

    private void Awake()
    {
        gameP = this;
    }
    void Start()
    {
        currentScore = 0;
    }
    void Update()
    {
        ScoreText.text = "Score : " + currentScore.ToString();
  
        if (SongManager.GetAudioSourceTime() >= 12) {
            Startsong = true;
        }

        if (Startsong)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void NoteHit()
    {
        currentScore += Scorepoint;
    }
}
