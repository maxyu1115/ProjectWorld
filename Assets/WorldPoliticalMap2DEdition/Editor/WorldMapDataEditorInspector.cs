using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WPMF;

namespace WPMF
{
    
    public partial class WorldMap2D_EditorInspector : Editor
    {
        
		void ShowDataEditor(){
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Population", GUILayout.Width (90));
			_editor.GUICountryPopulation = EditorGUILayout.TextField (_editor.GUICountryPopulation);
			if (GUILayout.Button ("Change")) {
				_editor.CountryPopulationChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryPopulation = "" + _editor.map.countries [_editor.countryIndex].data.population;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   GDP", GUILayout.Width (90));
			_editor.GUICountryGdp = EditorGUILayout.TextField (_editor.GUICountryGdp);
			if (GUILayout.Button ("Change")) {
				_editor.CountryGdpChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryGdp = "" + _editor.map.countries [_editor.countryIndex].data.gdp;

			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Technology", GUILayout.Width (90));
			_editor.GUICountryTechnology = EditorGUILayout.TextField (_editor.GUICountryTechnology);
			if (GUILayout.Button ("Change")) {
				_editor.CountryTechnologyChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryTechnology = "" + _editor.map.countries [_editor.countryIndex].data.technology;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Unhappiness", GUILayout.Width (90));
			_editor.GUICountryUnhappiness = EditorGUILayout.TextField (_editor.GUICountryUnhappiness);
			if (GUILayout.Button ("Change")) {
				_editor.CountryUnhappinessChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryUnhappiness = "" + _editor.map.countries [_editor.countryIndex].data.unhappiness;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Resource", GUILayout.Width (90));
			_editor.GUICountryResource = EditorGUILayout.TextField (_editor.GUICountryResource);
			if (GUILayout.Button ("Change")) {
				_editor.CountryResourceChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryResource = "" + _editor.map.countries [_editor.countryIndex].data.resource;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Religion", GUILayout.Width (90));
			_editor.GUICountryReligion = EditorGUILayout.TextField (_editor.GUICountryReligion);
			if (GUILayout.Button ("Change")) {
				_editor.CountryReligionChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryReligion = "" + _editor.map.countries [_editor.countryIndex].data.religion;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   gCultist", GUILayout.Width (90));
			_editor.GUICountryGCultist = EditorGUILayout.TextField (_editor.GUICountryGCultist);
			if (GUILayout.Button ("Change")) {
				_editor.CountryGCultistChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryGCultist = "" + _editor.map.countries [_editor.countryIndex].data.growthCultist;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   PopulationS", GUILayout.Width (90));
			_editor.GUICountryPopulationS = EditorGUILayout.TextField (_editor.GUICountryPopulationS);
			if (GUILayout.Button ("Change")) {
				_editor.CountryPopulationSChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryPopulationS = "" + _editor.map.countries [_editor.countryIndex].data.populationS;
			}
			EditorGUILayout.EndHorizontal ();


			/*EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   GdpS", GUILayout.Width (90));
			_editor.GUICountryGdpS = EditorGUILayout.TextField (_editor.GUICountryGdpS);
			if (GUILayout.Button ("Change")) {
				_editor.CountryGdpSChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryGdpS = "" + _editor.map.countries [_editor.countryIndex].data.GdpS;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   ResourceS", GUILayout.Width (90));
			_editor.GUICountryResourceS = EditorGUILayout.TextField (_editor.GUICountryResourceS);
			if (GUILayout.Button ("Change")) {
				_editor.CountryResourceSChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryResourceS = "" + _editor.map.countries [_editor.countryIndex].data.resourceS;
			}
			EditorGUILayout.EndHorizontal ();*/

		}


		bool SaveDataChanges ()
		{

			if (!_editor.dataChanges)
				return false;

			// First we make a backup if it doesn't exist
			string geoDataFolder;
			CheckDataBackup (out geoDataFolder);

			string dataFileName, fullPathName;
			// Save changes to countries
			if (_editor.dataChanges) {
				dataFileName = "data10.txt";
				fullPathName = GetAssetsFolder () + geoDataFolder + "/" + dataFileName;
				string data = _editor.GetCountryData ();
				File.WriteAllText (fullPathName, data, System.Text.Encoding.UTF8);
				_editor.dataChanges = false;
			}
			AssetDatabase.Refresh ();
			return true;
		}

		static void CheckDataBackup (out string geoDataFolder)
		{
			string[] paths = AssetDatabase.GetAllAssetPaths ();
			bool backupFolderExists = false;
			string rootFolder = "";
			geoDataFolder = "";
			for (int k = 0; k < paths.Length; k++) {
				if (paths [k].EndsWith ("Resources/WPMF/Geodata")) {
					geoDataFolder = paths [k]; 
				} else if (paths [k].EndsWith ("WorldPoliticalMap2DEdition")) {
					rootFolder = paths [k];
				} else if (paths [k].EndsWith ("WorldPoliticalMap2DEdition/Backup")) {
					backupFolderExists = true;
				}
			}

			if (!backupFolderExists) {
				// Do the backup
				AssetDatabase.CreateFolder (rootFolder, "Backup");
				string backupFolder = rootFolder + "/Backup";
				string fullFileName = geoDataFolder + "/data10.txt";
				if (File.Exists (fullFileName)) { 
					AssetDatabase.CopyAsset (fullFileName, backupFolder + "/data10.txt");
				}

			}
		}



    }
    


}