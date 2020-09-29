using System;

public class EventDetail
{


	private string eType;
	public string EType { 
		get{
			return eType;
		}
	}

	#region Human Events
	private int populationL;
	public int PopulationL { 
		get{
			return populationL;
		}
	}

	private int gdpL;
	public int GdpL { 
		get{
			return gdpL;
		}
	}

	private int technologyL;
	public int TechnologyL { 
		get{
			return technologyL;
		}
	}

	private int resourceL;
	public int ResourceL { 
		get{
			return resourceL;
		}
	}

	private int religionL;
	public int ReligionL { 
		get{
			return religionL;
		}
	}

	private int cultistL;
	public int CultistL { 
		get{
			return cultistL;
		}
	}

	private string diffusibility;
	public string Diffusibility { 
		get{
			return diffusibility;
		}
	}
	#endregion

	#region morphing human events
	private string variationNames;
	public string VariationNames { 
		get{
			return variationNames;
		}
	}

	private int populationH;
	public int PopulationH { 
		get{
			return populationH;
		}
	}
	private int gdpH;
	public int GdpH { 
		get{
			return gdpH;
		}
	}
	private int technologyH;
	public int TechnologyH { 
		get{
			return technologyH;
		}
	}
	private int resourceH;
	public int ResourceH { 
		get {
			return resourceH;
		}
	}
	private int religionH;
	public int ReligionH { 
		get{
			return religionH;
		}
	}
	private int cultistH;
	public int CultistH { 
		get{
			return cultistH;
		}
	}
	#endregion

	#region natural events
	private string normalRank;
	public string NormalRank { 
		get{
			return normalRank;
		}
	}

	private string buffedRank;
	public string BuffedRank { 
		get{
			return buffedRank;
		}
	}

	private string variationDegree;
	public string VariationDegree { 
		get{
			return variationDegree;
		}
	}
	#endregion





	//Normal Human Events
	public EventDetail (int pL, int gL, int tL, int resL, int relL, int cL, string diffusion)
	{
		eType = "Human Event";

		populationL = pL;
		gdpL = gL;
		technologyL = tL;
		resourceL = resL;
		religionL = relL;
		cultistL = cL;

		diffusibility = diffusion;
	}

	//Morphying Human Events
	public EventDetail (string variations, int pL, int pH, int gL, int gH, int tL, int tH, int resL, int resH, int relL, int relH, int cL, int cH, string diffusion)
	{
		eType = "Morphying Human Event";

		variationNames = variations;

		populationL = pL;
		populationH = pH;

		gdpL = gL;
		gdpH = gH;

		technologyL = tL;
		technologyH = tH;

		resourceL = resL;
		resourceH = resH;

		religionL = relL;
		religionH = relH;

		cultistL = cL;
		cultistH = cH;

		diffusibility = diffusion;
	}

	//Natural Events
	public EventDetail (string nR, string bR, string vD)
	{
		eType = "Natural Event";
		normalRank = nR;
		buffedRank = bR;
		variationDegree = vD;

	}

}


