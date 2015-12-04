using UnityEngine;
using System.Collections;

public class VincentCarDriving : MonoBehaviour {
	
	public float torque;
	public float steer;
	public float brake;

	public WheelCollider FrontRight;
	public WheelCollider FrontLeft;
	public WheelCollider BackRight;
	public WheelCollider BackLeft;
	public float velocity;		//used to measure MPH

	private float SlipLimit = 100;
	private float CurrentTorque;
	private float Downforce = 100;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//AddDownForce();
		TractionControl();
		if(Input.GetKey(KeyCode.Space) ) {
			BackRight.brakeTorque = brake;
			BackLeft.brakeTorque = brake;
			FrontRight.brakeTorque = brake;
			FrontLeft.brakeTorque = brake;
		}
		else {
			BackRight.brakeTorque = 0;
			BackLeft.brakeTorque = 0;
			FrontLeft.brakeTorque = 0;
			FrontRight.brakeTorque = 0;
			//PC:
			float vert = Input.GetAxis ("Vertical") * CurrentTorque;
			float hori = Input.GetAxis ("Horizontal") * steer;
			
			//Android:
			//float vert = -Input.acceleration.z * CurrentTorque * 0.75f;
			//float hori = Input.acceleration.x * steer;
			
			
			BackRight.motorTorque = vert;
			BackLeft.motorTorque = vert;
			
			FrontRight.steerAngle = hori;
			FrontLeft.steerAngle = hori;
			//GetComponent<Rigidbody>().angularVelocity = new Vector3(GetComponent<Rigidbody>().angularVelocity.x, GetComponent<Rigidbody>().angularVelocity.y, 0);
			Vector3 rot = transform.rotation.eulerAngles;
			if(rot.z > 1 || rot.z < -359){
				rot.z = 0.0f;
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rot),0.8f);
			}
		}
		velocity = GetComponent<Rigidbody> ().velocity.magnitude * 2.23694f;
	}
	
	private void TractionControl()
	{
		WheelHit wheelHit;
		BackRight.GetGroundHit(out wheelHit);
		AdjustTorque(wheelHit.forwardSlip);

		BackLeft.GetGroundHit(out wheelHit);
		AdjustTorque(wheelHit.forwardSlip);
	}


	private void AdjustTorque(float forwardSlip)
	{
		if (forwardSlip >= SlipLimit && CurrentTorque >= 0)
		{
			CurrentTorque -= 20;
		}
		else
		{
			CurrentTorque += 20;
			if (CurrentTorque > torque)
			{
				CurrentTorque = torque;
			}
		}
	}

	private void AddDownForce()
	{
		FrontLeft.attachedRigidbody.AddForce(-transform.up*Downforce*FrontLeft.attachedRigidbody.velocity.magnitude);
		FrontRight.attachedRigidbody.AddForce(-transform.up*Downforce*FrontLeft.attachedRigidbody.velocity.magnitude);
		BackLeft.attachedRigidbody.AddForce(-transform.up*Downforce*FrontLeft.attachedRigidbody.velocity.magnitude);
		BackRight.attachedRigidbody.AddForce(-transform.up*Downforce*FrontLeft.attachedRigidbody.velocity.magnitude);
	}
}