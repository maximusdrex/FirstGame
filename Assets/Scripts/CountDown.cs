using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {
    public Text Counter = null;
    private float timer = 120f;

	void Update() {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        Counter.text = timer.ToString("0");
        if (timer <= 0)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        string P1Name = "Player one";
        string P2Name = "Player two";
        string tie = "tie";
        int P1Score = GameObject.Find("Scoreboard").GetComponent<ScoreboardControls>().GetP1Score();
        int P2Score = GameObject.Find("Scoreboard").GetComponent<ScoreboardControls>().GetP2Score();
        string winner;
        if (P1Score > P2Score)
        {
            winner = P1Name;
        }
        else if (P2Score > P1Score)
        {
            winner = P2Name;
        }
        else
        {
            winner = tie;
        }
        PlayerPrefs.SetString("winner", winner);
        Application.LoadLevel("Game Over");
    }
}
