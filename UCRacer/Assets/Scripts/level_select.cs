using UnityEngine;
using System.Collections;

public class level_select : MonoBehaviour {
    Storage stor = GameObject.FindGameObjectWithTag("Storage").GetComponent<Storage>();

	public void loadlevelOne() //"Main Scene"
    {
        stor.currTrack = "hiscore";
        stor.playWithAI = false;
        Application.LoadLevel("car_select");
    }

    public void loadlevelOneAi() // "Main Scene With AI"
    {
        stor.currTrack = "hiscore";
        stor.playWithAI = true;
        Application.LoadLevel("car_select");
    }

    public void loadlevelTwo() // "New Track 2"
    {
        stor.currTrack = "hiscore2";
        stor.playWithAI = false;
        Application.LoadLevel("car_select");
    }

    public void loadlevelTwoAi() // "New Track 2 With AI"
    {
        stor.currTrack = "hiscore2";
        stor.playWithAI = true;
        Application.LoadLevel("car_select");
    }

    public void loadlevelThree() // "New Track 3"
    {
        stor.currTrack = "hiscore3";
        stor.playWithAI = false;
        Application.LoadLevel("car_select");
    }

    public void loadlevelThreeAi() // "New Track 3 With AI"
    {
        stor.currTrack = "hiscore3";
        stor.playWithAI = true;
        Application.LoadLevel("car_select");
    }
}
