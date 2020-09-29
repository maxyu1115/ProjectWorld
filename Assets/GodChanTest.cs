using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodChanTest : MonoBehaviour {

	private Sprite[] frames6;
	private  float frameRate = 0.2f;

	private int index;

	private float timePast=0;

	private Image displayUI;

	void Start () {
		index = 0;

		displayUI = this.gameObject.GetComponent<Image> ();

		string tempPath="";
		frames6 = Resources.LoadAll<Sprite> ("XieShen/6/6");
		/*frames6 = new Sprite[30];
		for (int i = 0; i < 30; i++) {
			tempPath =  "XieShen/6/6/6_"+i;
			frames6 [i] = Resources.Load<Sprite> (tempPath);
		}*/
		InvokeRepeating ("XieShen6",0,0.2f);

	}

	/*void Update () {
		timePast += Time.deltaTime;
		if (timePast >= frameRate) {
			timePast = 0;
			index=(index+1)%frames6.Length;
			if (index!=0 && index!=27 && index != 23)
				displayUI.sprite = frames6 [index]; 
		}

	}*/

	void XieShen6(){
		index=(index+1)%frames6.Length;
		if (index!=0 && index!=27 && index != 23)
			displayUI.sprite = frames6 [index]; 
	}

}
