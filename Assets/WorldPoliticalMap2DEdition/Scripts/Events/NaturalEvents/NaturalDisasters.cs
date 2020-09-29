using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WPMF;

public abstract class NaturalDisasters : Disasters {
	double intensity;
	public abstract double[] nature_Effect{ get;}

	public abstract double buffSwitch (RegionData a);

	public abstract int[] mod_Effect{ get;}

	public override void additionalEarlyStart (RegionData data)
	{
		string[] humanDisasters = { "Plague", "WarGenre", "FinancialGenre", "RiotGenre", "TerroristAttack" };

		string name;
		Dictionary<string,double> eventMods;
		double modValue;

		int[] modEffect = mod_Effect;

		for (int i = 0; i < 5; i++) {
			name = humanDisasters [i];

			var mod = (from p in map.disasterMods
				where p.DisasterName == name
				select p).First ();
			
			eventMods = mod.eventMods;
			modValue = modEffect[i] * 0.10;

			if (eventMods.ContainsKey (target.name)) {
				eventMods [target.name] += modValue;
			} else {
				eventMods.Add (target.name, modValue);
			}
		}

	}



	public override int effectPopulation(RegionData a) {
		intensity=(nature_Effect[0]+nature_Effect[1]*buffSwitch(a)+nature_Effect[3]*nature_Effect[4]+nature_Effect[5]*UnityEngine.Random.Range(0f,1f));

		return (int)(intensity * -1);
	}
	public override int resistencePopulation(RegionData a, int effect){
		return (int)(15 * effect*a.resistence()); //MAX!
	}

	public override int effectGDP(RegionData a) {
		intensity=(nature_Effect[0]+nature_Effect[1]*buffSwitch(a)+nature_Effect[3]*nature_Effect[4]+nature_Effect[5]*UnityEngine.Random.Range(0f,1f));

		return (int)((intensity / a.population) * -1 * a.gdp * 1);
	}
	public override int resistenceGDP(RegionData a, int effect){
		return effect;
	}

	//need to fix
	public override double effectResource(RegionData a) {
		return 0;
	}
	public override double resistenceResource(RegionData a, double effect){
		return effect;
	}
	public override double effectReligion(RegionData a) {
		intensity=(nature_Effect[0]+nature_Effect[1]*buffSwitch(a)+nature_Effect[3]*nature_Effect[4]+nature_Effect[5]*UnityEngine.Random.Range(0f,1f));

		return (intensity/a.population)*10*a.religion;
	}
	public override double resistenceReligion(RegionData a, double effect){
		return effect;
	}
	public override double effectTechnology(RegionData a) {
		intensity=(nature_Effect[0]+nature_Effect[1]*buffSwitch(a)+nature_Effect[3]*nature_Effect[4]+nature_Effect[5]*UnityEngine.Random.Range(0f,1f));

		return (intensity/a.population)*10*a.technology*-1;
	}
	public override double resistenceTechnology(RegionData a, double effect){
		return effect;
	}

	//public abstract float getDTime (RegionData d);

	public override double effectUnhappiness(RegionData d)
	{
		return 0;
	}
	public override double resistenceUnhappiness(RegionData d, double effect)
	{
		return effect;
	}
	public override double effectCultist(RegionData d)
	{
		return 0;
	}
	public override double resistenceCultist(RegionData d, double effect)
	{
		return effect;
	}

}
