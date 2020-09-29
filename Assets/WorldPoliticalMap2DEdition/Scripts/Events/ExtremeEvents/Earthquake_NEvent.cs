using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Earthquake_NEvent : ExtremeDisasters
{
    public override double[] nature_Effect
    {
        get
        {
            return new double[] { 10000, 30000, 0, 0, 0, 10000 };
        }
    }

	public override double buffSwitch(RegionData a)
	{
		return a.earthquakeBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 0.1f;
    }

    public override string eventName()
    {
        return "Earthquake";
    }

}