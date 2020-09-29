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

		public bool triangulatorChanges;

		public string getTriangulators () {

			map.refreshTriangulators ();

			StringBuilder sb = new StringBuilder ();
			for (int c = 0; c < map.countries.Length; c++) {

				sb.Append (map.countries [c].name + "%" + c + "%");

				for (int r = 0; r < map.countries [c].regions.Count; r++) {
					sb.Append (r + "*");
					for (int i = 0; i < map.countryTriangulated [c] [r].Length; i++) {
						sb.Append (map.countryTriangulated [c] [r] [i]+",");
					}
					sb.Append (";");
				}

				sb.Append ("|");


			}
			return sb.ToString ();
		}


	}
}
