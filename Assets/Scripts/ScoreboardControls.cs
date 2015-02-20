using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardControls : MonoBehaviour {
    public Text Score = null;
    private int p2Score = 0;
    private int p1Score = 0;
    
    public void P1Scores()
    {
        p1Score++;
    }

    public void P2Scores()
    {
        p2Score++;
    }

    public int GetP2Score()
    {
        return p2Score;
    }

    public int GetP1Score() 
    {
        return p1Score;
    }

    void Update()
    {
        Score.text = p1Score.ToString() + " : " + p2Score.ToString();
    }
}
