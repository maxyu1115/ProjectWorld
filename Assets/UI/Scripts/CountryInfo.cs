using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;
using System.Text;

public class CountryInfo : MonoBehaviour
{

	public Sprite upTriangle;
	public Sprite downTriangle;

	public GameObject ErrorLog;
	public GameObject ErrorMessage;

	public GameObject LoadingScreen;

	private Color transparentColor = new Color (1f, 1f, 1f, 0f);
	private Color disabledColor = new Color (1f, 1f, 1f, 0.4f);

	private Color normalColor = new Color (1f, 1f, 1f, 1f);

	private enum displayMode
	{
		RoundedBasic = 0,
		ExactBasic = 1,
		DetailedBasic = 2,
		EventsList = 3,
		IconList = 4,
	}

	private enum clickMode
	{
		OnTouch = 0,
		OnClick = 1,
	}

	displayMode mode = displayMode.RoundedBasic;

	clickMode clickmode = clickMode.OnClick;

    
	private Text countryName;
	private Text box1;
	private Text box2;
	private Text box3;
	private Text box4;
	private Text box5;
	private Text box6;
	private Text box7;
	private Text box8;

	private Text modeText;


	RegionData data;
	int countryIndex;

	bool modeChange = true;
	bool[] boxChange = new bool[7];
	//true when there are changes
	bool indexChange = true;

	int[] triangleStatus = new int[7];
	int[] prevStatus = new int[7];
	RegionData prevData = new RegionData ();
	long prevPopulation;
	int prevIndex;


	Image[] triangles = new Image[7];



	public GameObject SArchive;
	private SpriteArchive archive;
	GameObject[] iconBoxs = new GameObject[16];
	GameObject[] icons = new GameObject[16];

	private bool[] iconStatus = new bool[16];
	private string[] prevGenerics = new string[3];

	private enum eventNumber {
		RiotGenre = 0,
		WarGenre = 1,
		FinancialGenre = 2,

		Plague = 3,
		TerroristAttack = 6,

		Volcano = 5,
		Tornado = 6,
		Earthquake = 7,

		Wildfire = 8,
		Frost = 9,
		Drought = 10,
		Flood = 11,

		Meteor = 12,
		TechnologyBreakThrough = 13,

	}



	WorldMap2D map;



	public void changeMode ()
	{
		mode = (displayMode)(((int)mode + 1) % 5);

		modeText.text = mode.ToString ();

		modeChange = true;
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Country Info start");
		countryName = GameObject.Find ("CountryName").GetComponent<Text> ();
		countryName.text = "P ";
		box1 = GameObject.Find ("Box1").GetComponent<Text> ();
		box1.text = "P ";
		box2 = GameObject.Find ("Box2").GetComponent<Text> ();
		box2.text = "G ";
		box3 = GameObject.Find ("Box3").GetComponent<Text> ();
		box3.text = "P ";
		box4 = GameObject.Find ("Box4").GetComponent<Text> ();
		box4.text = "G ";
		box5 = GameObject.Find ("Box5").GetComponent<Text> ();
		box5.text = "P ";
		box6 = GameObject.Find ("Box6").GetComponent<Text> ();
		box6.text = "G ";
		box7 = GameObject.Find ("Box7").GetComponent<Text> ();
		box7.text = "G ";
		box8 = GameObject.Find ("Box8").GetComponent<Text> ();
		box8.text = "";

		modeText = GameObject.Find ("ModeText").GetComponent<Text> ();
		modeText.text = mode.ToString ();


		triangles [0] = GameObject.Find ("Triangle1").GetComponent<Image> ();
		triangles [1] = GameObject.Find ("Triangle2").GetComponent<Image> ();
		triangles [2] = GameObject.Find ("Triangle3").GetComponent<Image> ();
		triangles [3] = GameObject.Find ("Triangle4").GetComponent<Image> ();
		triangles [4] = GameObject.Find ("Triangle5").GetComponent<Image> ();
		triangles [5] = GameObject.Find ("Triangle6").GetComponent<Image> ();
		triangles [6] = GameObject.Find ("Triangle7").GetComponent<Image> ();
		for (int i = 0; i < 7; i++) {
			setChangeBlank (triangles [i]);
		}



		archive = SArchive.GetComponent<SpriteArchive> ();

		for (int i = 0; i < 16; i++) {
			iconBoxs [i] = GameObject.Find ("IconBox" + (i + 1));
			icons[i] = GameObject.Find ("Icon" + (i + 1));

			iconStatus [i] = false;
		}
		icons [14].GetComponent<Image> ().color = transparentColor;
		icons [15].GetComponent<Image> ().color = transparentColor;

		prevGenerics [0] = "";
		prevGenerics [1] = "";
		prevGenerics [2] = "";



		map = WorldMap2D.instance;


		map.ErrorLog = ErrorLog;
		map.errorMessage = ErrorMessage.GetComponent<Text> ();
		ErrorLog.SetActive (false);

		LoadingScreen.SetActive (false);
		Debug.Log ("Country Info initialized");
	}

