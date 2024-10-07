using System.Collections;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public ServerManager serverManager;
    public TextMeshProUGUI leaderboardText;

    void Start()
    {
        if (leaderboardText == null)
        {
            Debug.LogError("LeaderboardText is not assigned in the Unity Editor.");
            return;
        }
    }

    public async void DisplayScores()
    {
        if (serverManager == null)
        {
            Debug.LogError("ServerManager is not assigned in the Unity Editor.");
            return;
        }

        var leaderboardEntries = await serverManager.LoadScores();

        string leaderboardString = "";
        foreach (var entry in leaderboardEntries)
        {
            leaderboardString += entry.name + ": " + entry.score + "\n";
        }

        leaderboardText.text = leaderboardString;
    }


}
