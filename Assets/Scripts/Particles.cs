using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {

	public string LayerName = "Particles";

	void Start () {
        particleSystem.renderer.sortingLayerName = LayerName;
	}

}
