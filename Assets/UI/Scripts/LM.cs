using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

//Language Manager
public class LM : MonoBehaviour
{

	enum Languages{
		English = 0,
		Chinese = 1
	}

	public static Lang Texts;

	public static Lang CNames;

	private Languages currentLanguage;

	// Use this for initialization
	void Start ()
	{
		currentLanguage = Languages.Chinese;

		//Texts = new Lang (Path.Combine (Application.persistentDataPath, "/test.xml"), currentLanguage.ToString(), false);
		Texts = new Lang ("test", currentLanguage.ToString(), false);
		//CNames = new Lang (Path.Combine (Application.persistentDataPath, "/CountryNames.xml"), currentLanguage.ToString(), false);
		CNames = new Lang ("CountryNames", currentLanguage.ToString(), false);

		updateLabels ();
	}


	public void changeLanguages(){
		
		currentLanguage = (Languages)((int)currentLanguage + 1);
		Texts = new Lang (Path.Combine (Application.persistentDataPath, "/test.xml"), currentLanguage.ToString(), false);
		CNames = new Lang (Path.Combine (Application.persistentDataPath, "/CountryNames.xml"), currentLanguage.ToString(), false);

		updateLabels ();
	}

	private void updateLabels (){
		
		GameObject[] labels = GameObject.FindGameObjectsWithTag ("UILabels");
		Text label;
		foreach (GameObject g in labels) {
			try{
				label = g.GetComponent<Text> ();
				label.text = LM.Texts.getString(g.name);

			}catch(Exception e){
				
			}
		}



	}
}

