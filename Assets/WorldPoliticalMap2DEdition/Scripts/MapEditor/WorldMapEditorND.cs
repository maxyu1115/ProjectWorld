using UnityEngine;
/*using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;*/
using System.Text;
//using WPMF;


namespace WPMF
{

	public partial class WorldMap2D_Editor : MonoBehaviour
	{

		public bool ndChanges;

		public string GUICountryTornadoBuff="";
		public string GUICountryEarthquakeBuff="";
		public string GUICountryWildfireBuff="";
		public string GUICountryDroughtBuff="";
		public string GUICountryFloodBuff="";
		public string GUICountryFrostBuff="";
		public string GUICountryMeteorBuff="";
		public string GUICountryVolcanoBuff="";


		public string GetCountryNDData () {
			StringBuilder sb = new StringBuilder ();
			for (int k = 0; k < map.countries.Length; k++) {
				Country country = map.countries [k];
				if (k > 0)
					sb.Append ("|");
				sb.Append (country.name + "%");
				sb.Append (country.data.tornadoBuff + "$");
				sb.Append (country.data.earthquakeBuff + "$");
				sb.Append (country.data.wildfireBuff + "$");
				sb.Append (country.data.droughtBuff + "$");
				sb.Append (country.data.floodBuff + "$");
				sb.Append (country.data.frostBuff + "$");
				sb.Append (country.data.meteorBuff + "$");
				sb.Append (country.data.volcanoBuff + "$");
			}
			return sb.ToString ();
		}
			
		public void mergeCountryNDData (Country source, Country target){
			float a1 = source.regions [source.mainRegionIndex].rect2D.width * source.regions [source.mainRegionIndex].rect2D.height;
			float a2 = target.regions [target.mainRegionIndex].rect2D.width * target.regions [target.mainRegionIndex].rect2D.height;

			if (a2 >= a1) {
				return;
			}

			target.data.tornadoBuff = source.data.tornadoBuff;
			target.data.earthquakeBuff = source.data.earthquakeBuff;
			target.data.wildfireBuff = source.data.wildfireBuff;
			target.data.droughtBuff = source.data.droughtBuff;
			target.data.floodBuff = source.data.floodBuff;
			target.data.frostBuff = source.data.frostBuff;
			target.data.meteorBuff = source.data.meteorBuff;
			target.data.volcanoBuff = source.data.volcanoBuff;



		}

		public void GUIDataNDRefresh(){
			GUICountryTornadoBuff=""+map.countries[countryIndex].data.tornadoBuff;
			GUICountryEarthquakeBuff=""+map.countries[countryIndex].data.earthquakeBuff;
			GUICountryWildfireBuff=""+map.countries[countryIndex].data.wildfireBuff;
			GUICountryDroughtBuff=""+map.countries[countryIndex].data.droughtBuff;
			GUICountryFloodBuff=""+map.countries[countryIndex].data.floodBuff;
			GUICountryFrostBuff=""+map.countries[countryIndex].data.frostBuff;
			GUICountryMeteorBuff=""+map.countries[countryIndex].data.meteorBuff;
			GUICountryVolcanoBuff = "" + map.countries [countryIndex].data.volcanoBuff;
		}


		public void ClearDataNDSelection(){
			GUICountryTornadoBuff="";
			GUICountryEarthquakeBuff="";
			GUICountryWildfireBuff="";
			GUICountryDroughtBuff="";
			GUICountryFloodBuff="";
			GUICountryFrostBuff="";
			GUICountryMeteorBuff="";
			GUICountryVolcanoBuff = "";
		}

		public void CountryTornadoBuffChange(){
			double temp;
			if (double.TryParse (GUICountryTornadoBuff, out temp)) {
				map.countries [countryIndex].data.tornadoBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryEarthquakeBuffChange(){
			double temp;
			if (double.TryParse (GUICountryEarthquakeBuff, out temp)) {
				map.countries [countryIndex].data.earthquakeBuff = temp;
			}
			ndChanges = true;
		}



		public void CountryWildfireBuffChange(){
			double temp;
			if (double.TryParse (GUICountryWildfireBuff, out temp)) {
				map.countries [countryIndex].data.wildfireBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryDroughtBuffChange(){
			double temp;
			if (double.TryParse (GUICountryDroughtBuff, out temp)) {
				map.countries [countryIndex].data.droughtBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryFloodBuffChange(){
			double temp;
			if (double.TryParse (GUICountryFloodBuff, out temp)) {
				map.countries [countryIndex].data.floodBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryFrostBuffChange(){
			double temp;
			if (double.TryParse (GUICountryFrostBuff, out temp)) {
				map.countries [countryIndex].data.frostBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryMeteorBuffChange(){
			double temp;
			if (double.TryParse (GUICountryMeteorBuff, out temp)) {
				map.countries [countryIndex].data.meteorBuff = temp;
			}
			ndChanges = true;
		}

		public void CountryVolcanoBuffChange(){
			double temp;
			if (double.TryParse (GUICountryVolcanoBuff, out temp)) {
				map.countries [countryIndex].data.volcanoBuff = temp;
			}
			ndChanges = true;
		}
	}

}