using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Script : MonoBehaviour {
    public Image Battery = null;
    //jetpack smoke
    public ParticleSystem particles = null;
    //players fuel
	private float fuel = 100;
    //handles the players animations
	public Animator anim = null;
	private float speed = 3;
	private float jumpHeight = 4;
    private bool wasJumping = false;
    private bool hasBall = false;

	// Use this for initialization
	void Start () {
        particles.Stop();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        inWorldCheck();
		HandleTouch();
        //keep player rotated correctly
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
		float movex = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(movex));
	}

    /// <summary>
    /// Handles touches.
    /// </summary>
    private void HandleTouch()
    {
        int numTouches = Input.touchCount;
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");

        for (int touchNum = 0; touchNum < numTouches; touchNum++)
        {                
            Touch touch = Input.GetTouch(touchNum);

            // If player touches on the left side of the screen
            if (touch.position.x > Screen.width / 2)
            {
                continue;
            }

            if (touch.position.x < Screen.width / 4)
            {
                movex = -1;
            }
            else if (touch.position.x < Screen.width / 2 && touch.position.x >= Screen.width / 4)
            {
                movex = 1;
            }

            if (fuelCheck() && touch.position.y > (Screen.height / 3) * 2 && touch.position.x < Screen.height / 2)
            {
                particles.Play();
                movey = jumpHeight;
				fuel--;
                wasJumping = true;
            } else 
            {
                particles.Stop();
                //f signifies float
				fuel += 0.5f;
                wasJumping = false;
			}

            //change vector
            rigidbody2D.velocity = new Vector2(movex * speed, movey);				
        }
    }
    //checks jetpack fuel
    private bool fuelCheck()
    {
        if (fuel >= 33 || (fuel >= 1 && wasJumping))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //checks to see if in world
    private void inWorldCheck()
    {
        float playerStartY = 1.0f;
        float player1StartX = -4.5f;
        if (transform.position.y < -10)
        {
            transform.position = new Vector2(player1StartX, playerStartY);
        }
    }

    void OnTriggerEnter(Collider other) 
    {        

        GameObject Ball; 
        Ball = GameObject.Find("Ball");
        GameObject obj = other.transform.parent.gameObject;
        if (obj.Equals(Ball))
        {
            return;
        }
        
    }

}
