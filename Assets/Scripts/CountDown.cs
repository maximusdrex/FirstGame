using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {
    public Text Counter = null;
    private float timer = 120f;

	void Update() {
        timer -= Time.deltaTime;
        Counter.text = timer.ToString("0");
	}
}
