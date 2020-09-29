using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class Tornado_NEvent:NaturalDisasters{
	public override double[] nature_Effect{
		get{ 
			return new double[]{ 5000, 20000, 0, 0, 0, 10000 };
		}
	}

	public override int[] mod_Effect {
		get {
			return new int[] { 0, 0, 3, 2, 3 };
		}
	}

	public override double buffSwitch(RegionData a)
	{
		return a.tornadoBuff;
	}

    public override float getDTime(RegionData d)
    {
        return 0.5f;
    }

    public override string eventName()
    {
        return "Tornado";
    }

}

