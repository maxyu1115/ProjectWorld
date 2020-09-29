using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WPMF;

public class QuiteMonitor : MonoBehaviour {

    public bool quitFlag = false;
    public GameObject winMenu;


    private WorldMap2D map;

    private double countDown = 5;

	// Use this for initialization
	void Start () {
        map = WorldMap2D.instance;
	}
	
	// Update is called once per frame
	void Update () {
        if (map.winFlag)
        {
            quitFlag = true;
            winMenu.SetActive(true);
        }

        if (quitFlag)
        { 
            countDown -= Time.deltaTime;
        }

		if (countDown<=0)
        {
            // Application.Quit();
            LoadSettings.victoryTime = map.worldYear + "/" + map.worldMonth;
            SceneManager.LoadScene("Victory Screen");
        }

	}

    public void quitGame()
    {
        Application.Quit();
    }
}