	// Update is called once per frame
	void Update ()
	{
		//icons [13].GetComponent<Image> ().sprite = archive.getSprite("Riot");

		//this.transform.position = Input.mousePosition;

		/*frameCountDown--;
        if (frameCountDown == 0)
        {
            count = count + 1;
            frameCountDown = 30;
        }*/


		if (map.countryLastClicked == -1 || map.isOnDrag) {
			clickmode = clickMode.OnTouch;
		} else {
			clickmode = clickMode.OnClick;
		}

		switch (clickmode) {

		case clickMode.OnClick:
			countryIndex = map.countryLastClicked;
			break;
		case clickMode.OnTouch:
			countryIndex = map.cursorCountryIndex;
			break;
		default:
			countryIndex = map.cursorCountryIndex;
			break;
		}


		if (countryIndex == -1) {
			countryName.text = LM.CNames.getString ("World");
			box1.text = LM.Texts.getString ("Population") + ": " + map.TotalPopulation;
			box2.text = "";
			box3.text = "";
			box4.text = "";
			box5.text = "";
			box6.text = "";
			box7.text = "";

			if (map.tutorialMode) {
				box8.text = "\nSurviving Countries: ";

			} else {
				if (WPMF.WorldMap2D.Cost.survivingCountries <= 10) {
				
					StringBuilder tempSB = new StringBuilder ();
					foreach (Country c in map.countries) {
						if (c.data.notEliminated) {
							tempSB.Append (LM.CNames.getString (c.name) + ", ");
						}
					}
					box8.text = "\nSurviving Countries: " + WPMF.WorldMap2D.Cost.survivingCountries + "\n" + tempSB.ToString ();

				} else {
					box8.text = "\nSurviving Countries: " + WPMF.WorldMap2D.Cost.survivingCountries;
				}
			}


		} else {
			data = map.countries [countryIndex].data;
			countryName.text = LM.CNames.getString (map.countries [countryIndex].name);


			if (data.notEliminated) {

				switch (mode) {
				default:
					box1.text = LM.Texts.getString ("Population") + ": " + data.population;
					box2.text = LM.Texts.getString ("GDP") + ": " + data.gdp;
					box3.text = LM.Texts.getString ("Technology") + ": " + System.Math.Floor (data.technology * 100) / 100.0;
					box4.text = LM.Texts.getString ("Resource") + ": " + System.Math.Floor (data.resource * 100) / 100.0;
					box5.text = LM.Texts.getString ("Religion") + ": " + System.Math.Floor (data.religion * 100) / 100.0;
					box6.text = LM.Texts.getString ("Cultist") + ": " + System.Math.Floor (data.cultist * 100) / 100.0;
					box7.text = LM.Texts.getString ("Unhappiness") + ": " + System.Math.Floor (data.calculateTotalUnhappiness () * 100) / 100.0;
					box8.text = "";
					break;
				case (displayMode.ExactBasic):
					box1.text = LM.Texts.getString ("Population") + ": " + data.population;
					box2.text = LM.Texts.getString ("GDP") + ": " + data.gdp;
					box3.text = LM.Texts.getString ("Technology") + ": " + System.Math.Floor (data.technology * 10000) / 10000.0;
					box4.text = LM.Texts.getString ("Resource") + ": " + System.Math.Floor (data.resource * 10000) / 10000.0;
					box5.text = LM.Texts.getString ("Religion") + ": " + System.Math.Floor (data.religion * 10000) / 10000.0;
					box6.text = LM.Texts.getString ("Cultist") + ": " + System.Math.Floor (data.cultist * 10000) / 10000.0;
					box7.text = LM.Texts.getString ("Unhappiness") + ": " + System.Math.Floor (data.calculateTotalUnhappiness () * 10000) / 10000.0;
					box8.text = "";
					break;
				case (displayMode.DetailedBasic):
					box1.text = "Growth Cultist: " + System.Math.Floor (data.growthCultist * 10000) / 10000.0;
					box2.text = "Extra Cultist: " + System.Math.Floor (data.extraCultist * 10000) / 10000.0;
					box3.text = "Population UH: " + System.Math.Floor (data.calculatePopulationUnhapiness () * 10000) / 10000.0;
					box4.text = "GDP UH: " + System.Math.Floor (data.calculateGDPUnhapiness () * 10000) / 10000.0;
					box5.text = "Resource UH: " + System.Math.Floor (data.calculateResourceUnhapiness () * 10000) / 10000.0;
					box6.text = "Technology UH: " + System.Math.Floor (data.calculateTechnologyUnhapiness () * 10000) / 10000.0;
					box7.text = "Religion UH: " + System.Math.Floor (data.calculateReligionUnhapiness () * 10000) / 10000.0;
					box8.text = "";
					break;
				case (displayMode.EventsList):
					StringBuilder temp1 = new StringBuilder ();
					foreach (string s in data.eventQueue) {
						temp1.Append (LM.Texts.getString (s)).Append (", ");
					}
						
					box1.text = "Events on going: ";
					box2.text = "";
					box3.text = "";
					box4.text = "";
					box5.text = "";
					box6.text = "";
					box7.text = "";
						
					box8.text = temp1.ToString ();

					break;
				case (displayMode.IconList):
					box1.text = "Events on going: ";
					box2.text = "";
					box3.text = "";
					box4.text = "";
					box5.text = "";
					box6.text = "";
					box7.text = "";
					box8.text = "";
					/*
					if (data.eventQueue.Count <= 16) {
						int i = 0;
						for (; i < data.eventQueue.Count; i++) {
							icons [i].GetComponent<Image> ().sprite = archive.getSprite (data.eventQueue [data.eventQueue.Count - 1 - i]);
						}
						for (; i < 16; i++) {
							icons [i].GetComponent<Image> ().sprite = null;
						}
					} else {
						for (int i = 0; i < 16; i++) {
							icons [i].GetComponent<Image> ().sprite = archive.getSprite (data.eventQueue [data.eventQueue.Count - 1 - i]);
						}

					}*/
					break;
				}

			} else {
				box1.text = "Population: " + data.population;
				box2.text = "";
				box3.text = "" + "ELIMINATED!";
				box4.text = "";

				box5.text = "";
				box6.text = "";
				box7.text = "";
				box8.text = "";
			}
		}


		/*if (Time.timeScale != 0) {
			UpdateTriangles ();
		}*/

	}

