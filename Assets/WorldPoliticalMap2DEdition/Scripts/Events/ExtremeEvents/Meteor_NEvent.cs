using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Meteor_NEvent : ExtremeDisasters
{
    public override double[] nature_Effect
    {
        get
        {
            return new double[] { 1000000, 0, 0, 0, 0, 10000000 };
        }
    }

	public override double buffSwitch(RegionData a)
	{
		return a.meteorBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 0.1f;
    }

    public override string eventName()
    {
        return "Meteor";
    }

}