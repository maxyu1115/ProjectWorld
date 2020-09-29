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

		void ShowNDEditor(){
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   TornadoBuff", GUILayout.Width (90));
			_editor.GUICountryTornadoBuff = EditorGUILayout.TextField (_editor.GUICountryTornadoBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryTornadoBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryTornadoBuff = "" + _editor.map.countries [_editor.countryIndex].data.tornadoBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   EarthquakeBuff", GUILayout.Width (90));
			_editor.GUICountryEarthquakeBuff = EditorGUILayout.TextField (_editor.GUICountryEarthquakeBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryEarthquakeBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryEarthquakeBuff = "" + _editor.map.countries [_editor.countryIndex].data.earthquakeBuff;

			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   FireBuff", GUILayout.Width (90));
			_editor.GUICountryWildfireBuff = EditorGUILayout.TextField (_editor.GUICountryWildfireBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryWildfireBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryWildfireBuff = "" + _editor.map.countries [_editor.countryIndex].data.wildfireBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   DroughtBuff", GUILayout.Width (90));
			_editor.GUICountryDroughtBuff = EditorGUILayout.TextField (_editor.GUICountryDroughtBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryDroughtBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryDroughtBuff = "" + _editor.map.countries [_editor.countryIndex].data.droughtBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   FloodBuff", GUILayout.Width (90));
			_editor.GUICountryFloodBuff = EditorGUILayout.TextField (_editor.GUICountryFloodBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryFloodBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryFloodBuff = "" + _editor.map.countries [_editor.countryIndex].data.floodBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   FrostBuff", GUILayout.Width (90));
			_editor.GUICountryFrostBuff = EditorGUILayout.TextField (_editor.GUICountryFrostBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryReligionChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryFrostBuff = "" + _editor.map.countries [_editor.countryIndex].data.frostBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Meteor", GUILayout.Width (90));
			_editor.GUICountryMeteorBuff = EditorGUILayout.TextField (_editor.GUICountryMeteorBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryMeteorBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryMeteorBuff = "" + _editor.map.countries [_editor.countryIndex].data.meteorBuff;
			}
			EditorGUILayout.EndHorizontal ();


			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("   Volcano", GUILayout.Width (90));
			_editor.GUICountryVolcanoBuff = EditorGUILayout.TextField (_editor.GUICountryVolcanoBuff);
			if (GUILayout.Button ("Change")) {
				_editor.CountryVolcanoBuffChange ();
			}
			if (GUILayout.Button ("Undo")) {
				_editor.GUICountryVolcanoBuff = "" + _editor.map.countries [_editor.countryIndex].data.volcanoBuff;
			}
			EditorGUILayout.EndHorizontal ();




		}


		bool SaveNDChanges ()
		{

			if (!_editor.ndChanges)
				return false;

			// First we make a backup if it doesn't exist
			string geoDataFolder;
			CheckDataBackup (out geoDataFolder);

			string dataFileName, fullPathName;
			// Save changes to countries
			if (_editor.ndChanges) {
				dataFileName = "nd10.txt";
				fullPathName = GetAssetsFolder () + geoDataFolder + "/" + dataFileName;
				string data = _editor.GetCountryNDData ();
				File.WriteAllText (fullPathName, data, System.Text.Encoding.UTF8);
				_editor.ndChanges = false;
			}
			AssetDatabase.Refresh ();
			return true;
		}
	}
}

