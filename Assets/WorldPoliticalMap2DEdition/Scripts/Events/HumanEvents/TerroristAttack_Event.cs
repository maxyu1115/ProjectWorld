using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class TerroristAttack_Event : HumanDisasters {
	
	double[] effectIndex= {0,-0.05,0,-0.15,0,8};
	public override double[] effect_Index
	{
		get{
			return effectIndex;
		}

	}


	public override float getDTime(RegionData d)
	{
        return 0.1f;
	}

    public override string eventName()
    {
        return "TerroristAttack";
    }
}

