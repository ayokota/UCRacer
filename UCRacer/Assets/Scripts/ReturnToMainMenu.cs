using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void loadscene()
	{
		Application.LoadLevel("menu"); // replace with post-login menu scene name
	}
}
