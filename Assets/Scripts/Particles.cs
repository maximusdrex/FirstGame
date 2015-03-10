using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {

	public string LayerName = "Particles";

	void Start () {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = LayerName;
	}

}
