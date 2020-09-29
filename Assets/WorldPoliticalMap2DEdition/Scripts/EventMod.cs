using UnityEngine;
using WPMF;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class EventMod : MonoBehaviour {

	public string eventName;	
	public int modLevel;

	WorldMap2D map;

	Country target;

	public string targetName;

	private bool loadStatus = false;

	private void Start()
	{
		if (!loadStatus) {
			
			if (!map.deductEnergy (map.getCost (map.modTargetIndex, eventName), map.modTargetIndex)) {
				map.modTargetIndex = -1;
				Destroy (this.gameObject);
			}

			targetName = target.name;

			target.data.modQueue.Add (eventName);

			map.modTargetIndex = -1;

			ModProbability ();

		}
        this.gameObject.transform.position = new Vector3(target.center.x * WorldMap2D.mapWidth, target.center.y * WorldMap2D.mapHeight, 86);
    }

	public void setTarget (Country c)
	{
		map = WorldMap2D.instance;
		target=c;
	}

	public void loadMod (Country c){
		map = WorldMap2D.instance;
		target=c;
		loadStatus = true;
	}

    private void Update()
    {
        if (target.data.modDestroyQueue.Contains(eventName) || !target.data.notEliminated)
        {


            Destroy(this.gameObject);
        }
    }

	private void OnDestroy()
	{
		target.data.modDestroyQueue.Remove (eventName);
		target.data.modQueue.Remove (eventName);

		var mod=(from p in map.disasterMods
			where p.DisasterName == eventName
			select p).First();
		mod.eventMods.Remove (target.name);

	}

    void ModProbability()
	{

		var mod=(from p in map.disasterMods
				where p.DisasterName == eventName
			select p).First();

		if (mod.eventMods.ContainsKey (target.name)) {
			mod.eventMods [target.name] += 0.34 * modLevel;
		} else {
			mod.eventMods.Add (target.name, .34 * modLevel);
		}


	}
		










}

