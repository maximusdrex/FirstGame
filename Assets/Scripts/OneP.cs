using UnityEngine;
using System.Collections;

public class OneP : MonoBehaviour {

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
		int movex = 0;
		int movey = 0;

		if (numTouches < 2)
		{
			for (int touchNum = 0; touchNum < numTouches; touchNum++)
			{
				Touch touch = Input.GetTouch(touchNum);
				if (touch.position.x < Screen.width / 2)
				{
					movex = -1;
				}
				else if (touch.position.x >= Screen.width / 2)
				{
					movex = 1;
				}
				
				if (touch.position.y > (Screen.height / 3) * 2)
				{
					movey = 1;
				}

				if(touch.position.x < Screen.width / 2) {
					rigidbody2D.velocity = new Vector2(movex * speed, movey * jumpHeight);
				}
			}
		}
	}
}
