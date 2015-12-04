using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour {
    // SECRET
    public string hash = "736868697473736563726574"; //my secret value - also found in the php
    // Player info
	public float bestTime = 0.0f;
	public string username = "";
	public bool beatAI = true;
    // track info
    public string currTrack = "";
    public bool playWithAI = false;
    
    //enum trackName // tracks 1, 2, 3 respectively
    //{
    //    hiscore, hiscore2, hiscore3
    //}
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
