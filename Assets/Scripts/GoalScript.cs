using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour
{
    public string EnemyPlayerName;
    void OnTriggerEnter2D(Collider2D other)
    {
        string ColliderName = other.gameObject.name;
        GameObject Enemy; 
        Enemy = GameObject.Find(EnemyPlayerName);
        if (ColliderName == EnemyPlayerName && Enemy.GetComponent<PlayerController2d>().HasBall)
        {
            Enemy.GetComponent<PlayerController2d>().LostBall();
            GameObject.Find("Ball").transform.position = new Vector2(0f, 1.5f);
            PlayerScores();
        }
    }

    private void PlayerScores()
    {
        if (EnemyPlayerName == "Player filler")
        {
            GameObject.Find("Scoreboard").GetComponent<ScoreboardControls>().P1Scores();
        }
        else
        {
            GameObject.Find("Scoreboard").GetComponent<ScoreboardControls>().P2Scores();
        }
    }
}
