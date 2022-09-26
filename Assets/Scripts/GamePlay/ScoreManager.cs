using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour,IScoreManagerInterface
{
    public static ScoreManager Instance { get; private set; }

    public int totalScore;

    [SerializeField]
    public TMP_Text scoreText;

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
    }
}
