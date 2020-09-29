using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using WPMF;

public class AdjustEBSize : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		RectTransform tempRect = GetComponent<RectTransform> ();
		float height = GameObject.Find ("NewTimePanel").GetComponent<RectTransform> ().rect.height;
		float x = GameObject.Find ("Canvas").GetComponent<RectTransform> ().lossyScale.x;
		float width = Screen.width/x - GameObject.Find ("NewTimePanel").GetComponent<RectTransform> ().rect.width
			- GameObject.Find ("NewWindow").GetComponent<RectTransform> ().rect.width+27;
		tempRect.sizeDelta = new Vector2 (width, height);


		RectTransform barRect = GameObject.Find ("FutureEnergyBar").GetComponent<RectTransform> ();
		float xRatio = tempRect.rect.width / barRect.rect.width;
		Debug.Log (xRatio);
		barRect.localScale = new Vector3 (xRatio, 1, 1);
		Debug.Log (barRect.localScale);
		GameObject.Find ("EnergyBar").GetComponent<RectTransform> ().localScale = new Vector3 (xRatio, 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

