using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int numTouches = Input.touchCount;
        int Speed = 2;
        int movex, movey;
        if (numTouches < 2) 
        { 
            for (int touchNum = 0; touchNum < numTouches; touchNum++)
            {
                Touch touch = Input.GetTouch(touchNum);
                if (touch.position.x < Screen.width/4)
                {
                    movex = -1;
                    movey = 0;
                }
                else if(touch.position.x < Screen.width/2 && touch.position.x >= Screen.width/4)
                {
                    movex = 1;
                    movey = 0;
                }
                else
                {
                    movex = 0;
                    movey = 0;
                }
                rigidbody2D.velocity = new Vector2(movex * Speed, movey * Speed);
            }
        }
	}
}
