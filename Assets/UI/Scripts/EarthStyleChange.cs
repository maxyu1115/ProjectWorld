using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class EarthStyleChange : MonoBehaviour {
	
	private WorldMap2D map; 

	private Text earthStyleText;


	void Start(){
		map = WorldMap2D.instance;

		earthStyleText = GameObject.Find ("EarthStyleText").GetComponent<Text> ();
		earthStyleText.text = "Change Map Style: " + map.earthStyle.ToString ();

	}

	public void changeEarthStyle(){
		map.earthStyle = (EARTH_STYLE)(((int)map.earthStyle + 1) % 9);
		earthStyleText.text = "Change Map Style: " + map.earthStyle.ToString ();
	}


}
