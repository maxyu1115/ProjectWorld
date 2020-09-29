using UnityEngine;
using System.Collections;
using WPMF;

public class GodForm : MonoBehaviour
{
	Animator anim;
	WorldMap2D map;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		map = WorldMap2D.instance;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (map.tutorialMode)
			return;

		if (map.godChange) {
			map.godChange = false;
			anim.SetBool ("EvoStatus",true);
			anim.SetInteger ("Level", map.godForm);
		}

	}
}

