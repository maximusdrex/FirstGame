using UnityEngine;
using System.Collections;

public class DataHolder : MonoBehaviour {
    public string winner { get; set; }
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	

}
