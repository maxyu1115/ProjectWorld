using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{		

		public delegate double costfunctions(RegionData d);
		public Dictionary<string, costfunctions> disasterCost = new Dictionary<string, costfunctions> ();


		public double getCost(int index, string eventName)
		{
			return disasterCost [eventName].Invoke (countries [index].data);
		}


		public void initializeCostFuncs ()
		{
			
			disasterCost.Add ("RiotGenre", Cost.cRiotGenre);
			disasterCost.Add ("WarGenre", Cost.cWarGenre);
			disasterCost.Add ("FinancialGenre", Cost.cFinancialGenre);

			disasterCost.Add ("Plague", Cost.cPlague);
			disasterCost.Add ("TechnologyBreakThrough", Cost.cTechnologyBreakThrough);
			disasterCost.Add ("TerroristAttack", Cost.cTerroristAttack);

			disasterCost.Add ("Tornado", Cost.cTornado);
			disasterCost.Add ("Earthquake", Cost.cEarthquake);
			disasterCost.Add ("Wildfire", Cost.cWildfire);
			disasterCost.Add ("Drought", Cost.cDrought);
			disasterCost.Add ("Flood", Cost.cFlood);
			disasterCost.Add ("Frost", Cost.cFrost);
			disasterCost.Add ("Meteor", Cost.cMeteor);
			disasterCost.Add ("Volcano", Cost.cVolcano);


		}



		public class Cost
		{
			public static long TotalPopulation;
			public static int survivingCountries;

			public static double cRiotGenre(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.45 / 2;
			}
			public static double cWarGenre(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.6 / 2;
			}
			public static double cFinancialGenre(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.3 / 2;
			}
			public static double cPlague(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.8 / 2;
			}
			public static double cTechnologyBreakThrough(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.2 / 2;
			}
			public static double cTerroristAttack(RegionData d) {
				double temp = TotalPopulation / d.population;
				return (1 / temp) * (survivingCountries + 12.0) / 12.0 * 0.2 / 2;
			}


			public static double cTornado(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.05 + d.tornadoBuff * 0.15 + (1 / temp) * 0.05; // 0.05, 0.2
			}
			public static double cEarthquake(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.1 + d.earthquakeBuff * 0.35 + (1 / temp) * 0.05; //0.1, 0.45
			}	
			public static double cWildfire(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.2 + d.wildfireBuff * -0.1 + (1 / temp) * 0.05; //0.2, 0.1
			}
			public static double cDrought(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.05 + d.droughtBuff * 0.05 + (1 / temp) * 0.05; //0.05, 0.1
			}
			public static double cFlood(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.05 + d.droughtBuff * 0.05 + (1 / temp) * 0.05; //0.05, 0.1
			}
			public static double cFrost(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.2 + d.frostBuff * -0.1 + (1 / temp) * 0.05; //0.2, 0.1
			}
			public static double cMeteor(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.55 + d.meteorBuff * 0.0 + (1 / temp) * 0.05; //0.55
			}
			public static double cVolcano(RegionData d)
			{
				double temp = TotalPopulation / d.population;
				return 0.25 + d.volcanoBuff * 0.0 + (1 / temp) * 0.05; //0.25
			}
		}

	}
}

