using UnityEngine;

public class PauseAndContinue : MonoBehaviour
{
	//public bool gameActive;

	void Start()
	{
		//gameActive = true;
	}
	
	void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gameActive)
			{
				PauseGame();
			}
			else
			{
				ContinueGame();
			}
		}*/
	}
	public void PauseGame()
	{
		GameTimeStatus.buttonPause = true;
		//gameActive = false;
	}
	public void ContinueGame()
	{
		GameTimeStatus.buttonPause = false;
		//gameActive = true;
	}



}
