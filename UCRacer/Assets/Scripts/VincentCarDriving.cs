using UnityEngine;
using System.Collections;

public class VincentCarDriving : MonoBehaviour {
	
	public float accel;
	public float steer;
	public float brake;

	public WheelCollider FrontRight;
	public WheelCollider FrontLeft;
	public WheelCollider BackRight;
	public WheelCollider BackLeft;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float vert = Input.GetAxis ("Vertical") * accel;
		float hori = Input.GetAxis ("Horizontal") * steer;

		BackRight.motorTorque = vert;
		BackLeft.motorTorque = vert;

		FrontRight.steerAngle = hori;
		FrontLeft.steerAngle = hori;

		if(Input.GetKey(KeyCode.Space) ) {
			BackRight.brakeTorque = brake;
			BackLeft.brakeTorque = brake;
		}
		else {
			BackRight.brakeTorque = 0;
			BackLeft.brakeTorque = 0;
		}
	}
}