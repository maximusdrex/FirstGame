using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class PlayerController2d : MonoBehaviour {
    protected float Speed = 0.1f;
    //players fuel
    protected float Fuel = 100;
    protected float JumpHeight = 4;
    protected bool WasJumping = false;
    //fuel indicator
    public Text FuelPercentText = null;
    //jetpack smoke
    public ParticleSystem particles = null;
    public bool HasBall = false;

    // Use this for initialization
    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InWorldCheck();
        HandleTouch();
        if (!WasJumping && Fuel < 100)
        {
            particles.Stop();
            Fuel += 0.5f;
        }
        //keep player rotated correctly
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        KeepBall();
        float movex = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// Handles touches.
    /// </summary>
    protected void HandleTouch()
    {
        int numTouches = Input.touchCount;

        WasJumping = false;
        for (int touchNum = 0; touchNum < numTouches; touchNum++)
        {
            oneTouch(touchNum);
        }
    }
    //checks jetpack fuel
    protected bool FuelCheck()
    {
        if (Fuel >= 33 || (Fuel >= 1 && WasJumping))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //checks to see if in world
    protected abstract void InWorldCheck();

    void OnGUI() {
        FuelPercentText.text = Fuel.ToString("0") + "%";
    }

    public void PickUpBall()
    {
        Debug.Log("It Worked");
        GameObject Ball;
        Ball = GameObject.Find("Ball");
        Ball.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
        HasBall = true;
        if (this.name == "Player filler")
        {
            GameObject.Find("Player filler 2").GetComponent<PlayerController2d>().LostBall();
        }
        else
        {
            GameObject.Find("Player filler").GetComponent<PlayerController2d>().LostBall();

        }
    }

    protected void KeepBall()
    {
        if (HasBall)
        {
            GameObject Ball;
            Ball = GameObject.Find("Ball");
            Ball.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
        }
    }

    public void LostBall()
    {
        HasBall = false;
    }


    protected abstract void oneTouch(int TouchNum);
}
