using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float elapsedTime;
	private bool started;
	private float bestTime;
	private int currentLap;

	private int AICurrentLap;


	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		started = false;
		bestTime = 0;
		currentLap = 0;
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
			if(currentLap+1 > 3){
				//TODO Game over?
				loadscene ();
			}
			currentLap += 1;
		}

		if (other.tag == "AI") {

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

		string lap = "Lap " + currentLap + "/3";
		GUI.Label ( new Rect (50, 20, 200, 200), lap, style);

		int bestMinutes = Mathf.FloorToInt (bestTime / 60F);
		int bestSeconds = Mathf.FloorToInt (bestTime - bestMinutes * 60);
		niceTime = string.Format ("{00:00}:{1:00}", bestMinutes, bestSeconds);
		GUI.contentColor = Color.black;
		style = new GUIStyle();
		style.fontSize = 20;
		GUI.Label ( new Rect (Screen.width/2 - 50, 60, 200, 200), "best: " + niceTime, style);
	}

	public void loadscene()
	{
		Application.LoadLevel("End Scene"); // replace with name of any other scene
	}
}
