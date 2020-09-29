using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{
		public GameObject ErrorLog;
		public Text errorMessage;
		private HashSet<string> errorList = new HashSet<string>();


		private void debugCheck(){
			if (Energy < 0) {
				ErrorLog.SetActive (true);
				foreach(Country c in countries){
					if (double.IsNaN (c.data.population) || double.IsInfinity (c.data.population))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.gdp) || double.IsInfinity (c.data.gdp))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.technology) || double.IsInfinity (c.data.technology))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.resource) || double.IsInfinity (c.data.resource))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.religion) || double.IsInfinity (c.data.religion))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.cultist) || double.IsInfinity (c.data.cultist))
						errorList.Add (c.name);
					if (double.IsNaN (c.data.calculateTotalUnhappiness()) || double.IsInfinity (c.data.calculateTotalUnhappiness()))
						errorList.Add (c.name);
					}

				if (errorList.Count > 0) {
					Time.timeScale = 0;

					StringBuilder temp = new StringBuilder();
					Country tempC;
					foreach (string s in errorList)
					{
						tempC = countries[GetCountryIndex (s)];

						temp.Append(s).Append(": ");
						foreach (string ss in tempC.data.eventQueue)
						{
							temp.Append(ss).Append(", ");
						}
						temp.Append ("; ");
						if (double.IsNaN (tempC.data.population) || double.IsInfinity (tempC.data.population))
							temp.Append("P, ");
						if (double.IsNaN (tempC.data.gdp) || double.IsInfinity (tempC.data.gdp))
							temp.Append("G, ");
						if (double.IsNaN (tempC.data.technology) || double.IsInfinity (tempC.data.technology))
							temp.Append("T, ");
						if (double.IsNaN (tempC.data.resource) || double.IsInfinity (tempC.data.resource))
							temp.Append("R1, ");
						if (double.IsNaN (tempC.data.religion) || double.IsInfinity (tempC.data.religion))
							temp.Append("R2, ");
						if (double.IsNaN (tempC.data.cultist) || double.IsInfinity (tempC.data.cultist))
							temp.Append("C, ");
						if (double.IsNaN (tempC.data.calculateTotalUnhappiness()) || double.IsInfinity (tempC.data.calculateTotalUnhappiness()))
							temp.Append("U, ");
						temp.Append("\n");
					}
					errorMessage.text="Countries with error:\n "+temp.ToString();
				}
			}
		}

	}
}