	void LateUpdate ()
	{
		if (Time.timeScale != 0 && !map.tutorialMode) {


			if (prevIndex == countryIndex) {
				indexChange = false;
			} else {
				indexChange = true;
			}
				
			updateOngoingIcons ();

			UpdateTriangles ();

			modeChange = false;
		}

	}


	#region drawing triangles

	private void UpdateTriangles ()
	{


		if (indexChange || modeChange) {
			for (int i = 0; i < 7; i++) {
				triangleStatus [i] = 0;
			}

		} else if (countryIndex == -1) {
			triangleStatus [0] = getChangeStatus (map.TotalPopulation, prevPopulation);
			for (int i = 1; i < 7; i++) {
				triangleStatus [i] = 0;
			}

		} else if (data.notEliminated) {
			switch (mode) {

			case displayMode.RoundedBasic:
			case displayMode.ExactBasic:
				triangleStatus [0] = getChangeStatus (data.population, prevData.population);
				triangleStatus [1] = getChangeStatus (data.gdp, prevData.gdp);
				triangleStatus [2] = getChangeStatus (data.technology, prevData.technology);
				triangleStatus [3] = getChangeStatus (data.resource, prevData.resource);
				triangleStatus [4] = getChangeStatus (data.religion, prevData.religion);
				triangleStatus [5] = getChangeStatus (data.cultist, prevData.cultist);
				triangleStatus [6] = getChangeStatus (data.calculateTotalUnhappiness (), prevData.calculateTotalUnhappiness ());
				break;
			case displayMode.EventsList:
			case displayMode.IconList:
				for (int i = 0; i < 7; i++) {
					triangleStatus [i] = 0;
				}
				break;
			case displayMode.DetailedBasic:
				triangleStatus [0] = getChangeStatus (data.growthCultist, prevData.growthCultist);
				triangleStatus [1] = getChangeStatus (data.extraCultist, prevData.extraCultist);
				triangleStatus [2] = getChangeStatus (data.calculatePopulationUnhapiness (), prevData.calculatePopulationUnhapiness ());
				triangleStatus [3] = getChangeStatus (data.calculateGDPUnhapiness (), prevData.calculateGDPUnhapiness ());
				triangleStatus [4] = getChangeStatus (data.calculateResourceUnhapiness (), prevData.calculateResourceUnhapiness ());
				triangleStatus [5] = getChangeStatus (data.calculateTechnologyUnhapiness (), prevData.calculateTechnologyUnhapiness ());
				triangleStatus [6] = getChangeStatus (data.calculateReligionUnhapiness (), prevData.calculateReligionUnhapiness ());
				break;
			default:
				break;
			}
		} else {
			for (int i = 0; i < 7; i++) {
				triangleStatus [i] = 0;
			}
		}
		checkChanges ();


		for (int i = 0; i < 7; i++) {
			if (!boxChange [i])
				continue;

			if (triangleStatus [i] == 1) {
				setChangeUp (triangles [i]);
			} else if (triangleStatus [i] == -1) {
				setChangeDown (triangles [i]);
			} else {
				setChangeBlank (triangles [i]);
			}
		}

		setPrevs ();

	
	}

