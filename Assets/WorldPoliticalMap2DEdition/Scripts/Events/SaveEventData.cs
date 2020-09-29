using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WPMF;

[Serializable]
public class SaveEventData
{
	public string eventName;

	public string targetname;

	public float destroyTime;
	public float destroyCountdown;

	public int deltaPopulation;
	public int deltaGdp;
	public double deltaTechnology;
	public double deltaResource;
	public double deltaUnhappiness;
	public double deltaReligion;
	public double deltaCultist;
}

