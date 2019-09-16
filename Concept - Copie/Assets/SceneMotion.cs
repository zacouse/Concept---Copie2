using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	public void GoToMainMenu() {
        SceneManager.LoadScene(0);
	}

    public void GoToLevelOne()
    {
        SceneManager.LoadScene(1);
    }
}
