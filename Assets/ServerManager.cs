using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    private string conn_string = "";
    public async Task SaveScore(string playerName, int score)
    {
        Debug.Log(playerName + ": " + score);
        return;
    }
    public async Task<List<LeaderboardEntry>> LoadScores()
    {
        return new List<LeaderboardEntry>();
    }

    
}
public class LeaderboardEntry
{
    public string name;
    public int score;

    public LeaderboardEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

