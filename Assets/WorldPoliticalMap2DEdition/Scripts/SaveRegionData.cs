using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WPMF;

[Serializable]
public class SaveRegionData
{
	public int populationMax;
	public int population;
	public int gdpMax;
	public int gdp;
	public double technology;
	public double resource;
	public double religion;
	public double growthCultist;
	public double extraCultist;

	public bool refreshReligionUH;
	public double religionUH;

	public double tornadoBuff;
	public double earthquakeBuff;
	public double wildfireBuff;
	public double droughtBuff;
	public double floodBuff;
	public double frostBuff;
	public double meteorBuff;
	public double volcanoBuff;


	public int populationS;
	/*public double GdpS { get; set; }
	public double resourceS { get; set; }*/

	public List<string> modQueue = new List<string> ();

	public List<string> modDestroyQueue = new List<string>();

	//public Dictionary<string, double> instantiateQueue = new Dictionary<string, double> ();
	public string[] instantiateQueueKey;
	public double[] instantiateQueueValue;


	public List<string> eventQueue = new List<string> ();

	public List<string> genericQueue = new List<string> ();


	public void saveRegionData (RegionData d){
		populationMax = d.populationMax;
		population = d.population;
		gdpMax = d.gdpMax;
		gdp = d.gdp;
		technology = d.technology;
		resource = d.resource;
		religion = d.religion;
		growthCultist = d.growthCultist;
		extraCultist = d.extraCultist;

		refreshReligionUH = d.refreshReligionUH;
		religionUH = d.religionUH;
		populationS = d.populationS;

		tornadoBuff = d.tornadoBuff;
		earthquakeBuff = d.earthquakeBuff;
		wildfireBuff = d.wildfireBuff;
		droughtBuff = d.droughtBuff;
		floodBuff = d.floodBuff; 
		frostBuff = d.frostBuff;
		meteorBuff = d.meteorBuff;
		volcanoBuff = d.volcanoBuff;

		modQueue = d.modQueue;
		modDestroyQueue = d.modDestroyQueue;
		List<string> keys = new List<string> ();
		List<double> values = new List<double> ();
		foreach (KeyValuePair <string, double> KP in d.instantiateQueue) {
			keys.Add (KP.Key);
			values.Add (KP.Value);
		}
		instantiateQueueKey = keys.ToArray ();
		instantiateQueueValue = values.ToArray ();

		eventQueue = d.eventQueue;
		genericQueue = d.genericQueue;
	}

	public RegionData loadRegionData(){
		RegionData d = new RegionData ();

		d.populationMax = populationMax;
		d.population = population;
		d.gdpMax = gdpMax;
		d.gdp = gdp;
		d.technology = technology;
		d.resource = resource;
		d.religion = religion;
		d.growthCultist = growthCultist;
		d.extraCultist = extraCultist;

		d.refreshReligionUH = refreshReligionUH;
		d.religionUH = religionUH;
		d.populationS = populationS;

		d.tornadoBuff = tornadoBuff;
		d.earthquakeBuff = earthquakeBuff;
		d.wildfireBuff = wildfireBuff;
		d.droughtBuff = droughtBuff;
		d.floodBuff = floodBuff; 
		d.frostBuff = frostBuff;
		d.meteorBuff = meteorBuff;
		d.volcanoBuff = volcanoBuff;

		d.modQueue = modQueue;
		d.modDestroyQueue = modDestroyQueue;
		for (int i = 0; i < instantiateQueueKey.Length; i++) {
			d.instantiateQueue.Add (instantiateQueueKey [i], instantiateQueueValue [i]);
		}

		d.eventQueue = eventQueue;
		d.genericQueue = genericQueue;

		return d;

	}


}

