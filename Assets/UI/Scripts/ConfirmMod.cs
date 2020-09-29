using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class ConfirmMod : MonoBehaviour
{
	private WorldMap2D map;
	private Text warning;

	void Start()
	{
		map = WorldMap2D.instance;
		warning = GameObject.Find ("ConfirmModText").GetComponent<Text> ();

	}
	void Update()
	{
		map.lockDrag = true;
		GameTimeStatus.uiPause = true;

		warning.text = "Are you sure you want to initiate a " + map.modName
			+ " at " + LM.CNames.getString(map.countries[map.modTargetIndex].name) + "? ";
	}


	public void OkButton()
	{
		GameObject mod = Instantiate(Resources.Load("Prefabs/Mods/" + map.modName + "Mod", typeof(GameObject))) as GameObject;
		EventMod script = mod.GetComponent<EventMod> ();
		script.setTarget (map.countries [map.modTargetIndex]);

		map.modName = "";
		map.lockDrag = false;
		GameTimeStatus.uiPause = false;
		this.gameObject.SetActive (false);
	}
	public void CancelButton()
	{
		map.modName = "";
		map.lockDrag = false;
		GameTimeStatus.uiPause = false;

		this.gameObject.SetActive (false);
	}
}
