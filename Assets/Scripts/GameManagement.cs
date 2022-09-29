using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement GameManagementInstance;
    private float delayStart;
    [SerializeField] private float delayReset;
    public static bool gameEnd;

    void Awake()
    {
        GameManagementInstance = this;
        gameEnd = false;
    }

    private void Start()
    {
        delayStart = SongManager.SongManagerInstance.GetSongDelayInSeconds() + 0.5f;
    }

    void Update()
    {
        CheckStateGame();
        InputCheck();
    }

    private void InputCheck()
    {
        if (gameEnd && delayReset >= 0)
        {
            delayReset -= Time.deltaTime;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void CheckStateGame()
    {
        if (delayStart >= 0)
        {
            delayStart -= Time.deltaTime;
            return;
        }
        
        if (!SongManager.SongManagerInstance.SongIsPlaying())
        {
            gameEnd = true;
        }
    }

    public bool GetGameEnd()
    {
        return gameEnd;
    }
}
