using UnityEngine;
using System.Collections;
using WPMF;

public class EventDisplayer : MonoBehaviour
{
	private WorldMap2D map;
	private Country target;
	public string targetName = "";

	//public GameObject SArchive;
	private SpriteArchive archive;

	public GameObject square1;
	public GameObject square2;
	public GameObject square3;
	public GameObject square4;
	public GameObject square5;
	public GameObject square6;

	private SpriteRenderer[] sprites;


	// Use this for initialization
	void Start ()
	{
		map = WorldMap2D.instance;

		sprites = new SpriteRenderer[6];
		sprites[0] = square1.GetComponent<SpriteRenderer> ();
		sprites[1] = square2.GetComponent<SpriteRenderer> ();
		sprites[2] = square3.GetComponent<SpriteRenderer> ();
		sprites[3] = square4.GetComponent<SpriteRenderer> ();
		sprites[4] = square5.GetComponent<SpriteRenderer> ();
		sprites[5] = square6.GetComponent<SpriteRenderer> ();
		//SArchive = 
		//archive = SArchive.GetComponent<SpriteArchive> ();
		archive = WorldMap2D.sArchive;
	}

	public void setTarget(Country c)
	{
		target = c;
		targetName = c.name;
	}

	// Update is called once per frame
	void Update ()
	{
		if (target == null) {
			target = targetName == null ? null : map.countries[map.GetCountryIndex(targetName)];
			return;
		}

		if (target.data.eventQueue.Count <= 6) {
			int i = 0;
			for (; i < target.data.eventQueue.Count; i++) {
				sprites [i].sprite = archive.getSprite (target.data.eventQueue [target.data.eventQueue.Count-1-i]);
			}
			for (; i < 6; i++) {
				sprites [i].sprite = null;
			}
		} else {
			for (int i=0; i < 6; i++) {
				sprites [i].sprite = archive.getSprite (target.data.eventQueue [target.data.eventQueue.Count - 1 - i]);
			}
			// ADD new ... icon
		}

	}
}

