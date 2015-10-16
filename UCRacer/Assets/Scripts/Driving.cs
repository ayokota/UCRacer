using UnityEngine;
using System.Collections;

public class Driving : MonoBehaviour {
	
	float speed = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W))
		{
			GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical") * (speed));
			
		}
		if (Input.GetKey (KeyCode.S))
		{
			GetComponent<Rigidbody>().AddRelativeForce ( Vector3.back * Input.GetAxis ("Vertical") * (-1) * (speed));
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.Rotate (new Vector3 (0, -1, 0) );
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.Rotate (new Vector3 (0, 1, 0) );;
		}
	}
}