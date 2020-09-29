using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using WPMF;
using System.IO;

namespace WPMF
{

	public partial class WorldMap2D_EditorInspector : Editor{


		void ShowTriangulatorEditor(){
			EditorGUILayout.BeginHorizontal ();
			if (GUILayout.Button ("Update Triangulators")) {
				ForceTriangulatoUpdate ();
			}
			EditorGUILayout.EndHorizontal ();
		}

		void ForceTriangulatoUpdate(){
			_editor.triangulatorChanges = true;
			SaveTriangulators ();
		}

		bool SaveTriangulators ()
		{

			if (!_editor.triangulatorChanges)
				return false;

			// First we make a backup if it doesn't exist
			string geoDataFolder;
			string[] paths = AssetDatabase.GetAllAssetPaths ();
			geoDataFolder = "";
			for (int k = 0; k < paths.Length; k++) {
				if (paths [k].EndsWith ("Resources/WPMF/Geodata")) 
					geoDataFolder = paths [k]; 
			}

			string dataFileName, fullPathName;
			// Save changes to countries
			if (_editor.triangulatorChanges) {
				dataFileName = "triangulator10.txt";
				fullPathName = GetAssetsFolder () + geoDataFolder + "/" + dataFileName;
				string data = _editor.getTriangulators ();
				File.WriteAllText (fullPathName, data, System.Text.Encoding.UTF8);
				_editor.triangulatorChanges = false;
			}
			AssetDatabase.Refresh ();
			return true;
		}


		/*
		private void optimizeCountryPoints(){
			Country c;
			List<Region> newRegions=new List<Region>();
			Region temp;

			for (int i = 0; i < _map.countries.Length; i++) {
				c = _map.countries [i];

				newRegions.Clear ();


				foreach (Region r in c.regions) {
					if (r.points.Length <= 10) {
						continue;
					}
						
				}


			}
		}*/

	}

}

