using UnityEngine;
using System.Collections;

public class wheelSpinning : MonoBehaviour {
	Vector3 currentPosition;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Mathf.Abs(transform.position.z - currentPosition.z) > 0.01) ||
		    (Mathf.Abs(transform.position.x - currentPosition.x) > 0.01)||
		    (Mathf.Abs(transform.position.y - currentPosition.y) > 0.01))
		{ 
			if (Mathf.Abs(transform.position.z - currentPosition.z) >
			    Mathf.Abs(transform.position.x - currentPosition.x))
			{
				if	((transform.position.z - currentPosition.z) > 0.01)
					transform.Rotate (new Vector3 (0, -5, 0) );
				else 
					transform.Rotate (new Vector3 (0, 5, 0) );
			} else {
				if	((transform.position.x - currentPosition.x) > 0.01)
					transform.Rotate (new Vector3 (0, 5, 0) );
				else 
					transform.Rotate (new Vector3 (0, -5, 0) );
			}

		}
		currentPosition = transform.position;
	}


}
