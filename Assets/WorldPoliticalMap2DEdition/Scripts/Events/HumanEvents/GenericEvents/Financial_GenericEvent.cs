using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WPMF;

public class Financial_GenericEvent : GenericDisasters {
	public Sprite inflationIcon;
	public Sprite financialCrisisIcon;

	int financialLevel=0;
	double[] financialLevel_Threshold= {0.5};
	//double[,] effect_Index= {{0,+0.05,0,0,+0.05,-5},{-0.05,-0.2,-0.1,-0.05,-0.1,+13}};

	public override int getLevel ()
	{
		return financialLevel;
	}

	public override void refreshLevel(RegionData a) {
		financialLevel = 0;
		if(a.calculateTotalUnhappiness()<financialLevel_Threshold[0]) {
			financialLevel = 0;
		}
		else {
			financialLevel = 1;
		}
	}
		
	public override double[] getEffectIndex(int level){
		if (level == 0) {
			return new double[]{ 0, +0.05, 0, 0, +0.05, -5 };
		} else {
			return new double[]{ -0.05, -0.2, -0.1, -0.05, -0.1, +13 };
		}
	}


	public override Sprite getIcon (int level)
	{
		if (level == 0) {
			return inflationIcon;
		} else {
			return financialCrisisIcon;
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
			modValue = 0.001 * target.data.gdp / map.countries [i].data.gdp * (getLevel ());

			if (eventMods.ContainsKey (map.countries [i].name)) {
				eventMods [map.countries [i].name] += modValue;
			} else {
				eventMods.Add (map.countries [i].name, modValue);
			}
		}

	}


    public override float getDTime(RegionData d)
    {
        return 1.0f + 11*UnityEngine.Random.Range(0f, 1f);
    }

    public override string eventName()
    {
		if (financialLevel == 0) {
			return "Inflation";
		} else {
			return "FinancialCrisis";
		}
    }

	public override string eventName(int level)
	{
		if (level == 0) {
			return "Inflation";
		} else {
			return "FinancialCrisis";
		}
	}

	public override string genericName()
	{
		return "FinancialGenre";
	}
}
