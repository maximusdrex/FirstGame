using UnityEngine;
using System.Collections;

public class ExitsWorld : MonoBehaviour {

    //When player falls
    void OnTriggerEnter(Collider other)
    {
		float player1StartX = -4.5f;
		float playerStartY = 1.0f;
		float player2StartX = 4.5f;

        GameObject obj = other.transform.parent.gameObject;

        if(obj.name == "Player filler") 
        {
            obj.transform.position = new Vector2(player1StartX, playerStartY);
        }
        else if (obj.name == "Player filler 2")
        {
            obj.transform.position = new Vector2(player2StartX, playerStartY);
        }

    }
}
