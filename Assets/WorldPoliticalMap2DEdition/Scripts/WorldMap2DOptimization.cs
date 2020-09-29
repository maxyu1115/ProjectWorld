using UnityEngine;
using System.Collections;
using System;


namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{


		public bool tutorialMode = false;
		
		#region triangulator optimization

		public bool preloadTriangulators = true;


		public int[][][] countryTriangulated;


		public void initTriangulators ()
		{
			if (!preloadTriangulators)
				return;
			LoadPrecalculatedTriangulators ();
		}

		public void refreshTriangulators ()
		{
			countryTriangulated = new int[countries.Length][][];
			for (int i = 0; i < countries.Length; i++) {
				countryTriangulated [i] = new int[countries [i].regions.Count][];
				for (int j = 0; j < countries [i].regions.Count; j++) {
					countryTriangulated [i] [j] = Triangulator.GetPoints (countries [i].regions [j].points);
				}
			}
		}

		public void LoadPrecalculatedTriangulators ()
		{
			lastCountryLookupCount = -1;

			string frontiersFileName = "WPMF/Geodata/triangulator10";
			TextAsset ta = Resources.Load<TextAsset> (frontiersFileName);
			string s = ta.text;
			string[] countryList = s.Split (new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

			bool conflictError = false;

			int countryCount = countryList.Length;
			if (countryCount != countries.Length)
				conflictError = true;

			char[] separatorName = new char[] { '%' };
			char[] separatorRegion = new char[]{ ';' };
			char[] separatorRegionIndex = new char[] { '*' };
			char[] separatorData = new char[] { ',' };

			string[] temp1, countryTPoints, temp2, regionTPoints;

			countryTriangulated = new int[countries.Length][][];

			for (int k = 0; k < countryCount; k++) {

				if (conflictError)
					break;

				temp1 = countryList [k].Split (separatorName, StringSplitOptions.RemoveEmptyEntries); //temp1[0]==Country Name, temp1[1]==Country Index
				if (temp1 [0].CompareTo (countries [k].name) != 0 || temp1 [1].CompareTo (k + "") != 0) {
					conflictError = true;
					break;
				}

				countryTPoints = temp1 [2].Split (separatorRegion, StringSplitOptions.RemoveEmptyEntries);
				temp1 [2] = "";//release memory
				if (countryTPoints.Length != countries [k].regions.Count) {
					conflictError = true;
					break;
				}

				countryTriangulated [k] = new int[countries [k].regions.Count][];

				for (int r = 0; r < countries [k].regions.Count; r++) {
					temp2 = countryTPoints [r].Split (separatorRegionIndex, StringSplitOptions.RemoveEmptyEntries); //temp2[0]==Region Index
					if (temp2 [0].CompareTo (r + "") != 0) {
						conflictError = true;
						break;
					}
					regionTPoints = temp2 [1].Split (separatorData, StringSplitOptions.RemoveEmptyEntries);
					temp2 [1] = ""; //release memory
					countryTriangulated [k] [r] = Array.ConvertAll(regionTPoints, Int32.Parse);
				}

			}
			if (conflictError) {
				Debug.Log ("data conflict");
				refreshTriangulators ();
			}
		}

		#endregion



		//unfinished
		private void optimizeReadCountryData ()
		{
			Country c;
			for (int i = 0; i < countries.Length; i++) {
				c = countries [i];

				foreach (Region r in c.regions) {
					
				}


			}
		}


	}
}

