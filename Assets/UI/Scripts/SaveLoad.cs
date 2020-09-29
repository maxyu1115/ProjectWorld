using UnityEngine;
using System.Collections;
using WPMF;

public class SaveLoad : MonoBehaviour
{
	public void save(){
		WorldMap2D map = WorldMap2D.instance;
		map.saveGame ();
	}

}

