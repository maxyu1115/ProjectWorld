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
		public double Energy;
		public double possibleCost;
		public bool isOnDrag = false;

		public bool lockDrag = false;

		public int modTargetIndex = -1;
		public string modName = "";

		public void refreshEnergyDisplay()
		{
			Energy = 0;
			long totalCultist = 0;

			foreach(Country c in countries){
				
				//Debug.Log (c.name);

				//Debug.Log (c.data.cultist * c.data.population);
				if (c.data.notEliminated)
					totalCultist += (int)(c.data.cultist * c.data.population);
				
				//Debug.Log (totalCultist);
			}

			Energy = (double)(10000 * totalCultist / totalPopulation) / 10000;
			if (!isOnDrag) {
				possibleCost = 0;
			}
		}


		public bool deductEnergy(double cost, int index)
		{
			if (cost > Energy || cost < 0) {
				return false;
			}

			int temp = (int)(countries [index].data.cultist * countries [index].data.population); //number of cult members in target country

			if (temp < totalPopulation * cost) {
				double avgPercentageCost = (totalPopulation * cost - temp) / (totalPopulation * Energy - temp);

                if (countries[index].data.cultist != 0)
                {
				    deductCultist (countries [index].data.cultist, index);
                }

				for (int i = 0; i < countries.Length; i++) {
					if (i != index && countries[i].data.notEliminated && countries[index].data.cultist != 0) {
						deductCultist (avgPercentageCost * countries [i].data.cultist, i);
					}
				}
			} else {
				deductCultist (cost * totalPopulation / countries [index].data.population, index); 
			}
			return true;
		}


		/// <summary>
		/// Deducts the cultist.
		/// </summary>
		/// <param name="cost">from 0 to 1, percentage out of 1.</param>
		/// <param name="index">Index.</param>
		public void deductCultist(double cost, int index)
		{

			int p = countries [index].data.population;

			double growthCultRatio = countries[index].data.growthCultist / (countries[index].data.cultist);

			//needed cultist to activate event
			double deducted = p * (cost);

			//population that are not cultist
			double nonCult = p * (1 - countries[index].data.cultist) + deducted*1/3;

			countries [index].data.population -= (int)(deducted * 2/3);


			p = countries [index].data.population;

			if (p <= 0)
			{
				return;
			}

			double tempCult = 1.0 - nonCult / p;

			countries[index].data.growthCultist = tempCult * growthCultRatio;
			countries[index].data.extraCultist = tempCult * (1 - growthCultRatio);



			/*
			int p = countries [index].data.population;

			double extraCult = countries [index].data.extraCultist * countries [index].data.population;

			//needed cultist to activate event
			double deducted = p * (cost);

			//population that are not cultist
			double nonCult = p * (1 - countries[index].data.cultist) + deducted * (1/3);

			countries [index].data.population -= (int)(deducted * 2/3);


			p = countries [index].data.population;

			if (p == 0)
			{
				return;
			}

			double tempCult = 1.0 - nonCult / p;

			if (tempCult <= extraCult) {
				countries [index].data.extraCultist = tempCult / p;
			} else {
				countries [index].data.extraCultist = extraCult / p;
				countries [index].data.growthCultist = (tempCult - extraCult) / p; 
			}
			*/





		}

	}
}

