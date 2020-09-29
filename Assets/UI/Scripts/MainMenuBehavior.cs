using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {

    public void newGame()
    {
		//LoadSettings.loadSaveMode = false;
		try{
			Debug.LogError ("HEY");

			SceneManager.LoadScene("ExperimentalUI");
		}catch (Exception e){
			Debug.LogError ("hey");
		}
    }
	public void loadGame()
	{
		LoadSettings.loadSaveMode = true;
		SceneManager.LoadScene ("ExperimentalUI");
	}
	void quit()
    {
        Application.Quit();
    }
}
