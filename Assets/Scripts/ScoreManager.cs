using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    static int Score;
    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        Score = 0;
    }
    public static void Hit()
    {
        Score += 20;
        Debug.Log("score+20");
    }
    //public static void Miss()
   //{
     //   Score -= 1;
     //   Debug.Log("score-1");
  //  }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " +Score.ToString();
    }
}
