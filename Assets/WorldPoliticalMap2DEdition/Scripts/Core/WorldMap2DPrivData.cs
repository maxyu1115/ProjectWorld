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
        void ReadDataPackedString()
        {
            lastCountryLookupCount = -1;
            string frontiersFileName = "WPMF/Geodata/data10";
            TextAsset ta = Resources.Load<TextAsset>(frontiersFileName);
            string s = ta.text;
            string[] dataList = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            int countryCount = dataList.Length;

            char[] separatorName = new char[] { '%' };

            char[] separatorData = new char[] { '$' };

            int index = 0;

            for (int k = 0; k < countryCount; k++)
            {
                string[] temp = dataList[k].Split(separatorName, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    index = countryLookup[temp[0]];
                    string[] countryData = temp[1].Split(separatorData, StringSplitOptions.RemoveEmptyEntries);

                    int v1 = 0;
                    double v2 = 0;
                    if (int.TryParse(countryData[0], out v1))
                    {
                        countries[index].data.population = v1;
                        countries[index].data.populationMax = (int)(1.1f * v1);
                    }
                    if (int.TryParse(countryData[1], out v1))
                    {
                        countries[index].data.gdp = v1;
                        countries[index].data.gdpMax = (int)(1.1f * v1);
                    }
                    if (double.TryParse(countryData[2], out v2))
                    {
                        countries[index].data.technology = v2;
                    }
                    if (double.TryParse(countryData[3], out v2))
                    {
                        countries[index].data.unhappiness = v2;     //questionable
                    }
                    if (double.TryParse(countryData[4], out v2))
                    {
                        countries[index].data.resource = v2;
                    }
                    if (double.TryParse(countryData[5], out v2))
                    {
                        countries[index].data.religion = v2;
                    }
                    if (double.TryParse(countryData[6], out v2))
                    {
                        countries[index].data.growthCultist = v2;
                    }
					if (int.TryParse(countryData[7], out v1))
					{
						countries[index].data.populationS = v1;
					}
					/*if (double.TryParse(countryData[8], out v2))
					{
						countries[index].data.GdpS = v2;
					}
					if (double.TryParse(countryData[9], out v2))
					{
						countries[index].data.resourceS = v2;
					}*/

                }

                catch (Exception e)
                {
                    
                    Debug.Log("Fck");
                }

                



            }
        }



		void ReadNDPackedString()
		{
			lastCountryLookupCount = -1;
			string frontiersFileName = "WPMF/Geodata/nd10";
			TextAsset ta = Resources.Load<TextAsset>(frontiersFileName);
			string s = ta.text;
			string[] dataList = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			int countryCount = dataList.Length;

			char[] separatorName = new char[] { '%' };

			char[] separatorData = new char[] { '$' };

			int index = 0;

			for (int k = 0; k < countryCount; k++)
			{
				string[] temp = dataList[k].Split(separatorName, StringSplitOptions.RemoveEmptyEntries);
				try
				{
					index = countryLookup[temp[0]];
					string[] countryData = temp[1].Split(separatorData, StringSplitOptions.RemoveEmptyEntries);

					double v2 = 0;
					if (double.TryParse(countryData[0], out v2))
					{
						countries[index].data.tornadoBuff = v2;
					}
					if (double.TryParse(countryData[1], out v2))
					{
						countries[index].data.earthquakeBuff = v2;
					}
					if (double.TryParse(countryData[2], out v2))
					{
						countries[index].data.wildfireBuff = v2;
					}
					if (double.TryParse(countryData[3], out v2))
					{
						countries[index].data.droughtBuff = v2;     //questionable
					}
					if (double.TryParse(countryData[4], out v2))
					{
						countries[index].data.floodBuff = v2;
					}
					if (double.TryParse(countryData[5], out v2))
					{
						countries[index].data.frostBuff = v2;
					}
					if (double.TryParse(countryData[6], out v2))
					{
						countries[index].data.meteorBuff = v2;
					}
					if (double.TryParse(countryData[7], out v2))
					{
						countries[index].data.volcanoBuff = v2;
					}
				}

				catch (Exception e)
				{

					Debug.Log("Fck");
				}
					


			}
		}
    }
}