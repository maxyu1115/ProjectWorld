using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WPMF;

public class War_GenericEvent : GenericDisasters
{
	public Sprite skirmishIcon;
	public Sprite warIcon;
	public Sprite fullWarIcon;

	bool[] warCap;

	public void setCapReference (bool[] warLevelCap)
	{
		warCap = warLevelCap;
	}

	//double[,] effect_Index= {{-0.02,+0.1,-0.03,-0.03,+0.02,5},{-0.05,-0.2,-0.05,+0.05,0,8},{-0.15,-0.23,-0.1,+0.15,-0.05,18}};

	int warLevel;
	private static double[] warLevel_Threshold = { 0.45, 0.75, 1 };

	public override void refreshLevel (RegionData a)
	{
		warLevel = 0;
		if (a.calculateTotalUnhappiness () < warLevel_Threshold [0]) {
			warLevel = 0;
		} else if (a.calculateTotalUnhappiness () < warLevel_Threshold [1]) {
			warLevel = 1;
		} else {
			warLevel = 2;
		}

		while (warLevel != -1) {
			if (warCap [warLevel] == true)
				break;
			warLevel--;
		}
	}


	public override int getLevel ()
	{
		return warLevel;
	}

	public int getActualLevel ()
	{
		RegionData a = base.target.data;
		int actualLevel = 0;
		if (a.calculateTotalUnhappiness () < warLevel_Threshold [0]) {
			actualLevel = 0;
		} else if (a.calculateTotalUnhappiness () < warLevel_Threshold [1]) {
			actualLevel = 1;
		} else {
			actualLevel = 2;
		}
		return actualLevel;
	}

	public static int estimateLevel (RegionData a)
	{
		//RegionData a = base.target.data;
		int estimateLevel = 0;
		if (a.calculateTotalUnhappiness () < warLevel_Threshold [0]) {
			estimateLevel = 0;
		} else if (a.calculateTotalUnhappiness () < warLevel_Threshold [1]) {
			estimateLevel = 1;
		} else {
			estimateLevel = 2;
		}
		return estimateLevel;
	}

	public override double[] getEffectIndex (int level)
	{
		if (level == 0) {
			return new double[]{ -0.02, +0.1, -0.03, -0.03, +0.02, 5 };
		} else if (level == 1) {
			return new double[]{ -0.05, -0.2, -0.05, +0.05, 0, 8 };
		} else {
			return new double[]{ -0.15, -0.23, -0.1, +0.15, -0.05, 18 };
		}
	}


	public override Sprite getIcon (int level)
	{
		if (level == 0) {
			return skirmishIcon;
		} else if (level == 1) {
			return warIcon;
		} else {
			return fullWarIcon;
		}
	}


	public override float getDTime (RegionData d)
	{
		return 1.0f + (warLevel + 1) * 3.0f * UnityEngine.Random.Range (0f, 1f);
	}

	public override void specialDestroy ()
	{
		if (getLevel () < 0) {
			map.warList.Remove (this);
			Destroy (this.gameObject);
		}
	}


	public override void boostCountries ()
	{
		string name = genericName ();
		var mod = (from p in map.disasterMods
		          where p.DisasterName == name
		          select p).First ();
		Dictionary<string,double> eventMods = mod.eventMods;

		int index = map.GetCountryIndex (target);

		double modValue;

		for (int i = 0; i < map.countries.Length; i++) {
			if (i == index || !map.countries[i].data.notEliminated) {
				continue;
			}
			modValue = 0.03 * map.countries [i].data.calculateTotalUnhappiness() * (getLevel () + 1);

			if (eventMods.ContainsKey (map.countries [i].name)) {
				eventMods [map.countries [i].name] += modValue;
			} else {
				eventMods.Add (map.countries [i].name, modValue);
			}
		}

	}


	public override string eventName ()
	{
		if (warLevel == 0) {
			return "Skirmish";
		} else if (warLevel == 1) {
			return "War";
		} else {
			return "FullScaleWar";
		}
	}

	public override string eventName (int level)
	{
		if (level == 0) {
			return "Skirmish";
		} else if (level == 1) {
			return "War";
		} else {
			return "FullScaleWar";
		}
	}

	public override string genericName ()
	{
		return "WarGenre";
	}


}