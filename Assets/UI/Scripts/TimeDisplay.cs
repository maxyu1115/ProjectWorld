using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class TimeDisplay : MonoBehaviour
{

	private Text monthText;
	private Text yearText;

	WorldMap2D map;


	void Start()
	{
		map = WorldMap2D.instance;


		monthText = GameObject.Find("Month").GetComponent<Text>();

		yearText = GameObject.Find("Year").GetComponent<Text>();
	}

	void Update()
	{
		yearText.text = map.worldYear + "/";
		if (map.worldMonth < 10) {
			monthText.text = "0" + map.worldMonth;
		} else {
			monthText.text = "" + map.worldMonth;
		}

	}


}


