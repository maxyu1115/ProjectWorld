using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WPMF;


public class RegionData
{
    public bool notEliminated = true;

    public const double CultistGrowthLIMIT= 0.33;

    public int populationMax;
    private int _population;
	public int population
    {
        get
        {
            return _population;
        }
        set
        {
            if (value <= 0)
            {
                _population = 0;

                notEliminated = false;

                _gdp = 0;
                _religion = 0;
                _technology = 0;
                _growthCultist = 0;
                _extraCultist = 0;
                _resource = 0;
            }
            else
                _population = value;
        }
    }

    public int gdpMax;
    private int _gdp;
	public int gdp
    {
        get
        {
            return _gdp;
        }
        set
        {
            if (value < 0)
                _gdp = 0;
            else
                _gdp = value;
        }
    }

    private double _technology;
	public double technology
    {
        get
        {
            return _technology;
        }
        set
        {
            if (value > 100)
                _technology = 100;
            else if (value < 0)
                _technology = 0;
            else
                _technology = value;
        }
    }


	public double unhappiness { get; set; }

    private double _resource;
	public double resource
    {
        get
        {
            return _resource;
        }
        set
        {
            if (value > 100)
                _resource = 100;
            else if (value < 0)
                _resource = 0;
            else
                _resource = value;
        }

    }

    private double _religion;
	public double religion
    {
        get
        {
            return _religion;
        }
        set
        {
            if (value > 10)
                _religion = 10;
            else if (value < 0)
                _religion = 0;
            else
                _religion = value;
        }
    }

    //private double _cultist;
    public double cultist
    {
        get
        {
            if (_growthCultist + _extraCultist > 1)
            {
                Debug.Log("cultist error");
            }

            return _growthCultist + _extraCultist;
        }
    }

    private double _growthCultist;
    public double growthCultist
    {
        get
        {
            return _growthCultist;
        }
        set
        {
            if (value > CultistGrowthLIMIT)
                _growthCultist = CultistGrowthLIMIT;
            else if (value < 0)
                _growthCultist = 0;
            else
                _growthCultist = value;
        }
    }
    private double _extraCultist;
    public double extraCultist
    {
        get
        {
            return _extraCultist;
        }
        set
        {
            if (value > (1 - CultistGrowthLIMIT))
                _extraCultist = 1 - CultistGrowthLIMIT;
            else if (value < 0)
                _extraCultist = 0;
            else
                _extraCultist = value;
        }
    }

	public bool refreshReligionUH { get; set; }
	public double religionUH { get; set; }



	public double tornadoBuff { get; set; }
	public double earthquakeBuff { get; set; }
	public double wildfireBuff { get; set; }
	public double droughtBuff { get; set; }
	public double floodBuff { get; set; }
	public double frostBuff { get; set; }
	public double meteorBuff { get; set; }
	public double volcanoBuff { get; set; }


	public int populationS { get; set; }
    /*public double GdpS { get; set; }
	public double resourceS { get; set; }*/

	public List<string> modQueue = new List<string> ();

    public List<string> modDestroyQueue = new List<string>();

	public Dictionary<string, double> instantiateQueue = new Dictionary<string, double> ();

	public List<string> eventQueue = new List<string> ();

	public List<string> genericQueue = new List<string> ();

	Constants world = new Constants ();

	public void clone (RegionData d)
	{
        populationMax = d.populationMax;
		population = d.population;
        gdpMax = d.gdpMax;
		gdp = d.gdp;
		technology = d.technology;
		unhappiness = d.unhappiness;
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
	}
		

	/*
	public RegionData(int population, double GDP, int t, int religious, int resource, int populationS, 
		double GDPS,double resourceS,double[] nature,double[] nature_Effect) {
		this.population=population;
		this.gdp=GDP;
		this.technology=t;
		this.religion=religious;
		this.resource=resource;
		this.populationS=populationS;
		this.GDPS=GDPS;
		this.resourceS=resourceS;
		this.nature_Startprobability=nature;//自然触发率，地区增益，增益开关，保护锁，主动触发概率
		this.nature_Effect=nature_Effect;//基础日折损，增益日折损，增益开关，线性参数，线性日折损，随机日折损，

	}*/
	public double calculatePopulationUnhapiness ()
	{
		return (System.Math.Abs(population - populationS) / (double)populationS) * 0.2;
	}

	public double calculateGDPUnhapiness ()
	{
		return ((System.Math.Abs ((gdp / (double)population) - world.gdpS)) / world.gdpS) * 0.2;
	}

	public double calculateResourceUnhapiness ()
	{
		double temp = (world.resourceS - (resource / ((double)population / 100000000)));
		if (temp < 0)
			temp = 0;
		return (temp / world.resourceS) * 0.2;
	}

	public double calculateTechnologyUnhapiness ()
	{
		return (System.Math.Abs ((technology - world.average_Technology)) / world.average_Technology) * 0.2;
	}

	public double calculateReligionUnhapiness ()
	{
		if (religion > world.religionSL && religion < world.religionSH) {
			return 0;
		} else {
			if (refreshReligionUH) {
				religionUH = UnityEngine.Random.Range (0f, 1f) * 0.2;
				refreshReligionUH = false;
			}
			return religionUH;
		}

	}

	public double calculateTotalUnhappiness ()
	{
		return this.calculatePopulationUnhapiness () + this.calculateGDPUnhapiness () + this.calculateResourceUnhapiness () +
		this.calculateTechnologyUnhapiness () + this.calculateReligionUnhapiness ();

	}

	public int resistenceLevel ()
	{
		int resistenceLevel = 0;
		if (technology < world.resistenceLevel_Index [1]) {
			resistenceLevel = 0;
		} else if (technology < world.resistenceLevel_Index [2]) {
			resistenceLevel = 1;
		} else if (technology < world.resistenceLevel_Index [3]) {
			resistenceLevel = 2;
		} else if (technology < world.resistenceLevel_Index [4]) {
			resistenceLevel = 3;
		} else if (technology < world.resistenceLevel_Index [5]) {
			resistenceLevel = 4;
		}
		return resistenceLevel;
	}

	public double resistence ()
	{
		return 1 + (1 + (technology - world.resistenceLevel_Index [resistenceLevel ()]) / world.resistenceLevel_Index [resistenceLevel ()]) * world.resistence_Index [resistenceLevel ()];

	}


}



