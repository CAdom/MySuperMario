using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_JumpScence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenRegistUI()
    {
        SceneManager.LoadScene("UI_Register");
    }

    public void OpenLoginUI()
    {
        SceneManager.LoadScene("UI_Login");
    }
}
