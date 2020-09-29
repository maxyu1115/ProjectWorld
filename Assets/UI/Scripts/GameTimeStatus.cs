using System;
using UnityEngine;

public class GameTimeStatus : MonoBehaviour
{
	public static bool buttonPause;

	public static bool uiPause;

	public static bool fastForward;

	void Start()
	{
		buttonPause = false;
		uiPause = false;
		fastForward = false;
	}

	void Update()
	{
		if (buttonPause || uiPause) {
			Time.timeScale = 0;
		} else if (fastForward) {
			Time.timeScale = 2;
		} else {
			Time.timeScale = 1;
		}
	}

}

