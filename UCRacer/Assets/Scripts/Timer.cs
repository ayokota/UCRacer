using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float elapsedTime;
	private bool started;

	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (started) {
			elapsedTime += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		elapsedTime = 0;
		started = true;
	}

	void OnGUI() {
		int minutes = Mathf.FloorToInt (elapsedTime / 60F);
		int seconds = Mathf.FloorToInt (elapsedTime - minutes * 60);
		string niceTime = string.Format ("{00:00}:{1:00}", minutes, seconds);
		GUI.contentColor = Color.black;
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		GUI.Label ( new Rect (Screen.width/2 - 50, 20, 200, 200), niceTime, style);
	}
}
