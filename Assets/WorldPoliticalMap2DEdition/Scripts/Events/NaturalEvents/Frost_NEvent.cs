using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Frost_NEvent : NaturalDisasters
{
    public override double[] nature_Effect
    {
        get
        {
            return new double[] { 20000, 5000, 0, 0, 0, 1000 };
        }
    }

	public override int[] mod_Effect {
		get {
			return new int[] { 0, 1, 3, 0, 0 };
		}
	}
		
	public override double buffSwitch(RegionData a)
	{
		return a.frostBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 1.0f;
    }

    public override string eventName()
    {
        return "Frost";
    }


}