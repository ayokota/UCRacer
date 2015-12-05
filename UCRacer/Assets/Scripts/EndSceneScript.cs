using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneScript : MonoBehaviour {

	public int Mins;
	public int Secs;

    private string updateURL = "http://shinray.webuda.com/update_scores.php"; // HORRIBLE SECURITY. If anyone finds this they can probably update anyone's hiscores if they have the correct info.
	private Storage stor;

	// Use this for initialization
	void Start () {
		stor = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();
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

        // TODO: upload hiscores to database
        updateHiscores(stor);
	}

    public void updateHiscores(Storage stor)
    {
        WWWForm form = new WWWForm();
        form.AddField("myform_hash", stor.hash); //fetch hash
        form.AddField("myform_nick", stor.username);
        form.AddField("myform_tracknum", stor.currTrack);
        form.AddField("myform_hiscore", stor.bestTime.ToString()); //just test this hopefully database accepts float
        //also apparently WWWForm doesn't have a float method so I'm going to send it as a string.

        WWW www = new WWW(updateURL,form);
        StartCoroutine(handleHiscores(www));
    }

    private IEnumerator handleHiscores(WWW www) //handler
    {
        yield return www; //yield puts this in another thread. prevents game from stalling while waiting.
        if (www.error == null)
        {
            Debug.Log("WaitForRequest OK: " + www.text);
            if (www.text.Contains("Success!")) // this is so bad
            {
                Debug.Log("Hiscores updated.");
            }
            else if (www.text.Contains("rejected")) // I can't believe I just did that
            {
                Debug.Log("Hiscores rejected.");
            }
            www.Dispose();
        }
        else
        {
            Debug.LogError("WaitForRequest ERROR: " + www.error);
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
