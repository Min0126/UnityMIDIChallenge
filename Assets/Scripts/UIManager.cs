using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject RestartText;
    public static int gameScore;

    private void Awake()
    {
        gameScore = 0;
    }

    public static void UpdateScore(int score)
    {
        gameScore += score;
    }

    private void Update()
    {
        scoreText.text = gameScore.ToString();
        ShowText();
    }

    public void ShowText()
    {
        if (GameManagement.GameManagementInstance.GetGameEnd())
        {
            RestartText.SetActive(true);
        }
    }
}
