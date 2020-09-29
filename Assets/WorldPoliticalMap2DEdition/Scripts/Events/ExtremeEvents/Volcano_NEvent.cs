using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Volcano_NEvent : ExtremeDisasters
{
    public override double[] nature_Effect
    {
        get
        {
            return new double[] { 20000, 1000, 0, 0, 0, 20000 };
        }
    }

	public override double buffSwitch(RegionData a)
	{
		return a.volcanoBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 0.1f;
    }

    public override string eventName()
    {
        return "Volcano";
    }

}