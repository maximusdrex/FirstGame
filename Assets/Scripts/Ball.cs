using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        obj.GetComponent<PlayerController2d>().PickUpBall();
    }
}
