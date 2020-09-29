using UnityEngine;
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


		private delegate double disasterFunc(RegionData d);
		private Dictionary<string, disasterFunc> disasterTriggers = new Dictionary<string, disasterFunc>();

		public List<ModList> disasterMods=new List<ModList>();

		public int targetIndex;

		public int cursorCountryIndex = -1;

		public void EventTrigger()
		{
			foreach(Country country in countries)
			{
                if (country.data.notEliminated)
                {
                    checkEvent(country);
                }
				
			}
			//checkEvent (countries [0]);

		}

		public void checkEvent(Country country)
		{
			foreach (KeyValuePair<string, disasterFunc> pair in disasterTriggers)
			{
				double tempP = pair.Value.Invoke(country.data);

				var mod=(from p in disasterMods
						where p.DisasterName == pair.Key
					select p).First();

				Dictionary<string, double> eventMods = mod.eventMods; //the dictionary of country names for the certain event
				//Dictionary<string, double> eventMods=new Dictionary<string, double>();
				//eventMods.Add ("Test", 0);
				//disasterMods.TryGetValue(pair.Key, out eventMods);

				double modtemp=0;
				eventMods.TryGetValue (country.name, out modtemp);

				if (checkProb(tempP / (10.0 * 2) + modtemp))
				//if (checkProb(tempP + modtemp))
				{
                    Debug.Log(mod.DisasterName);
					targetIndex = GetCountryIndex (country.name);
					if (!countries[targetIndex].data.genericQueue.Contains(mod.DisasterName))
                    	instEvent (pair.Key, country, UnityEngine.Random.Range (0f, 1f) * THREEMONTHTIME);
                    //instEvent(pair.Key, country, 0);
                }



			}
		}


		public bool checkProb(double tempProb)
		{
			int temp = (int)(tempProb * 100);

			int number = UnityEngine.Random.Range(0, 100);
			return (temp > number);
		}

		public void instEvent(string genericName, Country c, double timeLag)
		{
            //Debug.Log ("TEST ACTIVATED");
            //GameObject temp=Instantiate(Resources.Load("Test",typeof(GameObject))) as GameObject;

			c.data.instantiateQueue.Add (genericName, timeLag);

            /*GameObject temp = Instantiate(Resources.Load("Prefabs/Events/" + eventName + "Event", typeof(GameObject))) as GameObject;
            Disasters temp2 = temp.GetComponent<Disasters>();
            temp2.setTarget(countryIndex);*/

		}

		public void clearMods(){
			foreach (ModList m in disasterMods) {
				m.eventMods.Clear ();
			}
		}


		public void initializeDisasterMods(){
			disasterMods.Clear ();
			//disasterMods.Add (new ModList ("Test"));

			disasterMods.Add (new ModList ("RiotGenre"));
			disasterMods.Add (new ModList ("WarGenre"));
			disasterMods.Add (new ModList ("FinancialGenre"));

			disasterMods.Add (new ModList ("Plague"));
			disasterMods.Add (new ModList ("TechnologyBreakThrough"));
			disasterMods.Add (new ModList ("TerroristAttack"));


			disasterMods.Add (new ModList ("Tornado"));
			disasterMods.Add (new ModList ("Earthquake"));
			disasterMods.Add (new ModList ("Wildfire"));
			disasterMods.Add (new ModList ("Drought"));
			disasterMods.Add (new ModList ("Flood"));
			disasterMods.Add (new ModList ("Frost"));
			disasterMods.Add (new ModList ("Meteor"));
			disasterMods.Add (new ModList ("Volcano"));

			/*var mod=(from p in disasterMods
				where p.DisasterName == "Test"
				select p).First();

			Dictionary<string, double> eventMods = mod.eventMods;
			eventMods.Add (countries[0].name, 1);*/

		}


		public void createDisasterTrigger()
		{
			disasterTriggers.Clear();
			//disasterTriggers.Add ("Test", Probs.pTest);

			disasterTriggers.Add ("RiotGenre", Probs.pRiotGenre);
			disasterTriggers.Add ("WarGenre", Probs.pWarGenre);
			disasterTriggers.Add ("FinancialGenre", Probs.pFinancialGenre);
			disasterTriggers.Add ("Plague", Probs.pPlague);
			disasterTriggers.Add ("TechnologyBreakThrough", Probs.pTechnologyBreakThrough);
			disasterTriggers.Add ("TerroristAttack", Probs.pTerroristAttack);


			disasterTriggers.Add ("Tornado", Probs.pTornado);
			disasterTriggers.Add ("Earthquake", Probs.pEarthquake);
			disasterTriggers.Add ("Wildfire", Probs.pWildfire);
			disasterTriggers.Add ("Drought", Probs.pDrought);
			disasterTriggers.Add ("Flood", Probs.pFlood);
			disasterTriggers.Add ("Frost", Probs.pFrost);
			disasterTriggers.Add ("Meteor", Probs.pMeteor);
			disasterTriggers.Add ("Volcano", Probs.pVolcano);


		}

		private class Probs
		{
			public static double pTest(RegionData d) {
				return 1;
			}


			public static double pRiotGenre(RegionData d) {
				return d.calculateGDPUnhapiness()+d.calculateResourceUnhapiness()+d.calculateReligionUnhapiness()+0*UnityEngine.Random.Range(0f,1.0f);
			}
			public static double pWarGenre(RegionData d) {
				return d.calculatePopulationUnhapiness()+d.calculateGDPUnhapiness()+d.calculateResourceUnhapiness()+d.calculateTechnologyUnhapiness()+0*UnityEngine.Random.Range(0f,1.0f);
			}
			public static double pFinancialGenre(RegionData d) {
				return d.calculateGDPUnhapiness()+d.calculateResourceUnhapiness()+d.calculateTechnologyUnhapiness()+0*UnityEngine.Random.Range(0f,1.0f);
			}
			public static double pPlague(RegionData d) {
				return d.calculatePopulationUnhapiness()+d.calculateTechnologyUnhapiness()+0*UnityEngine.Random.Range(0f,1.0f);
			}
			public static double pTechnologyBreakThrough(RegionData d) {
				return d.calculateTechnologyUnhapiness()+0*UnityEngine.Random.Range(0f,0.9f)+0.1;
			}
			public static double pTerroristAttack(RegionData d) {
				return d.calculateReligionUnhapiness()+0*UnityEngine.Random.Range(0f,0.9f)+0.1;
			}


			public static double pNature(double p1, double p2, double p3, double p4) {
				return (p1 + p2 * p3) * p4;
			}
			public static double pTornado(RegionData d)
			{
				return pNature (0.0001, 0.1, d.tornadoBuff, 1);
			}
			public static double pEarthquake(RegionData d)
			{
				return pNature (0.0001, 0.01, d.earthquakeBuff, 1);
			}
			public static double pWildfire(RegionData d)
			{
				return pNature (0.01, 0.5, d.wildfireBuff, 1);
			}
			public static double pDrought(RegionData d)
			{
				return pNature (0.001, 0.2, d.droughtBuff, 1);
			}
			public static double pFlood(RegionData d)
			{
				return pNature (0.001, 0.2, d.floodBuff, 1);
			}
			public static double pFrost(RegionData d)
			{
				return pNature (0.01, 0.5, d.frostBuff, 1);
			}
			public static double pMeteor(RegionData d)
			{
				return pNature (0.0001, 0.001, d.meteorBuff, 1);
			}
			public static double pVolcano(RegionData d)
			{
				return pNature (0.0001, 0.001, d.volcanoBuff, 1);
			}



		}


	}
}
