using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{		
		//lock so that if war <1, war doesnt happen
		public bool isWar = false;

		//is there war on that level
		public bool[] isLevelWar;


		public int warLevelMax;
		public bool[] warLevelCap;

		//public int[] warLevels;

		public int[] warLevelCounts;

		public List<War_GenericEvent> warList;

		private void initializeWarArrays ()
		{
			isLevelWar = new bool[3];
			isLevelWar [0] = false;
			isLevelWar [1] = false;
			isLevelWar [2] = false;


			warLevelCap = new bool[3];
			//warLevels = new int[countries.Length];
			warLevelCounts = new int[3];
			warList = new List<War_GenericEvent> (countries.Length);
		}

		private void warLevelControl()
		{
			for (int i = 0; i < 3; i++)
				warLevelCounts [i] = 0;

			warLevelMax = -1;

			foreach (War_GenericEvent w in warList) {
				warLevelCounts [w.getActualLevel ()]++;
				if (w.getActualLevel () > warLevelMax) {
					warLevelMax = w.getActualLevel ();
				}
			}

			isWar = (warLevelCounts [0] + warLevelCounts [1] + warLevelCounts [2]) > 1;

			for (int i=0;i<3;i++)
				isLevelWar [i] = warLevelCounts [i] > 1;


			if (isWar) {
				for (int i = 2; i >= 0; i--) {
					if (warLevelCounts [i] > 1) {
						warLevelCap [i] = true;
					} else if (warLevelCounts [i] == 1 && i != 0) {
						warLevelCap [i] = false;
						warLevelCounts [i - 1]++;
					} else {
						warLevelCap [i] = false;
					}
				}
			} else {
				warLevelCap [0] = false;
				warLevelCap [1] = false;
				warLevelCap [2] = false;
			}

		}



		private void instantiateWar (int countryIndex)
		{
			if (countries [countryIndex].data.notEliminated) {
				GameObject temp = Instantiate (Resources.Load ("Prefabs/Events/" + "WarGenre" + "Event", typeof(GameObject))) as GameObject;
				War_GenericEvent temp2 = temp.GetComponent<War_GenericEvent> ();
				temp2.setTarget (countryIndex);
				temp2.setCapReference(warLevelCap);
				warList.Add (temp2);
			}
			Debug.Log (countryIndex);
			countries [countryIndex].data.instantiateQueue.Remove ("WarGenre");
		}

		/// <summary>
		/// Instantiates the wars.
		/// </summary>
		/// <param name="flagIndex">Index of ready to instantiate country index.</param>
		/// <param name="count1">Number of ready to instantiate countries.</param>
		public void instantiateWars (int flagIndex, int count1)
		{
			if (flagIndex == -1)
				return; // no notable war events

			if (count1 == 1) {
				singleWar (flagIndex, false);
			} else if (count1 > 1) {
				multipleWars ();
			}






			/*
			//Case where countries want to join an existing war
			if (isWar == true) {
				instantiateWar (flagIndex);
				return;

			}

			//Case where there isnt an ongoing war
			int count2 = 0;
			List<int> tempIndexes = new List<int> ();
			for (int i = 0; i < countries.Length; i++) {
				if (countries [i].data.instantiateQueue.ContainsKey ("WarGenre")) {
					count2++;
					tempIndexes.Add (i);
				}
			}

			//Case where more than one country are wanting to fight
			if (count1 > 1) {
				foreach (int i in tempIndexes) {
					if (countries [i].data.instantiateQueue ["WarGenre"] <= 0) {
						instantiateWar (i);
					}
				}
			}

			//Case where there is only one country wanting to fight
			if (count2 == 1) {
				countries [flagIndex].data.instantiateQueue.Remove ("WarGenre");
				//SEND WARNING "They couldn't find an enemy"
				return;
			}

			//Case where one country is ready while there are also other countries going to join
			int max1 = flagIndex;
			int max2 = -1;
			double minCountdown = 10000;
			foreach (int i in tempIndexes) {
				if (i!=max1 && countries [i].data.instantiateQueue ["WarGenre"] <= minCountdown) {
					max2 = i;
					minCountdown = countries [i].data.instantiateQueue ["WarGenre"];
				}
			}
			instantiateWar (max1);
			instantiateWar (max2);
			*/
		}

		void singleWar(int flagIndex, bool refreshWarArrays){
			if (isLevelWar [War_GenericEvent.estimateLevel (countries [flagIndex].data)]) {
				instantiateWar (flagIndex);
				return;
			}

			int tempEst = War_GenericEvent.estimateLevel (countries [flagIndex].data);

			//if there is a highlevel but supressed country
			if (warLevelCounts [tempEst] == 1) {
				instantiateWar (flagIndex);
				if (refreshWarArrays)
					warLevelControl ();		//refresh arrays after inst
				return;
			}

			bool instFlag = true;

			for (int l = tempEst; l >= 0; l--) {
				if (warLevelCounts [l] >= 1) {
					instantiateWar (flagIndex);
					instFlag = false;
					break;
				}
			}

			if (instFlag) {
				int count2 = 0;
				List<int> tempIndexes = new List<int> ();

				for (int i = 0; i < countries.Length; i++) {
					if (countries [i].data.instantiateQueue.ContainsKey ("WarGenre")) {
						count2++;
						tempIndexes.Add (i);
					}
				}

				int max1 = flagIndex;
				int max2 = -1;
				double minCountdown = 10000;
				foreach (int i in tempIndexes) {
					if (War_GenericEvent.estimateLevel(countries[i].data) == tempEst && countries [i].data.instantiateQueue ["WarGenre"] <= minCountdown && i!=max1) {
						max2 = i;
						minCountdown = countries [i].data.instantiateQueue ["WarGenre"];
					}
				}

				//not even ready countries of the same level
				if (max2 == -1) {
					int tempLevel = 0;
					foreach (int i in tempIndexes) {
						tempLevel = War_GenericEvent.estimateLevel (countries [i].data);
						if (tempLevel > tempEst && warLevelCounts[tempLevel] == 0 && warLevelCounts[tempLevel-1] == 0 && countries [i].data.instantiateQueue ["WarGenre"] <= minCountdown && i!=max1) {
							max2 = i;
							minCountdown = countries [i].data.instantiateQueue ["WarGenre"];
						}
					}
					//if not even higher level countries exist
					if (max2 == -1) {
						//delete event.
						countries [flagIndex].data.instantiateQueue.Remove ("WarGenre");
						if (countries [flagIndex].data.modQueue.Contains ("WarGenre")) {
							countries [flagIndex].data.modDestroyQueue.Add ("WarGenre");
						}

						return;
					}
				}

				instantiateWar (max1);
				instantiateWar (max2);
			}


		}

		void multipleWars(){
		
			bool isLeftOver = false;
			List<int> readyIndices = new List<int>();

			for (int i = 0; i < countries.Length; i++) {
				if (countries [i].data.instantiateQueue.ContainsKey ("WarGenre") && countries [i].data.instantiateQueue ["WarGenre"] <= 0){
					if (isLevelWar [War_GenericEvent.estimateLevel (countries [i].data)]) {
						instantiateWar (i);
					} else {
						isLeftOver = true;
						readyIndices.Add (i);
					}
				}
			}

			//Check if there are any that failed to instantiate
			if (!isLeftOver) {
				return;
			}

			foreach (int i in readyIndices) {
				singleWar (i, true);
			}

		}
			
	}



}

