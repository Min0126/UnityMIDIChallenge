using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // private string currentKeyPressed;
    public static ScoreManager Instance { get; private set; }

    [SerializeField]
    private TMP_Text scoreText;

    public int totalScore;

    private void Start()
    {
        Instance = this;
        totalScore = 0;
    }

    private void Update()
    {
        scoreText.text = $"Score: {totalScore.ToString()}";
    }

    public void Hit(int score)
    {
        totalScore += score;

        // Instance.hitSfx.Play();
    }

    public void Miss()
    {
        totalScore += 0;
    }

    // void OnGUI()
    // {
    //     Event e = Event.current;
    //     if (e.isKey)
    //     {
    //         currentKeyPressed = e.keyCode.ToString();
    //     }
    //     currentKeyPressed = e.keyCode.ToString();
    //     Debug.Log (currentKeyPressed);
    // }

    // private void CheckNote(Vector3 notePos)
    // {
    //     if ((notePos.y< (noteIndicatorTransform.position.y + marginOfError)||notePos.y> (noteIndicatorTransform.position.y - marginOfError))
    //     {
    //         if (currentKeyPressed == other.name[0].ToString())
    //         {
    //             int noteScore = other.gameObject.GetComponent<Note>().noteScore;
    //             Hit (noteScore);
    //             Debug
    //                 .Log($"Player pressed {currentKeyPressed} on {other.name}");
    //             Destroy(other.gameObject);
    //         }
    //         else
    //         {
    //             Miss();
    //             Debug.Log($"Player miss");
    //         }
    //     }
    //     // if (other.gameObject.CompareTag("Note"))
    //     // {
    //     //     if (currentKeyPressed == other.name[0].ToString())
    //     //     {
    //     //         int noteScore = other.gameObject.GetComponent<Note>().noteScore;
    //     //         Hit (noteScore);
    //     //         Debug
    //     //             .Log($"Player pressed {currentKeyPressed} on {other.name}");
    //     //         Destroy(other.gameObject);
    //     //     }
    //     //     else
    //     //     {
    //     //         Miss();
    //     //         Debug.Log($"Player miss");
    //     //     }
    //     // }
    // }
    // public static ScoreManager Instance { get; private set; }

    // [SerializeField]
    // private AudioSource hitSfx;

    // [SerializeField]
    // private AudioSource missSfx;

    // [SerializeField]
    // private TMP_Text scoreText;

    // public int score;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     Instance = this;
    //     score = 0;
    // }

    // public void Hit()
    // {
    //     score += 1;
    //     Instance.hitSfx.Play();
    // }

    // public void Miss()
    // {
    //     score += 0;
    //     Instance.missSfx.Play();
    // }

    // // Update is called once per frame
    // private void Update()
    // {
    //     scoreText.text = score.ToString();
    // }
}
