using UnityEngine;
/*using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;*/
using System.Text;
using WPMF;


namespace WPMF
{
    
    public partial class WorldMap2D_Editor : MonoBehaviour
    {
		
		public bool dataChanges;

		public string GUICountryPopulation="";
		public string GUICountryGdp="";
		public string GUICountryTechnology="";
		public string GUICountryUnhappiness="";
		public string GUICountryResource="";
		public string GUICountryReligion="";
		public string GUICountryGCultist="";
		public string GUICountryPopulationS="";
		/*public string GUICountryGdpS="";
		public string GUICountryResourceS="";*/


		public string GetCountryData () {
			StringBuilder sb = new StringBuilder ();
			for (int k = 0; k < map.countries.Length; k++) {
				Country country = map.countries [k];
				if (k > 0)
					sb.Append ("|");
				sb.Append (country.name + "%");
				sb.Append (country.data.population + "$");
				sb.Append (country.data.gdp + "$");
				sb.Append (country.data.technology + "$");
				sb.Append (country.data.unhappiness + "$");
				sb.Append (country.data.resource + "$");
				sb.Append (country.data.religion + "$");
				sb.Append (country.data.growthCultist + "$");
				sb.Append (country.data.populationS + "$");
				/*sb.Append (country.data.GdpS + "$");
				sb.Append (country.data.resourceS + "$");*/
			}
			return sb.ToString ();
		}

		public void mergeCountryData(Country source, Country target){
			target.data.population += source.data.population;
			target.data.gdp += source.data.gdp;
			target.data.technology += source.data.technology;
			target.data.unhappiness += source.data.unhappiness;
			target.data.resource += source.data.resource;
			target.data.religion += source.data.religion;
			target.data.growthCultist += source.data.growthCultist;
            target.data.extraCultist += source.data.extraCultist;
            target.data.populationS += source.data.populationS;
			/*target.data.GdpS += source.data.GdpS;
			target.data.resourceS += source.data.resourceS;*/

			mergeCountryNDData (source, target);

		}


		public void GUIDataRefresh(){
			GUICountryPopulation=""+map.countries[countryIndex].data.population;
			GUICountryGdp=""+map.countries[countryIndex].data.gdp;
			GUICountryTechnology=""+map.countries[countryIndex].data.technology;
			GUICountryUnhappiness=""+map.countries[countryIndex].data.unhappiness;
			GUICountryResource=""+map.countries[countryIndex].data.resource;
			GUICountryReligion=""+map.countries[countryIndex].data.religion;
			GUICountryGCultist=""+map.countries[countryIndex].data.growthCultist;
			GUICountryPopulationS=""+map.countries[countryIndex].data.populationS;
			/*GUICountryGdpS=""+map.countries[countryIndex].data.GdpS;
			GUICountryResourceS=""+map.countries[countryIndex].data.resourceS;*/
		}


		public void ClearDataSelection(){
			GUICountryPopulation="";
			GUICountryGdp="";
			GUICountryTechnology="";
			GUICountryUnhappiness="";
			GUICountryResource="";
			GUICountryReligion="";
			GUICountryGCultist="";
			GUICountryPopulationS = "";
			/*GUICountryGdpS = "";
			GUICountryResourceS = "";*/
		}

		public void CountryPopulationChange(){
			int temp;
			if (int.TryParse (GUICountryPopulation, out temp)) {
				map.countries [countryIndex].data.population = temp;
			}
			dataChanges = true;
		}

		public void CountryGdpChange(){
			int temp;
			if (int.TryParse (GUICountryGdp, out temp)) {
				map.countries [countryIndex].data.gdp = temp;
			}
			dataChanges = true;
		}

		public void CountryTechnologyChange(){
			double temp;
			if (double.TryParse (GUICountryTechnology, out temp)) {
				map.countries [countryIndex].data.technology = temp;
			}
			dataChanges = true;
		}

		public void CountryUnhappinessChange(){
			double temp;
			if (double.TryParse (GUICountryUnhappiness, out temp)) {
				map.countries [countryIndex].data.unhappiness = temp;
			}
			dataChanges = true;
		}

		public void CountryResourceChange(){
			double temp;
			if (double.TryParse (GUICountryResource, out temp)) {
				map.countries [countryIndex].data.resource = temp;
			}
			dataChanges = true;
		}

		public void CountryReligionChange(){
			double temp;
			if (double.TryParse (GUICountryReligion, out temp)) {
				map.countries [countryIndex].data.religion = temp;
			}
			dataChanges = true;
		}

		public void CountryGCultistChange(){
			double temp;
			if (double.TryParse (GUICountryGCultist, out temp)) {
				map.countries [countryIndex].data.growthCultist = temp;
			}
			dataChanges = true;
		}

		public void CountryPopulationSChange(){
			int temp;
			if (int.TryParse (GUICountryPopulationS, out temp)) {
				map.countries [countryIndex].data.populationS = temp;
			}
			dataChanges = true;
		}

		/*public void CountryGdpSChange(){
			double temp;
			if (double.TryParse (GUICountryGdpS, out temp)) {
				map.countries [countryIndex].data.GdpS = temp;
			}
			dataChanges = true;
		}

		public void CountryResourceSChange(){
			double temp;
			if (double.TryParse (GUICountryResourceS, out temp)) {
				map.countries [countryIndex].data.resourceS = temp;
			}
			dataChanges = true;
		}*/
    }

}