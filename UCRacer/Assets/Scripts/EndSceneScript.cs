using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneScript : MonoBehaviour {

	public int Mins;
	public int Secs;

	// Use this for initialization
	void Start () {
		Storage stor = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();
		Text t = GameObject.Find ("BestTime").GetComponent<Text>();

		Mins = Mathf.FloorToInt (stor.bestTime / 60F);
		Secs = Mathf.FloorToInt (stor.bestTime - Mins * 60F);
		string niceTime = string.Format ("{00:00}:{1:00}", Mins, Secs);

		t.text = "Your Best Time: " + niceTime;

		t = GameObject.Find ("Placing").GetComponent<Text> ();
		if (stor.beatAI == true) {
			t.text = "You Came In 1st Place!";
		} 
		else {
			t.text = "You Lost. What a Loser.";
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void loadscene()
	{
		Application.LoadLevel("menu"); // replace with post-login menu scene name
	}
}
