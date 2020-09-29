using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Drought_NEvent : NaturalDisasters
{
    public override double[] nature_Effect
    {
        get
        {
            return new double[] { 5000, 10000, 0, 0, 0, 5000 };
        }
    }

	public override int[] mod_Effect {
		get {
			return new int[] { 2, 2, 3, 0, 0 };
		}
	}

	public override double buffSwitch(RegionData a)
	{
		return a.droughtBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 0.5f;
    }

    public override string eventName()
    {
        return "Drought";
    }

}