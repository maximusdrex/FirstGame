using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleTouch();
	}

    private void HandleTouch()
    {
        int numTouches = Input.touchCount;
        int speed = 2;
        int jumpHeight = 4;
        int movex, movey;
        if (numTouches < 2)
        {
            for (int touchNum = 0; touchNum < numTouches; touchNum++)
            {
                Touch touch = Input.GetTouch(touchNum);
                if (touch.position.x < Screen.width / 4)
                {
                    movex = -1;
                }
                else if (touch.position.x < Screen.width / 2 && touch.position.x >= Screen.width / 4)
                {
                    movex = 1;
                }
                else
                {
                    movex = 0;
                }

                if (touch.position.y > (Screen.height / 3) * 2 && touch.position.x < Screen.height / 2)
                {
                    movey = 1;
                }
                else
                {
                    movey = 0;
                }
                rigidbody2D.velocity = new Vector2(movex * speed, movey * jumpHeight);
            }
        }
    }
}
