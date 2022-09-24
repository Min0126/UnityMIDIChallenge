using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private string currentKeyPressed;

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            currentKeyPressed = e.keyCode.ToString();
            Debug.Log("Detected key code: " + e.keyCode.GetType());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            if (currentKeyPressed == other.name[0].ToString())
            {
                Debug
                    .Log($"Player pressed {currentKeyPressed} on {other.name}");
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log($"Player miss");
            }
        }
    }
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
