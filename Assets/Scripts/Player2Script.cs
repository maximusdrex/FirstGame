using UnityEngine;
using System.Collections;

public class Player2Script : MonoBehaviour
{
	public float fuel = 100;
	public GameObject Player2Ground;
	public float Speed = 2;
	public float jumpHeight = 4;
	// Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

            if (TestGrounded() && touch.position.y > (Screen.height / 3) * 2 && touch.position.x >= Screen.height / 2)
            {
                movey = jumpHeight;
            }

            rigidbody2D.velocity = new Vector2(movex * Speed, movey);
        }
    }

    public bool TestGrounded()
    {
        bool isGrounded = false;
		isGrounded = Physics2D.Linecast(transform.position, Player2Ground.transform.position, 1 << LayerMask.NameToLayer("Platforms"));
		return isGrounded;
    }
}