	private void checkChanges ()
	{

		for (int i = 0; i < 7; i++) {
			boxChange [i] = !(triangleStatus [i] == prevStatus [i]);
		}
	}


	private int getChangeStatus (long current, long prev)
	{
		if (current > prev) {
			return 1;
		} else if (current < prev) {
			return -1;
		} else {
			return 0;
		}
	}

	private int getChangeStatus (double current, double prev)
	{
		if (current > prev) {
			return 1;
		} else if (current < prev) {
			return -1;
		} else {
			return 0;
		}
	}

	private int getChangeStatus (int current, int prev)
	{
		if (current > prev) {
			return 1;
		} else if (current < prev) {
			return -1;
		} else {
			return 0;
		}
	}

	private void setPrevs ()
	{
		for (int i = 0; i < 7; i++) {
			prevStatus [i] = triangleStatus [i];
		}
		prevIndex = countryIndex;
		if (countryIndex != -1)
			prevData.clone (data);
		prevPopulation = map.TotalPopulation;
	}

		

	private void setChangeBlank (Image t)
	{
		t.sprite = null;
		t.color = transparentColor;
	}

	private void setChangeUp (Image t)
	{
		t.sprite = upTriangle;
		t.color = normalColor;
	}

	private void setChangeDown (Image t)
	{
		t.sprite = downTriangle;
		t.color = normalColor;
	}

	#endregion

	#region event icons

