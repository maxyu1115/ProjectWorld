using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public abstract class HumanDisasters : Disasters {
	
	public abstract double[] effect_Index{ get;}
	//0人口，1gdp，2resource，3religion，4tech，5邪教徒


	public override int effectPopulation(RegionData a) {
		return (int)(a.calculateTotalUnhappiness()*effect_Index[0]*a.population);
	}
	public override int resistencePopulation(RegionData a, int effect){
		return (int)(3 * effect*a.resistence());
	}

	public override int effectGDP(RegionData a) {
		return (int)(a.calculateTotalUnhappiness()*effect_Index[1]*a.gdp);
	}
	public override int resistenceGDP(RegionData a, int effect){
		return (int)(3 * effect*a.resistence());
	}
	public override double effectResource(RegionData a) {
		return a.calculateTotalUnhappiness()*effect_Index[2]*a.resource;
	}
	public override double resistenceResource(RegionData a, double effect){
		return 3 * effect*a.resistence();
	}
	public override double effectReligion(RegionData a) {
		return a.calculateTotalUnhappiness()*effect_Index[3]*a.religion;
	}
	public override double resistenceReligion(RegionData a, double effect){
		return 3 * effect*a.resistence();
	}
	public override double effectTechnology(RegionData a) {
		return a.calculateTotalUnhappiness()*effect_Index[4]*a.technology;
	}
	public override double resistenceTechnology(RegionData a, double effect){
		return 3 * effect*a.resistence();
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
		return 1.5 * 3 * d.calculateTotalUnhappiness () * (effect_Index [5] /100);
	}
	public override double resistenceCultist(RegionData d, double effect)
	{
		return effect;
	}
		
}
