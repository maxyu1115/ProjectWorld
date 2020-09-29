using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WPMF;

public class Plague_Event : HumanDisasters{
	double[] effectIndex= {-0.35,-0.3,-0.1,+0.1,-0.1,15};
	public override double[] effect_Index
	{
		get{
			return effectIndex;
		}

	}

	public override void additionalEarlyStart (RegionData data)
	{
		string name = genericName ();
		var mod=(from p in map.disasterMods
			where p.DisasterName == name
			select p).First();
		Dictionary<string,double> eventMods = mod.eventMods;

		double modValue;

		foreach (int i in target.countryNeighborIndices) {
			if (!target.data.notEliminated)
				continue;

			modValue = 0.05 * target.data.population / map.countries [i].data.population;

			if (eventMods.ContainsKey (map.countries[i].name)) {
				eventMods [map.countries[i].name] += modValue;
			} else {
				eventMods.Add (map.countries[i].name, modValue);
			}
		}
	}

	public override float getDTime(RegionData d)
	{
        return 1.0f + 7.0f*UnityEngine.Random.Range(0f, 1f);
    }



    public override string eventName()
    {
        return "Plague";
    }
}
