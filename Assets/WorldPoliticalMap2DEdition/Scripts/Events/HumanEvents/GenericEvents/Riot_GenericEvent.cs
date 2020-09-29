using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Riot_GenericEvent : GenericDisasters{
	public Sprite riotIcon;
	public Sprite rebellionIcon;

	int riotLevel = 0;
	double[] riotLevel_Index = { 0.5 };
	//double[,] effect_Index = { { 0, -0.05, 0, -0.05, -0.05, 15 }, { -0.05, -0.1, -0.05, -0.05, -0.08, 10 } };
	//两类暴动
	//人口，gdp，resource，religion，tech，邪教徒
	//可以写成字典

	public override int getLevel ()
	{
		return riotLevel;
	}
	
	public override void refreshLevel(RegionData a) {
		riotLevel = 0;
		if(a.calculateTotalUnhappiness()<riotLevel_Index[0]) {
			riotLevel = 0;
		}
		else {
			riotLevel = 1;
		}
	}

	public override double[] getEffectIndex(int level){
		if (level == 0) {
			return new double[]{ 0, -0.05, 0, -0.05, -0.05, 15 };
		} else {
			return new double[]{ -0.05, -0.1, -0.05, -0.05, -0.08, 10 };
		}
	}


	public override Sprite getIcon (int level)
	{
		if (level == 0) {
			return riotIcon;
		} else {
			return rebellionIcon;
		}
	}



    public override float getDTime(RegionData d)
    {
		return 1.5f + (2.5f + riotLevel * 8)*UnityEngine.Random.Range(0f, 1f);
    }

    public override string eventName()
    {
		if (riotLevel == 0) {
			return "Riot";
		} else {
			return "Rebellion";
		}
    }

	public override string eventName(int level)
	{
		if (level == 0) {
			return "Riot";
		} else {
			return "Rebellion";
		}
	}

	public override string genericName ()
	{
		return "RiotGenre";
	}

}

