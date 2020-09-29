using UnityEngine;
using WPMF;
using System.Linq;
using System.Collections.Generic;


public abstract class Disasters : MonoBehaviour {
	public Sprite defaultSprite;
    public WorldMap2D map;
    //Vector3 mousePos;
    public Country target;

	public string targetname;

	public bool loadStatus = false;

	public float destroyTime;
	public float destroyCountdown;

	int deltaPopulation;
	int deltaGdp;
	double deltaTechnology;
	double deltaResource;
	double deltaUnhappiness;
	double deltaReligion;
	double deltaCultist;

	public Animator anim;
	bool endAnim = false;

	//Peter
	//BlankPlace blankplace = new BlankPlace ();

	private void Start()
    {
		anim = GetComponent<Animator> ();

		additionalEarlyStart(target.data);


        //mousePos = Input.mousePosition;

        //target=getCursorCountry();

        //dont forget if target==null case...

        /*
		if (map.targetIndex == -1 || !map.countries[map.targetIndex].data.notEliminated) {
            Debug.Log("Destroyed Type1");
			Destroy (this.gameObject);
		} else {
			target = map.countries [map.targetIndex];
		}*/

		targetname = target.name;

		//Peter
		Vector3 place = BlankPlace.getBlankArea (target);
		this.gameObject.transform.position = place;

		LineRenderer line;
		//画线
		line = this.gameObject.AddComponent<LineRenderer>();
		//只有设置了材质 setColor才有作用
		line.material = new Material(Shader.Find("Particles/Additive"));
		line.SetVertexCount(2);//设置两点
		line.SetColors(Color.yellow, Color.red); //设置直线颜色
		line.SetWidth(0.2f, 0.2f);//设置直线宽度

		//设置指示线的起点和终点
		line.SetPosition(0, place);
		line.SetPosition(1, new Vector3(target.center.x * WorldMap2D.mapWidth, target.center.y * WorldMap2D.mapHeight, 86));


		if (!loadStatus) {
			destroyTime = getDTime (target.data) * WPMF.WorldMap2D.THREEMONTHTIME;
			destroyCountdown = destroyTime;
			//Destroy (this.gameObject, destroyTime);

			//Debug.Log (resistencePopulation (target.data, effectPopulation (target.data)));
			refreshEffect (destroyTime);

			target.data.modDestroyQueue.Add (genericName ());
			target.data.eventQueue.Add (eventName ());
			target.data.genericQueue.Add (genericName ());
			target.data.instantiateQueue.Remove (genericName ());
		}
    }

	public virtual void animationCount(){
		//Debug.Log ("fck yeah");
		int temp = anim.GetInteger ("Count");
		temp -= 1;
		anim.SetInteger ("Count", temp);
		if (temp <= 0) {
			anim.SetBool ("EndAnim", true);
		}

	}

    public virtual void additionalEarlyStart(RegionData data) {}
	public virtual void additionalUpdate(RegionData data){
		if (!endAnim && anim.GetBool ("EndAnim")) {
			endAnim = true;
			SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer> ();
			sr.sprite = defaultSprite;
		}


	}


    public void setTarget(int targetIndex)
    {
        map = WorldMap2D.instance;
        target = map.countries[targetIndex];
		anim = GetComponent<Animator> ();
    }

	public void loadEventData(SaveEventData ed){
		map = WorldMap2D.instance;
		anim = GetComponent<Animator> ();

		if (ed.eventName != eventName ()) {
			Debug.Log ("Event Load Error");
		}

		deltaCultist = ed.deltaCultist;
		deltaGdp = ed.deltaGdp;
		deltaPopulation = ed.deltaPopulation;
		deltaReligion = ed.deltaReligion;
		deltaResource = ed.deltaResource;
		deltaTechnology = ed.deltaTechnology;
		deltaUnhappiness = ed.deltaUnhappiness;
		targetname = ed.targetname;
		destroyTime = ed.destroyTime;
		destroyCountdown = ed.destroyCountdown;

		target = map.countries [map.GetCountryIndex (targetname)];
		loadStatus = true;

	}

