using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button leaderboardButton;
    public Button exitButton;
    public Leaderboard leaderboard;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        leaderboardButton.onClick.AddListener(ShowLeaderboard);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowLeaderboard()
    {
        // Enable the Leaderboard script and display the leaderboard
        leaderboard.gameObject.SetActive(true);
        leaderboard.DisplayScores();
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        // Add your exit game logic here
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
