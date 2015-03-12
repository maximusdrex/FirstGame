using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadWinner : MonoBehaviour {
    private Text WinnerBox;
	// Use this for initialization
	void Start () {
	    WinnerBox = GameObject.Find("WinnerText").GetComponent<Text>();
        WinnerBox.text = PlayerPrefs.GetString("winner");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
