using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ScoreManagerTest : MonoBehaviour
{
    [UnityTest]
    public IEnumerator ScoreManagerHitTest()
    {
        ScoreManager scoreManager = new ScoreManager();

        int startTotalScore = scoreManager.totalScore;
        int score = 20;
        scoreManager.Hit (score);

        yield return null;

        Assert.That(startTotalScore < scoreManager.totalScore);
    }
}
