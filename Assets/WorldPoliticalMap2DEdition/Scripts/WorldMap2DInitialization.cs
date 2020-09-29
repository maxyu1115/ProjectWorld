using UnityEngine;
using System.Collections;
using System;


namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{

		static SpriteArchive _sArchive = null;

		/// <summary>
		/// Instance of the world map. Use this property to access World Map functionality.
		/// </summary>
		public static SpriteArchive sArchive {
			get {
				if (_sArchive == null) {
					_sArchive = FindObjectOfType<SpriteArchive>();
					if (_sArchive == null) {
						Debug.LogWarning ("'WorldMap2D' GameObject could not be found in the scene. Make sure it's created with this name before using any map functionality.");
					}
				}
				return _sArchive;
			}
		}
		
		void initGame(){
			Debug.Log ("WorldMap2D init");
			if (!tutorialMode) {
				createDisasterTrigger ();
				initializeDisasterMods ();
				initializeCostFuncs ();
				initializeWarArrays ();

			}
			initTriangulators (); //MUST be placed before cult coloring

			initializeCultColoring ();


			refreshCountryNeighbors ();

			//GameObject temp = GameObject.Find ("Loading");
			//loading.SetActive (false);
			//InvokeRepeating("TurnRefresh", 0 * REFRESHRATE, 60 * REFRESHRATE);

			//initEventDisplayers ();

			Debug.Log("WorldMap2D init success");
		}

		void initEventDisplayers() {
			GameObject parent = GameObject.Find("IconDisplayerParent");
			int childs = parent.transform.childCount;
			for (int i = childs - 1; i >= 0; i--)
			{
				DestroyImmediate (parent.transform.GetChild(i).gameObject);
			}


			foreach (Country c in countries) {
				//c.labelMeshCenter
				GameObject temp = Instantiate (Resources.Load<GameObject> ("Prefabs/IconDisplayer Prefab")) as GameObject;

				temp.transform.position = new Vector3 (c.labelMeshCenter.x, c.labelMeshCenter.y, 
					temp.transform.position.z);

				temp.transform.SetParent (parent.transform);
				//temp.transform.SetPositionAndRotation (c.labelMeshCenter, c.labelRotation);

				//temp.transform.rotation.eulerAngles.Set

				//Debug.Log ("icon displayer instantiated.");

				EventDisplayer temp2 = temp.GetComponent<EventDisplayer> ();
				temp2.setTarget (c);
			}
		}

	}

}

