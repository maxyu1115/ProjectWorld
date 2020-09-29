using UnityEngine;
using UnityEngine.UI;
using WPMF;
using System.Collections.Generic;

public class AbilityDetail : MonoBehaviour
{
	public GameObject NameDisplay;
	public GameObject AdditionalDisplay;
	public GameObject Display1;
	public GameObject Display2;
	//Peter
	public GameObject Population_PositiveBar;
	public GameObject Population_NegativeBar;
	public GameObject PopulationBackgroundPositive;
	public GameObject PopulationBackgroundNegative;
	//

	private WorldMap2D map;
	private Text nameDisplay;
	private Text additionalDisplay;
	private Text display1;
	private Text display2;

	private string eventName="";
	//Peter 
	private Image population_Positivebar;
	private Image population_Negativebar;
	private	Image populationBackgroundPositive;
	private Image populationBackgroundNegative;
	//

	private Dictionary<string, EventDetail> details;

	EventDetail target;


	private bool firstTime = true; //OnEnable is ran before start, so we have to leave initiate this first

	void Init()
	{
		//Peter 
		/*
		population_Positivebar = Population_PositiveBar.GetComponent<Image> ();
		population_Positivebar.fillAmount=0;
		population_Negativebar = Population_NegativeBar.GetComponent<Image> ();
		population_Negativebar.fillAmount=0;
		populationBackgroundNegative = PopulationBackgroundNegative.GetComponent<Image> ();
		populationBackgroundNegative.fillAmount = 0;
		populationBackgroundPositive = PopulationBackgroundPositive.GetComponent<Image> ();
		populationBackgroundPositive.fillAmount = 0;
		*/
		//
		map = WorldMap2D.instance;
		nameDisplay = NameDisplay.GetComponent<Text> ();
		additionalDisplay = AdditionalDisplay.GetComponent<Text> ();
		display1 = Display1.GetComponent<Text> ();
		display2 = Display2.GetComponent<Text> ();
		details = new Dictionary<string, EventDetail>();
		details.Add ("RiotGenre", new EventDetail ("Riot / Rebellion" , 0, -1, -1, -2, 0, -1, -1, -1, -1, -2, 2, 1, "None"));
		details.Add ("WarGenre", new EventDetail ("Skirmish / War / Full-Scale War", -1, -3, 2, -3, -1, -2, -1, 2, 1, -1, 1, 3, "Worldwide"));
		details.Add ("FinancialGenre", new EventDetail ("Inflation / Financial Crisis", 0, -1, 1, -3, 0, -2, 0, -1, 1, -2, -1, 2, "None/Worldwide"));

		details.Add ("Plague", new EventDetail (-3, -3, -2, 2, -2, 3, "Neighbors"));
		details.Add ("TerroristAttack", new EventDetail (0, -1, 0, -2, 0, 2, "None"));

		details.Add ("Riot", new EventDetail (0, -1, 0, -1, -1, 2, "None"));
		details.Add ("Rebellion", new EventDetail (-1, -2, -1, -1, -2, 1, "None"));
		details.Add ("Skirmish", new EventDetail (-1, 2, -1, -1, 1, 1, "Worldwide"));
		details.Add ("War", new EventDetail (-1, -3, - 1, 1, 0, 2, "Worldwide"));
		details.Add ("FullScaleWar", new EventDetail (-3, -3, -2, 2, -1, 3, "Worldwide"));
		details.Add ("Inflation", new EventDetail (0, 1, 0, 0, 1, -1, "None"));
		details.Add ("FinancialCrisis", new EventDetail (-1, -3, -2, -1, -2, 2, "Worldwide"));


		details.Add ("Tornado", new EventDetail ("D", "A", "B"));
		details.Add ("Frost", new EventDetail ("A", "D", "E"));
		details.Add ("Wildfire", new EventDetail ("A", "D", "E"));
		details.Add ("Flood", new EventDetail ("C", "B", "C"));
		details.Add ("Drought", new EventDetail ("C", "B", "C"));
		details.Add ("Earthquake", new EventDetail ("B", "S", "B"));
		details.Add ("Volcano", new EventDetail ("A", "E", "A"));
		details.Add ("Meteor", new EventDetail ("SSS", "E", "SSS"));



		firstTime = false;

	
	}

	void OnEnable()
	{
		if (firstTime) {
			Init ();
		}

		if (!details.TryGetValue (eventName, out target)) {
			this.gameObject.SetActive (false);
			return;
		}

		//nameDisplay.text = target.EName + " - " + target.EType;
		nameDisplay.text = LM.Texts.getString(eventName);
		if (target.EType == "Human Event") {

			additionalDisplay.text = "";

			display1.text = "Population \n \t\t\t\t\t" + target.PopulationL +
				"\n GDP \n \t\t\t\t\t" + target.GdpL 
				+ "\nTechnology \n \t\t\t\t\t" + target.TechnologyL;
			display2.text = "Resource \n \t\t\t\t\t" + target.ResourceL 
				+ "\nReligion \n \t\t\t\t\t" + target.ReligionL 
				+ "\nCultist \n \t\t\t\t\t" + target.CultistL;

		} else if (target.EType == "Morphying Human Event") {
			//Peter
			/*
			populationBackgroundNegative.fillAmount = 1;
			populationBackgroundPositive.fillAmount = 1;
			if (target.PopulationL <= 0) {
				population_Negativebar.fillAmount = -(target.PopulationL / 3f);
			} else {
				population_Negativebar.fillAmount = (target.PopulationL / 3f);
			}
			if (target.PopulationH > 0) {
				population_Positivebar.fillAmount = (target.PopulationH / 3f);
			} else {
				population_Positivebar.fillAmount = -(target.PopulationH / 3f);
			}
			*/
			//

			additionalDisplay.text = target.VariationNames;
			display1.text = "Population \n \t" + target.PopulationL + " ~ " + target.PopulationH
				+ "\nGDP \n    " + target.GdpL + " ~ " + target.GdpH
				+ "\nTechnology \n    " + target.TechnologyL + " ~ " + target.TechnologyH;
			display2.text = "Resource \n    " + target.ResourceL + " ~ " + target.ResourceH
				+ "\nReligion \n    " + target.ReligionL  + " ~ " + target.ReligionH
				+ "\nCultist \n    " + target.CultistL + " ~ " + target.CultistH;

		} else if (target.EType == "Natural Event") {
			additionalDisplay.text = "";
			display1.text = " Normal Ranking \n \n Destruction on Vulnerable Countries\n \n Degree of Variation";
			display2.text = target.NormalRank + "\n \n" + target.BuffedRank + "\n \n \n" + target.VariationDegree;


		}
			





	}

	public void setName(string eName){
		eventName = eName;
	}

}
