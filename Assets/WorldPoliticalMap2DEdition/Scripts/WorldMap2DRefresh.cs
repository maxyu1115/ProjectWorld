using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WPMF
{
    public partial class WorldMap2D : MonoBehaviour
    {
        public bool winFlag = false;

		private double turnTime = 0;
		//private double turnTime = 100;

		private double monthTime = 0;

		private int _worldMonth=3;
		public int worldMonth
		{
			get {
				return _worldMonth;
			}
			set {
				_worldMonth = (value - 1) % 12 + 1;
				_worldYear += value / 12;
				
			}

		}
		private int _worldYear=2017;
		public int worldYear
		{
			get {
				return _worldYear;
			}
		}

		const int REFRESHRATE = 1;//in 3 months
        const float CGR = 0.15f;//Cultist Growth Rate, the maximum amount of increase every three month
        const float PGR = 0.001f;//Population Growth Rate, the percentage of Limit increase every three month
        const float GGR = 0.001f;//GDP Growth Rate, the percentage of Limit increase every three month
        const float LPGS = 0.0001f;//LogisticPopulationGrowthSpeed
        const float LGGS = 0.0001f;//LogisticGDPGrowthSpeed

		public static int THREEMONTHTIME = 40;//seconds three month are

		private long totalPopulation = 0;
        public long TotalPopulation
        {
            get
            {
                return totalPopulation;
            }
        }
		private long totalGDP = 0;
		public long TotalGDP
		{
			get
			{
				return totalGDP;
			}
		}


		public void Refresh()
		{
			if (tutorialMode)
				return;


			debugCheck();




			RTRefresh ();
			turnTime += Time.deltaTime;

			monthTime += Time.deltaTime;

			if (monthTime > THREEMONTHTIME / 3.0) {
				worldMonth += 1;
				monthTime = 0;

				foreach (Country c in countries) {
					c.data.refreshReligionUH = true;
				}

			}

			//Debug.Log (turnTime);
			if (turnTime > REFRESHRATE*THREEMONTHTIME) {
				TurnRefresh ();
				turnTime = 0;

				isWar = true;
			}
		}



        //The Refresh commands ran during turns(years)
        public void TurnRefresh()
        {

            EventTrigger();

			clearMods ();

        }

        //The Real Time refreshes ran with update
        public void RTRefresh()
        {
            checkEliminateWin();
			refreshGodForm ();

            //all the natural accumulations
            refreshPopulation();
            refreshGDP();
            refreshCultist();

			refreshEnergyDisplay();

			refreshCultColoring ();

            if (Energy == 1)
            {
                winFlag = true;
				return;
            }


        }

		public void LateRefresh()
		{
			instantiateEvents ();
			warLevelControl ();
		}

		public void instantiateEvents()
		{
			
			int flagIndex = -1;
			int count1 = 0;

			foreach (Country c in countries)
			{
				foreach (string genericName in c.data.instantiateQueue.Keys.ToList())
				{
					c.data.instantiateQueue [genericName] -= Time.deltaTime;

					if (genericName == "WarGenre" && c.data.instantiateQueue [genericName] <= 0) {
						flagIndex = GetCountryIndex (c);
						count1++;
						continue;
					}

					if (c.data.instantiateQueue [genericName] <= 0) {
						if (c.data.notEliminated) {
							GameObject temp = Instantiate (Resources.Load ("Prefabs/Events/" + genericName + "Event", typeof(GameObject))) as GameObject;
							Disasters temp2 = temp.GetComponent<Disasters> ();
							temp2.setTarget (GetCountryIndex (c));

						}
					}
				}

			}

			instantiateWars (flagIndex, count1);

		}


        public void checkEliminateWin()
        {
			int countryCount = 0;
            foreach (Country c in countries)
            {
                if (c.data.notEliminated)
                {
					countryCount++;
                }
            }
			if (countryCount==0)
            {
                winFlag = true;
            }
			Cost.survivingCountries = countryCount;
        }





		public void refreshPopulation()
		{
			totalPopulation = 0;
			for(int i = 0; i < countries.Length; i++)
            {
                if (countries[i].data.notEliminated)
                {
                    if(countries[i].data.population<=0)
                    {
                        countries[i].data.notEliminated = false;
						continue;
                    }

                    //logisticPopulationGrowth(countries[i].data);
                    populationGrowth(countries[i].data);

				    totalPopulation += countries[i].data.population;
                }

			}

			Cost.TotalPopulation = totalPopulation;
		}

        public void refreshGDP()
        {
			totalGDP = 0;

            for(int i = 0; i < countries.Length; i++)
            {
                if (countries[i].data.notEliminated)
                {
                    gdpGrowth(countries[i].data);
                }
				totalGDP += countries[i].data.gdp;

            }
        }

        public void refreshCultist()
        {
            for (int i = 0; i < countries.Length; i++)
            {
                if (countries[i].data.notEliminated)
                {
                    cultistGrowth(countries[i].data);
                }
            }
        }

        #region growth models
        private void cultistGrowth(RegionData d)
        {
            if (d.growthCultist < RegionData.CultistGrowthLIMIT)
            {
                d.growthCultist += (10 - d.religion) / 10 * CGR / THREEMONTHTIME * Time.deltaTime;
            }
        }


		int pTemp;
        private void populationGrowth(RegionData d)
        {
			pTemp = (int)((d.populationMax * PGR) / THREEMONTHTIME * Time.deltaTime);
			if (d.population < d.populationMax) {
				d.population += pTemp + (int)UnityEngine.Random.Range (-0.15f * pTemp, 0.3f * pTemp);
			} else if (d.population >= d.populationMax) {
				d.population += (int)UnityEngine.Random.Range (-0.5f * pTemp, 0.5f * pTemp);
			}
        }

		int gTemp;
        private void gdpGrowth(RegionData d)
        {
			gTemp = (int)((d.gdpMax * GGR) / THREEMONTHTIME * Time.deltaTime);

            if (d.gdp < d.gdpMax)
            {
				d.gdp += gTemp + (int)UnityEngine.Random.Range (-0.15f * gTemp, 0.3f * gTemp);
			}else if (d.gdp >= d.gdpMax)
			{
				d.gdp += (int)UnityEngine.Random.Range (-0.5f * gTemp, 0.5f * gTemp);
			}

        }

        private void logisticPopulationGrowth(RegionData d)
        {
            double x = Math.Log(((double)d.populationMax / d.population) - 1) / LPGS * -1;

            d.population += (int)(d.populationMax * LPGS * Math.Exp(-1 * LPGS * x) / Math.Pow(Math.Exp(-1 * LPGS * x) + 1, 2) * Time.deltaTime);

        }

        private void logisticGDPGrowth(RegionData d)
        {
            double x = Math.Log(((double)d.gdpMax / d.gdp) - 1) / LGGS * -1;

            d.gdp += (int)(d.gdpMax * LGGS * Math.Exp(-1 * LGGS * x) / Math.Pow(Math.Exp(-1 * LGGS * x) + 1, 2) * Time.deltaTime);
        }
        #endregion
    }
}

