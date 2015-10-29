using UnityEngine;
using System.Collections;

public class FlashBackLight : MonoBehaviour {
	Renderer rend = new MeshRenderer ();
	public Material lightOff;
	public Material lightOn;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material = lightOff;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.S)) {
			rend.material = lightOn;
		} else {
			rend.material = lightOff;
		}
	}
}
