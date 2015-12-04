using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour {

	public float bestTime = 0.0f;
	public string username = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
}
