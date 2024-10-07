using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public SequenceManager sequenceManager;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public GameObject gameOverScreen;
    public TextMeshProUGUI totalScoreText;
    public ServerManager serverManager;
    public string playerName;
    public bool gameStarted = false;
    void Update()
    {
        if (!sequenceManager.IsPlayingSequence && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (gameStarted && Physics.Raycast(ray, out hit) && int.TryParse(hit.transform.name, out int index))
            {
                if (sequenceManager.CheckInput(index))
                {
                    score++;
                    scoreText.text = "Score: " + score;
                }
                else
                {
                    gameOverScreen.SetActive(true);
                    totalScoreText.text = "Total score: " + score;
                    serverManager.SaveScore(playerName, score).GetAwaiter();
                }
            }
        }
    }

    public void setPlayerName(TMP_InputField inputField)
    {
        playerName = inputField.text;
        gameStarted = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
