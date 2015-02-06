using UnityEngine;
using System.Collections;

public class ExitsWorld : MonoBehaviour {

    //When player falls
    void OnTriggerEnter(Collider other)
    {
		float p1x = -4.5f;
		float py = 1.0f;
		float p2x = 4.5f;
        Vector2 spawnPoint1 = new Vector2(p1x, py);
        Vector2 spawnPoint2 = new Vector2(p2x, py);
        GameObject obj = other.transform.parent.gameObject;
        if(obj.name == "Player filler") 
        {
            obj.transform.position = spawnPoint1;
        }
        else if (obj.name == "Player filler 2")
        {
            obj.transform.position = spawnPoint2;
        }

    }
}
