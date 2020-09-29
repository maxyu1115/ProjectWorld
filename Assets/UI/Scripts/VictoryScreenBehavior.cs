using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenBehavior : MonoBehaviour
{
	public GameObject daysText;
    public void Start()
    {
		Text box = daysText.GetComponent<Text>();
		box.text = "" + LoadSettings.victoryTime;
    }
    public void loadMainMenu()
	{
		SceneManager.LoadScene("Start Menu");
	}
	public void quit()
	{
		Application.Quit();
	}
}