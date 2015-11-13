using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float elapsedTime;
	private bool started;
	private float bestTime;

	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		started = false;
		bestTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (started) {
			elapsedTime += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (bestTime == 0 || elapsedTime < bestTime) {
				bestTime = elapsedTime;
			}
			elapsedTime = 0;
			started = true;
		}
	}

	void OnGUI() {
		int elapsedMinutes = Mathf.FloorToInt (elapsedTime / 60F);
		int elapsedSeconds = Mathf.FloorToInt (elapsedTime - elapsedMinutes * 60);
		string niceTime = string.Format ("{00:00}:{1:00}", elapsedMinutes, elapsedSeconds);
		GUI.contentColor = Color.black;
		GUIStyle style = new GUIStyle();
		style.fontSize = 40;
		GUI.Label ( new Rect (Screen.width/2 - 50, 20, 200, 200), niceTime, style);

		int bestMinutes = Mathf.FloorToInt (bestTime / 60F);
		int bestSeconds = Mathf.FloorToInt (bestTime - bestMinutes * 60);
		niceTime = string.Format ("{00:00}:{1:00}", bestMinutes, bestSeconds);
		GUI.contentColor = Color.black;
		style = new GUIStyle();
		style.fontSize = 20;
		GUI.Label ( new Rect (Screen.width/2 - 50, 60, 200, 200), "best: " + niceTime, style);
	}
}
