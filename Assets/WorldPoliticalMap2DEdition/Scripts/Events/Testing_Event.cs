using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Testing_Event : Disasters {

	public override int effectPopulation(RegionData a) {
		return (int)(-0.3 * a.population);
	}
	public override int resistencePopulation(RegionData a, int effect){
		return effect;
	}
	public override int effectGDP(RegionData a) {
		return (int)(-10000);
	}
	public override int resistenceGDP(RegionData a, int effect){
		return (int)(effect*a.resistence());
	}
	public override double effectResource(RegionData a) {
		return -10000;
	}
	public override double resistenceResource(RegionData a, double effect){
		return effect;
	}
	public override double effectReligion(RegionData a) {
		return -1;
	}
	public override double resistenceReligion(RegionData a, double effect){
		return effect;
	}
	public override double effectTechnology(RegionData a) {
		return -5000;
	}
	public override double resistenceTechnology(RegionData a, double effect){
		return effect;
	}



	public override float getDTime(RegionData d)
	{
		return 0.5f;
	}

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
		return 0.3;
	}
	public override double resistenceCultist(RegionData d, double effect)
	{
		return effect;
	}

    public override string eventName()
    {
        return "Test";
    }
	public override string genericName ()
	{
		return eventName ();
	}
}

