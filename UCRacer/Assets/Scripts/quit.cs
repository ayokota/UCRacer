using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
	
	//}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
    public void QuitClicked()
    {
        Quit();
    }

    public void Quit()
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
