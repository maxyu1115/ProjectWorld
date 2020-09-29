using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class TechnologyBreakThrough_Event : HumanDisasters {
	
	double[] effectIndex= {+0.05,+0.05,+0.05,-0.05,+0.1,-17};
	public override double[] effect_Index
	{
		get{
			return effectIndex;
		}

	}



	public override float getDTime(RegionData d)
	{
		return 12;
	}

    public override string eventName()
    {
        return "TechnologyBreakThrough";
    }
}
