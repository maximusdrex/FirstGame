using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Script : MonoBehaviour
{
    public Image Battery = null;
	public ParticleSystem particles = null;
	private float fuel = 100;
	private float Speed = 3;
	private float jumpHeight = 4;
    private bool wasJumping = false;
    private bool hasBall = false;

	// Use this for initialization
    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inWorldCheck();
        //keep player rotated correctly
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        HandleTouch();
    }

    protected void HandleTouch()
    {
        int numTouches = Input.touchCount;
		float movex = Input.GetAxis("Horizontal");
		float movey = Input.GetAxis("Vertical");
        
        for (int touchNum = 0; touchNum < numTouches; touchNum++)
        {
                Touch touch = Input.GetTouch(touchNum);

			if(touch.position.x < Screen.width / 2) 
			{
				continue;
			}

            if (touch.position.x > (Screen.width / 4) * 3)
            {
                movex = 1;
            }
            else if (touch.position.x >= Screen.width / 2 && touch.position.x <= (Screen.width / 4) * 3)
            {
                movex = -1;
            }

            if (fuelCheck() && touch.position.y > (Screen.height / 3) * 2 && touch.position.x >= Screen.height / 2)
            {
                particles.Play();
                movey = jumpHeight;
                fuel--;
                wasJumping = true;
            }
            else
            {
                //f signifies float
                fuel += 0.5f;
                particles.Stop();
                wasJumping = false;
            }
            //change vector
            rigidbody2D.velocity = new Vector2(movex * Speed, movey);
        }
    }

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

    private void inWorldCheck()
    {
        float playerStartY = 1.0f;
        float player2StartX = 4.5f;
        if (transform.position.y < -10)
        {
            transform.position = new Vector2(player2StartX, playerStartY);
        }
    }

    private void setBattery()
    {
        if (fuel > 83)
        {
            Sprite newSprite = Resources.Load<Sprite>("Full Battery");
            Battery.sprite = newSprite;
        }
        else if (fuel > 66)
        {
            Sprite newSprite = Resources.Load<Sprite>("83%");
            Battery.sprite = newSprite;
        }
        else
        {
            Sprite newSprite = Resources.Load<Sprite>("66%");
            Battery.sprite = newSprite;
        }
    }
}
