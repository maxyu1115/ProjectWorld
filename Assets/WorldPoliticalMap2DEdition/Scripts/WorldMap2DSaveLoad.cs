using UnityEngine;
//using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;


namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{
		public int dataSlot;


		public void saveGame(){
			BinaryFormatter bf = new BinaryFormatter ();
			saveGameData (bf);
			saveRegionData (bf);

		}

		private void saveGameData(BinaryFormatter bf){
			FileStream streamGameData = new FileStream (Application.persistentDataPath + "/" + dataSlot + ".gd", FileMode.Create);

			GameData gd = new GameData ();
			gd.winFlag = winFlag;
			gd.turnTime = turnTime;
			gd.monthTime = monthTime;
			gd.worldMonth = worldMonth;
			gd.worldYear = worldYear;
			gd.isWar = isWar;
			gd.isLevelWar = isLevelWar;
			gd.warLevelCap = warLevelCap;
			gd.warLevelCounts = warLevelCounts;
			gd.warLevelMax = warLevelMax;

			bf.Serialize (streamGameData, gd);
			streamGameData.Close ();
		}

		private void saveRegionData(BinaryFormatter bf){
			FileStream streamRegionData = new FileStream (Application.persistentDataPath + "/" + dataSlot + ".rd", FileMode.Create);

			SaveRegionData[] rd = new SaveRegionData[countries.Length];
			for (int i = 0; i < countries.Length; i++) {
				rd [i] = new SaveRegionData ();
				rd [i].saveRegionData (countries [i].data);
			}

			bf.Serialize (streamRegionData, rd);
			streamRegionData.Close ();
		}

		private void saveEventData(BinaryFormatter bf){
			GameObject[] events = GameObject.FindGameObjectsWithTag("Event");
			SaveEventData[] ed = new SaveEventData[events.Length];
			Disasters temp;

			for (int i = 0; i < events.Length; i++) {
				temp = events [i].GetComponent<Disasters> ();
				ed [i] = temp.saveEventData ();
			}

			FileStream streamEventData = new FileStream (Application.persistentDataPath + "/" + dataSlot + ".ed", FileMode.Create);
			bf.Serialize (streamEventData, ed);
			streamEventData.Close ();
		}

		private void saveModData(BinaryFormatter bf){
			ModData[] md = new ModData[disasterMods.Count];
			for (int i = 0; i < disasterMods.Count; i++) {
				md [i] = new ModData ();
				md [i].saveModData (disasterMods [i]);
			}
			FileStream streamModData = new FileStream (Application.persistentDataPath + "/" + dataSlot + ".md", FileMode.Create);
			bf.Serialize (streamModData, md);
			streamModData.Close ();

		}


		public void loadGame(){
			BinaryFormatter bf = new BinaryFormatter ();
			loadGameData (bf);
			loadRegionData (bf);

		}

		private void loadGameData(BinaryFormatter bf){
			string path = Application.persistentDataPath + "/" + dataSlot + ".gd";
			if (!File.Exists (path)) {
				Debug.Log ("error");
				return;
			}
				
			FileStream streamGameData = new FileStream (path, FileMode.Open);

			GameData gd = bf.Deserialize (streamGameData) as GameData;
			streamGameData.Close ();

			winFlag = gd.winFlag;
			turnTime = gd.turnTime;
			monthTime = gd.monthTime;
			worldMonth = gd.worldMonth;
			_worldYear = gd.worldYear;
			isWar = gd.isWar;
			isLevelWar = gd.isLevelWar;
			warLevelCap = gd.warLevelCap;
			warLevelCounts = gd.warLevelCounts;
			warLevelMax = gd.warLevelMax;

		}

		private void loadRegionData(BinaryFormatter bf){
			string path = Application.persistentDataPath + "/" + dataSlot + ".rd";
			if (!File.Exists (path)) {
				Debug.Log ("error");
				return;
			}
			FileStream streamRegionData = new FileStream (path, FileMode.Open);
			SaveRegionData[] rd = bf.Deserialize(streamRegionData) as SaveRegionData[];
			streamRegionData.Close ();

			GameObject temp;
			EventMod temp2;
			for (int i = 0; i < countries.Length; i++) {
				countries [i].data = rd [i].loadRegionData ();
				foreach (string modName in countries[i].data.modQueue) {
					temp = Instantiate (Resources.Load ("Prefabs/Mods/" + modName + "Mod", typeof(GameObject))) as GameObject;
					temp2 = temp.GetComponent<EventMod> ();
					temp2.loadMod (countries [i]);
				}
			}
		}

		private void loadEventData(BinaryFormatter bf){
			string path = Application.persistentDataPath + "/" + dataSlot + ".ed";
			if (!File.Exists (path)) {
				Debug.Log ("error");
				return;
			}
			FileStream streamEventData = new FileStream (path, FileMode.Open);
			SaveEventData[] ed = bf.Deserialize(streamEventData) as SaveEventData[];
			streamEventData.Close ();

			GameObject temp;
			Disasters temp2;
			foreach (SaveEventData e in ed) {
				temp = Instantiate (Resources.Load ("Prefabs/Events/" + e.eventName + "Event", typeof(GameObject))) as GameObject;
				temp2 = temp.GetComponent<Disasters> ();
				temp2.loadEventData (e);
			}
		}

		private void loadModData(BinaryFormatter bf){
			string path = Application.persistentDataPath + "/" + dataSlot + ".md";
			if (!File.Exists (path)) {
				Debug.Log ("error");
				return;
			}
			FileStream streamModData = new FileStream (path, FileMode.Open);
			ModData[] md = bf.Deserialize(streamModData) as ModData[];
			disasterMods.Clear ();
			for (int i = 0; i < md.Length; i++) {
				disasterMods.Add (md [i].loadModData());
			}
			streamModData.Close ();
		}



	}

	[Serializable]
	public class GameData
	{
		public bool winFlag;

		public double turnTime;
		public double monthTime;

		public int worldMonth;
		public int worldYear;

		public bool isWar;

		public bool[] isLevelWar;

		public int warLevelMax;
		public bool[] warLevelCap;

		public int[] warLevelCounts;
	}

	[Serializable]
	public class ModData
	{
		public string modName;
		public string[] modCountryNames;
		public double[] modCountryValues;

		public void saveModData (ModList m){
			modName = m.DisasterName;

			List<string> names = new List<string> ();
			List<double> values = new List<double> ();
			foreach (KeyValuePair <string, double> KP in m.eventMods) {
				names.Add (KP.Key);
				values.Add (KP.Value);
			}
			modCountryNames = names.ToArray ();
			modCountryValues = values.ToArray ();
		}

		public ModList loadModData (){
			ModList m = new ModList (modName);

			for (int i = 0; i < modCountryNames.Length; i++) {
				m.eventMods.Add (modCountryNames [i], modCountryValues [i]);
			}

			return m;
		}


	}
}

