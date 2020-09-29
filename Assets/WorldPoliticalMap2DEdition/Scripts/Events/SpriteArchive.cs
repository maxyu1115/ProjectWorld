using UnityEngine;
using System.Collections.Generic;

public class SpriteArchive : MonoBehaviour
{
	public Sprite Riot;
	public Sprite Rebellion;
	public Sprite Skirmish;
	public Sprite War;
	public Sprite FullScaleWar;
	public Sprite Inflation;
	public Sprite FinancialCrisis;
	public Sprite Plague;
	public Sprite TechnologyBreakThrough;
	public Sprite TerroristAttack;
	public Sprite Tornado;
	public Sprite Earthquake;
	public Sprite Wildfire;
	public Sprite Drought;
	public Sprite Flood;
	public Sprite Frost;
	public Sprite Meteor;
	public Sprite Volcano;

	private Dictionary<string, Sprite> catalog;


	//relative to 100*100 grid sizes
	private Dictionary<string, IconDisplayer> posCatalog;


	// Use this for initialization
	void Start ()
	{
		catalog = new Dictionary<string,Sprite> ();

		catalog.Add ("Riot", Riot);
		catalog.Add ("Rebellion", Rebellion);
		catalog.Add ("Skirmish", Skirmish);
		catalog.Add ("War", War);
		catalog.Add ("FullScaleWar", FullScaleWar);
		catalog.Add ("Inflation", Inflation);
		catalog.Add ("FinancialCrisis", FinancialCrisis);
		catalog.Add ("Plague", Plague);
		catalog.Add ("TechnologyBreakThrough", TechnologyBreakThrough);
		catalog.Add ("TerroristAttack", TerroristAttack);
		catalog.Add ("Tornado", Tornado);
		catalog.Add ("Earthquake", Earthquake);
		catalog.Add ("Wildfire", Wildfire);
		catalog.Add ("Drought", Drought);
		catalog.Add ("Flood", Flood);
		catalog.Add ("Frost", Frost);
		catalog.Add ("Meteor", Meteor);
		catalog.Add ("Volcano", Volcano);


		posCatalog = new Dictionary<string,IconDisplayer> ();

		posCatalog.Add ("Riot", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Rebellion", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Skirmish", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("War", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("FullScaleWar", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Inflation", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("FinancialCrisis", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Plague", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("TechnologyBreakThrough", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("TerroristAttack", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Tornado", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Earthquake", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Wildfire", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Drought", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Flood", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Frost", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Meteor", new IconDisplayer(0,0,1,1));
		posCatalog.Add ("Volcano", new IconDisplayer(0,0,1,1));
	}

	public Sprite getSprite(string name){
		return catalog [name];
	}

	public float posX(string name){
		return posCatalog[name].posX;
	}
	public float posY(string name){
		return posCatalog[name].posY;
	}
	public float scaleX(string name){
		return posCatalog[name].scaleX;
	}
	public float scaleY(string name){
		return posCatalog[name].scaleY;
	}
}

