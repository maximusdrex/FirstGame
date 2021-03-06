﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Script : PlayerController2d
{
    protected override void oneTouch(int TouchNum)
    {
        float YPosition = transform.position.y;
        float XPosition = transform.position.x;
		float movex = Input.GetAxis("Horizontal");
		float movey = Input.GetAxis("Vertical");
        Touch touch = Input.GetTouch(TouchNum);

	    if(touch.position.x < Screen.width / 2) 
		{
			return;
		}

        if (touch.position.x > (Screen.width / 4) * 3)
        {
            transform.position = new Vector2(XPosition + Speed, YPosition);
        }
        else if (touch.position.x >= Screen.width / 2 && touch.position.x <= (Screen.width / 4) * 3)
        {
            transform.position = new Vector2(XPosition - Speed, YPosition);
        }

        if (FuelCheck() && touch.position.y > (Screen.height / 3) * 2 && touch.position.x >= Screen.height / 2)
        {
            particles.Play();
            movey = JumpHeight;
            Fuel--;
            WasJumping = true;
        }
        else
        {
            particles.Stop();
            WasJumping = false;
        }
        //change vector
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
    }

    protected override void InWorldCheck()
    {
        float playerStartY = 1.0f;
        float player2StartX = 4.5f;
        if (transform.position.y < -10)
        {
            transform.position = new Vector2(player2StartX, playerStartY);
        }
    }
}