	private void updateOngoingIcons ()
	{
		if (modeChange || indexChange) {
			if (mode == displayMode.IconList && countryIndex != -1) {
				//enable all icons
				for (int i = 0; i < 14; i++) {
					if ( data.genericQueue.Contains ( ((eventNumber)i).ToString () ) ) {
						icons [i].GetComponent<Image> ().color = normalColor;
						iconStatus [i] = true;
					} else {
						icons [i].GetComponent<Image> ().color = disabledColor;
						iconStatus [i] = false;
					}
					iconBoxs [i].GetComponent<HoldToDisplay> ().setName (((eventNumber)i).ToString ());
				}

				if (data.genericQueue.Contains ("RiotGenre")) {
					updateRiotGenre ();
				}
				if (data.genericQueue.Contains ("WarGenre")) {
					updateWarGenre ();
				}
				if (data.genericQueue.Contains ("FinancialGenre")) {
					updateFinancialGenre ();
				}

			} else {
				//disable icons
				for (int i = 0; i < 14; i++) {
					icons [i].GetComponent<Image> ().color = transparentColor;
					iconBoxs [i].GetComponent<HoldToDisplay> ().setName ("temp");
				}
				icons [0].GetComponent<Image> ().sprite = archive.getSprite("Riot");
				icons [1].GetComponent<Image> ().sprite = archive.getSprite("Skirmish");
				icons [2].GetComponent<Image> ().sprite = archive.getSprite("Inflation");

			}
		} else {
			//update each icon
			if (mode == displayMode.IconList && countryIndex != -1) {
				for (int i = 3; i < 14; i++) {
					if (iconStatus [i]) {
						//Icon i is enabled
						if (! data.genericQueue.Contains (((eventNumber)i).ToString ())) {
							icons [i].GetComponent<Image> ().color = disabledColor;
							iconStatus [i] = false; 
						}
					} else {
						//Icon i is disabled
						if (data.genericQueue.Contains (((eventNumber)i).ToString ())) {
							icons [i].GetComponent<Image> ().color = normalColor;
							iconStatus [i] = true; 
						}
					}
				}

				//Update RiotGenre
				if (iconStatus [0]) {
					//Icon i is enabled
					if (!data.genericQueue.Contains ("RiotGenre")) {
						icons [0].GetComponent<Image> ().sprite = archive.getSprite ("Riot");
						icons [0].GetComponent<Image> ().color = disabledColor;
						iconStatus [0] = false; 
					} else if (!data.eventQueue.Contains (prevGenerics [0])) {
						updateRiotGenre (); 
					}
				} else {
					//Icon i is disabled
					if (data.genericQueue.Contains ("RiotGenre")) {
						updateRiotGenre ();
						icons [0].GetComponent<Image> ().color = normalColor;
						iconStatus [0] = true; 
					}
				}

				//Update WarGenre
				if (iconStatus [1]) {
					//Icon i is enabled
					if (!data.genericQueue.Contains ("WarGenre")) {
						icons [1].GetComponent<Image> ().sprite = archive.getSprite ("Skirmish");
						icons [1].GetComponent<Image> ().color = disabledColor;
						iconStatus [1] = false; 
					} else if (!data.eventQueue.Contains (prevGenerics [1])) {
						updateWarGenre ();
					}
				} else {
					//Icon i is disabled
					if (data.genericQueue.Contains ("WarGenre")) {
						updateWarGenre ();
						icons [1].GetComponent<Image> ().color = normalColor;
						iconStatus [1] = true; 
					}
				}

				//Update FinancialGenre
				if (iconStatus [2]) {
					//Icon i is enabled
					if (!data.genericQueue.Contains ("FinancialGenre")) {
						icons [2].GetComponent<Image> ().sprite = archive.getSprite ("Inflation");
						icons [2].GetComponent<Image> ().color = disabledColor;
						iconStatus [2] = false; 
					} else if (!data.eventQueue.Contains (prevGenerics [2])) {
						updateFinancialGenre (); 
					}
				} else {
					//Icon i is disabled
					if (data.genericQueue.Contains ("FinancialGenre")) {
						updateFinancialGenre ();
						icons [2].GetComponent<Image> ().color = normalColor;
						iconStatus [2] = true; 
					}
				}


			}
		}
	}

	private void updateRiotGenre (){
		//must only be called when data.genericQueue.Contains ("RiotGenre") = true.

		if (data.eventQueue.Contains ("Riot")) {
			icons [0].GetComponent<Image> ().sprite = archive.getSprite ("Riot");
			prevGenerics [0] = "Riot"; 
		} else {
			icons [0].GetComponent<Image> ().sprite = archive.getSprite ("Rebellion");
			prevGenerics [0] = "Rebellion"; 
		}
	}

	private void updateWarGenre (){
		//must only be called when data.genericQueue.Contains ("WarGenre") = true.

		if (data.eventQueue.Contains ("Skirmish")) {
			icons [1].GetComponent<Image> ().sprite = archive.getSprite ("Skirmish");
			prevGenerics [1] = "Skirmish"; 
		} else if (data.eventQueue.Contains ("War")) {
			icons [1].GetComponent<Image> ().sprite = archive.getSprite ("War");
			prevGenerics [1] = "War"; 
		} else {
			icons [1].GetComponent<Image> ().sprite = archive.getSprite ("FullScaleWar");
			prevGenerics [1] = "FullScaleWar"; 
		}
	}

	private void updateFinancialGenre(){
		//must only be called when data.genericQueue.Contains ("FinancialGenre") = true.

		if (data.eventQueue.Contains ("Inflation")) {
			icons [2].GetComponent<Image> ().sprite = archive.getSprite ("Inflation");
			prevGenerics [2] = "Inflation";
		} else {
			icons [2].GetComponent<Image> ().sprite = archive.getSprite ("FinancialCrisis");
			prevGenerics [2] = "FinancialCrisis";
		}
	}

	#endregion


}
