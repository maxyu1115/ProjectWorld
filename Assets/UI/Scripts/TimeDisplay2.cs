using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class TimeDisplay2 : MonoBehaviour
{

	private Text time;

	WorldMap2D map;


	void Start()
	{
		map = WorldMap2D.instance;


		time = GetComponent<Text>();
	}

	void Update()
	{
		time.text = map.worldYear + "/";
		if (map.worldMonth < 10) {
			time.text += "0" + map.worldMonth;
		} else {
			time.text += "" + map.worldMonth;
		}

	}


}


