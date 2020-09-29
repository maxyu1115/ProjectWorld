using System;

public class Constants
{
	public readonly double gdpS;
	public readonly double resourceS;

	public readonly double average_Technology;
	public readonly double religionSL;
	public readonly double religionSH;
	public readonly double[] resistenceLevel_Index;
	//科技值分五类
	public readonly double[] resistence_Index;


	public Constants ()
	{
		gdpS = 0.035;
		
		resourceS = 25;
		average_Technology = 50;
		religionSL = 3;
		religionSH = 6;
		resistenceLevel_Index= new double[]{ 1, 20, 40, 60, 80, 100 };
		resistence_Index = new double[]{ -0.05, -0.1, -0.15, -0.175, -0.2 };
		//resistence_Index = new double[]{ 0.95, 0.9, 0.85, 0.825, 0.8 };

	}
}


