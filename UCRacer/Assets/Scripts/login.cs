using UnityEngine;
using System.Collections;

public class login : MonoBehaviour {
    public string username = "";
    private string password = "";
    private string loginURL = "http://shinray.webuda.com/check_scores.php"; // login url, ignore the fact it's called 'check_scores'
    private string registerURL = "http://shinray.webuda.com/create_account.php"; // register
    private string hash = "736868697473736563726574"; //my secret value - also found in the php

    public void getUser(string usrnm)
    {
        Debug.Log("Username: " + usrnm);
        username = usrnm;
    }
    public void getPwd(string pwd)
    {
        Debug.Log("Pass: " + pwd);
        password = pwd;
    }

    public void userLogin()
    {
        WWWForm form = new WWWForm(); //new form connection
        form.AddField("myform_hash", hash); // hash check
        form.AddField("myform_nick", username);
        form.AddField("myform_pass", password);
        WWW www = new WWW(loginURL, form); // send the form to the url
        StartCoroutine(handleLogin(www)); // send this off to the subroutine

        // username = "";
        password = ""; // clean variables(?) idk if this is what I do
    }

    private IEnumerator handleLogin(WWW www) // coroutine, runs in another thread so game doesn't hang while this is happening
    {
        yield return www; //yield ensures we don't hang while this processes
        if (www.error == null) //we gucci
        {
            Debug.Log("WaitForRequest OK: " + www.text);
            //Debug.Log(www.data); // just for debug purposes, dump data
            if (www.text.Contains("LOGADO - PASSWORD CORRECT"))
            {
                loadscene(); // login successful!
                www.Dispose(); // clears the form ingame
            }
        }
        else // we focken lostttt
        {
            Debug.LogError("WaitForRequest ERROR: " + www.error);
        }
    }

    public void userRegister()
    {
        WWWForm form = new WWWForm(); //new form connection
        form.AddField("myform_hash", hash); // hash check
        form.AddField("myform_nick", username);
        form.AddField("myform_pass", password);
        WWW www = new WWW(registerURL, form); // send the form to the url
        StartCoroutine(handleRegister(www)); // send this off to the subroutine

        // username = "";
       // password = ""; // clean variables(?) idk if this is what I do
    }

    private IEnumerator handleRegister(WWW www) // coroutine, runs in another thread so game doesn't hang while this is happening
    {
        yield return www; //yield ensures we don't hang while this processes
        if (www.error == null) //we gucci
        {
            Debug.Log("WaitForRequest OK: " + www.text);
            //Debug.Log(www.data); // just for debug purposes, dump data
            if (www.text.Contains("Success!"))
            {
                //loadscene(); // login successful!
                www.Dispose(); // clears the form ingame
            }
        }
        else // we focken lostttt
        {
            Debug.LogError("WaitForRequest ERROR: " + www.error);
        }
    }

    public void loadscene()
    {
        Application.LoadLevel("Main Scene"); // replace with name of any other scene
    }
}