	public SaveEventData saveEventData(){
		SaveEventData ed = new SaveEventData ();
		ed.eventName = eventName ();
		ed.deltaCultist = deltaCultist;
		ed.deltaGdp = deltaGdp;
		ed.deltaPopulation = deltaPopulation;
		ed.deltaReligion = deltaReligion;
		ed.deltaResource = deltaResource;
		ed.deltaTechnology = deltaTechnology;
		ed.deltaUnhappiness = deltaUnhappiness;
		ed.targetname = targetname;
		ed.destroyTime = destroyTime;
		ed.destroyCountdown = destroyCountdown;
		return ed;
	}


    private void Update()
    {
        
        if (!target.data.notEliminated)
        {
            Debug.Log(target.name+" Destroyed Type2");
            Destroy (this.gameObject);
		}


		additionalUpdate (target.data);


		getEffect(target.data);

		destroyCountdown -= Time.deltaTime;
		if (destroyCountdown <= 0) {
			Destroy (this.gameObject);
		}
    }

	private void OnDestroy()
	{
		target.data.eventQueue.Remove (eventName ());
		target.data.genericQueue.Remove (genericName ());
	}




	/*public void worldBoost(double modValue){
		string name = genericName ();
		var mod=(from p in map.disasterMods
			where p.DisasterName == name
			select p).First();
		Dictionary<string,double> eventMods = mod.eventMods;

		int index = map.GetCountryIndex (target);

		for (int i = 0; i < map.countries.Length; i++) {
			if (i == index) {
				continue;
			}
			if (eventMods.ContainsKey (map.countries[i].name)) {
				eventMods [map.countries[i].name] += modValue;
			} else {
				eventMods.Add (map.countries[i].name, modValue);
			}
		}
	}

	public void neighborBoost(double modValue){
		string name = genericName ();
		var mod=(from p in map.disasterMods
			where p.DisasterName == name
			select p).First();
		Dictionary<string,double> eventMods = mod.eventMods;

		foreach (int i in target.countryNeighborIndices) {
			if (eventMods.ContainsKey (map.countries[i].name)) {
				eventMods [map.countries[i].name] += modValue;
			} else {
				eventMods.Add (map.countries[i].name, modValue);
			}
		}
	}*/



	public void refreshEffect(float dTime){
		deltaPopulation = (int)(resistencePopulation (target.data, effectPopulation (target.data)) / dTime);
		deltaGdp = (int)(resistenceGDP (target.data, effectGDP (target.data)) / dTime);
		deltaTechnology = resistenceTechnology (target.data, effectTechnology (target.data)) / dTime;
		deltaResource = resistenceResource (target.data, effectResource (target.data)) / dTime;
		deltaUnhappiness = resistenceUnhappiness (target.data, effectUnhappiness (target.data)) / dTime;
		deltaReligion = resistenceReligion (target.data, effectReligion (target.data)) / dTime;
		deltaCultist = resistenceCultist (target.data, effectCultist (target.data)) / dTime;
	}

    public void getEffect(RegionData d)
    {
		d.population += (int)(deltaPopulation * Time.deltaTime);
		d.gdp += (int)(deltaGdp * Time.deltaTime);
		d.technology += deltaTechnology * Time.deltaTime;
		d.resource += deltaResource * Time.deltaTime;
		d.unhappiness += deltaUnhappiness * Time.deltaTime;
		d.religion += deltaReligion * Time.deltaTime;
		d.extraCultist += deltaCultist * Time.deltaTime;
    }

    #region override parameter equations
    public abstract int effectPopulation(RegionData d);
    public abstract int resistencePopulation(RegionData d, int effect);

    public abstract int effectGDP(RegionData d);
    public abstract int resistenceGDP(RegionData d, int effect);

    public abstract double effectTechnology(RegionData d);
    public abstract double resistenceTechnology(RegionData d, double effect);

    public abstract double effectResource(RegionData d);
    public abstract double resistenceResource(RegionData d, double effect);

    public abstract double effectUnhappiness(RegionData d);
    public abstract double resistenceUnhappiness(RegionData d, double effect);

    public abstract double effectReligion(RegionData d);
    public abstract double resistenceReligion(RegionData d, double effect);

    public abstract double effectCultist(RegionData d);
    public abstract double resistenceCultist(RegionData d, double effect);
    #endregion

	public abstract float getDTime (RegionData d);

	public float getDTIME (RegionData d){
		return getDTime (d);
	}

    public abstract string eventName();

	public virtual string genericName(){
		return eventName ();
	}
}
