using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPMF;

public class BlankPlace {


	//private static Dictionary<int, Vector3> blankArea1 = (1) new Vector3 (-27.3521f, 24.99f, 86));
	private static Vector3[] blankArea1 = { new Vector3 (-100f+13.63f*2/5, 24.99f, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f, 86),  
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*2, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*2, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*2, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*3, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*3, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*3, 86),new Vector3 (-100f+13.63f*2/5+13.63f*3, 24.99f-8.33f*3, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*4, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*4, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*4, 86),new Vector3 (-100f+13.63f*2/5+13.63f*3, 24.99f-8.33f*4, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*5, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*5, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*5, 86),new Vector3 (-100f+13.63f*2/5+13.63f*3, 24.99f-8.33f*5, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*6, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*6, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*6, 86),new Vector3 (-100f+13.63f*2/5+13.63f*3, 24.99f-8.33f*6, 86),
		new Vector3 (-100f+13.63f*2/5, 24.99f-8.33f*7, 86),new Vector3 (-100f+13.63f*2/5+13.63f, 24.99f-8.33f*7, 86),new Vector3 (-100f+13.63f*2/5+13.63f*2, 24.99f-8.33f*7, 86),new Vector3 (-100f+13.63f*2/5+13.63f*3, 24.99f-8.33f*7, 86)};
	private static Vector3[] blankArea2 = { new Vector3 (-27.3521f, 24.99f, 86),new Vector3 (-27.3521f + 13.63f, 24.99f, 86),  
		new Vector3 (-27.3521f, 24.99f-8.33f, 86),new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f, 86), 
		new Vector3 (-27.3521f, 24.99f-8.33f*2, 86),new Vector3 (-27.3521f+13.63f, 24.99f-8.33f*2, 86),
		new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f*3, 86),new Vector3 (-27.3521f + 13.63f*5, 24.99f-8.33f*3, 86),
		new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f*4, 86),new Vector3 (-27.3521f + 13.63f*2, 24.99f-8.33f*4, 86),new Vector3 (-27.3521f + 13.63f*5, 24.99f-8.33f*4, 86),
		new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f*5, 86),new Vector3 (-27.3521f + 13.63f*2, 24.99f-8.33f*5, 86),new Vector3 (-27.3521f + 13.63f*5, 24.99f-8.33f*5, 86),
		new Vector3 (-27.3521f , 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f*2, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f*3, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f*4, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f*5, 24.99f-8.33f*6, 86),
		new Vector3 (-27.3521f , 24.99f-8.33f*7, 86),new Vector3 (-27.3521f + 13.63f, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f + 13.63f*2, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f + 13.63f*3, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f + 13.63f*4, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f + 13.63f*5, 24.99f-8.33f*6, 86)};
	private static Vector3[] blankArea3 = { new Vector3 (-27.3521f+ 13.63f*8, 24.99f-8.33f, 86),new Vector3 (-27.3521f+ 13.63f*9, 24.99f-8.33f, 86),
		new Vector3 (-27.3521f+ 13.63f*8, 24.99f-8.33f*2, 86),new Vector3 (-27.3521f+ 13.63f*9, 24.99f-8.33f*2, 86),
		new Vector3 (-27.3521f+ 13.63f*6, 24.99f-8.33f*4, 86),
		new Vector3 (-27.3521f+ 13.63f*6, 24.99f-8.33f*5, 86),
		new Vector3 (-27.3521f+ 13.63f*6, 24.99f-8.33f*6, 86),new Vector3 (-27.3521f+ 13.63f*7, 24.99f-8.33f*6, 86),
		new Vector3 (-27.3521f+ 13.63f*6, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f+ 13.63f*7, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f+ 13.63f*8, 24.99f-8.33f*7, 86),new Vector3 (-27.3521f+ 13.63f*9, 24.99f-8.33f*7, 86)};
	private static bool[] blankArea10 = { false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
		false,false,false,false,false,false,false,false,false,false,false };
	private static bool[] blankArea20 = { false,false,false,false,false,false,false,false,
		false,false,false,false,false,false,false,false,
		false,false,false};
	private static bool[] blankArea30 = { false,false,false,false,false,false,false,false,
		false,false,false,false};
	static int index = -1;


	//America
	private static Vector3[] Vector_Canada = {
		new Vector3 (-94.548f, 41.65f-8.33f/2, 86),
		new Vector3 (-94.548f + 13.63f/2, 41.65f-8.33f/2, 86),
		new Vector3 (-94.548f + 13.63f, 41.65f-8.33f/2, 86),
		new Vector3 (-94.548f + 13.63f/2*3, 41.65f-8.33f/2, 86),
		new Vector3 (-94.548f+ 13.63f*2, 41.65f -8.33f/2, 86),
		new Vector3 (-94.548f+ 13.63f/2*5, 41.65f -8.33f/2, 86),
		new Vector3 (-94.548f + 13.63f * 3, 41.65f -8.33f/2, 86),
		new Vector3 (-94.548f + 13.63f /2* 7, 41.65f -8.33f/2*3, 86),
		new Vector3 (-94.548f + 13.63f * 4, 41.65f -8.33f, 86)
	};
	private static bool[] Vector_Canada0 = {false,false,false,false,false,false,false,false,false};
	private static Vector3[] Vector_USA = {
		new Vector3 (-94.548f+13.63f/2*3, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f +13.63f/2*4, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f +13.63f/2*5, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f +13.63f/2*6, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f +13.63f/2*7, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f * 2, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f * 3, 86),
	};
	private static bool[] Vector_USA0 = {false,false,false,false,false,false,false};
	private static Vector3[] Vector_Mexico = { 
		new Vector3 (-94.548f+13.63f/2*4, 41.65f - 8.33f * 3, 86),
		new Vector3 (-94.548f+13.63f/2*4, 41.65f - 8.33f * 4, 86),
		new Vector3 (-94.548f+13.63f/2*6, 41.65f - 8.33f * 4, 86),
		new Vector3 (-94.548f+13.63f/2*3, 41.65f - 8.33f * 3, 86),
		new Vector3 (-94.548f+13.63f/2*3, 41.65f - 8.33f * 4, 86),
	};
	private static bool[] Vector_Mexico0 = {false,false,false,false,false};
	private static Vector3[] Vector_MesoAmerican = {
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f * 4, 86),
		new Vector3 (-94.548f+13.63f/2*9, 41.65f - 8.33f * 4, 86),
		new Vector3 (-94.548f+13.63f/2*6, 41.65f - 8.33f /2* 9, 86),
		new Vector3 (-94.548f+13.63f/2*7, 41.65f - 8.33f * 5, 86),
	};
	private static bool[] Vector_MesoAmerican0 = {false,false,false,false};
	private static Vector3[] Vector_Peru = {
		new Vector3 (-94.548f+13.63f/2*6, 41.65f - 8.33f /2*11, 86),
		new Vector3 (-94.548f+13.63f/2*6, 41.65f - 8.33f * 6, 86),
		new Vector3 (-94.548f+13.63f/2*7, 41.65f - 8.33f * 6, 86)
	};
	private static bool[] Vector_Peru0 = {false,false,false};
	private static Vector3[] Vector_Bolivia_Argentina = {
		new Vector3 (-94.548f+13.63f/2*7, 41.65f - 8.33f /2*13, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f /2*13, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f /2*14, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f /2*15, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f /2*16, 86),
		new Vector3 (-94.548f+13.63f/2*8, 41.65f - 8.33f /2*18, 86),
		new Vector3 (-94.548f+13.63f/2*10, 41.65f - 8.33f /2*14, 86),
		new Vector3 (-94.548f+13.63f/4*19, 41.65f - 8.33f /2*15, 86),
		new Vector3 (-94.548f+13.63f/2*9, 41.65f - 8.33f /2*16, 86),
	};
	private static bool[] Vector_Bolivia_Argentina0 = {false,false,false,false,false,false,false,false,false};
	private static Vector3[] Vector_Brazil = {
		new Vector3 (-94.548f+13.63f/2*9, 41.65f - 8.33f /2*10, 86),
		new Vector3 (-94.548f+13.63f/2*10, 41.65f - 8.33f /2*10, 86),
		new Vector3 (-94.548f+13.63f/2*11, 41.65f - 8.33f /2*10, 86),
		new Vector3 (-94.548f+13.63f/2*9, 41.65f - 8.33f /2*11, 86),
		new Vector3 (-94.548f+13.63f/2*10, 41.65f - 8.33f /2*11, 86),
		new Vector3 (-94.548f+13.63f/2*11, 41.65f - 8.33f /2*11, 86),
		new Vector3 (-94.548f+13.63f/2*11, 41.65f - 8.33f /2*13, 86),
	};
	private static bool[] Vector_Brazil0 = {false,false,false,false,false,false,false};

	//Africa
	private static Vector3[] Vector_Morocco = {
		new Vector3 (-94.548f+13.63f/4*27, 41.65f - 8.33f /4*13, 86),
		new Vector3 (-94.548f+13.63f/4*25, 41.65f - 8.33f /4*13, 86),
		new Vector3 (-94.548f+13.63f/4*25, 41.65f - 8.33f /4*15, 86),
	};
	private static bool[] Vector_Morocco0 = {false,false,false};
	private static Vector3[] Vector_Algeria = { 
		new Vector3 (-94.548f+13.63f*7.25f, 41.65f - 8.33f *2.75f, 86),
		new Vector3 (-94.548f+13.63f*6.75f, 41.65f - 8.33f *3.25f, 86),
		new Vector3 (-94.548f+13.63f*7.25f, 41.65f - 8.33f *3.5f, 86)};
	private static bool[] Vector_Algeria0 = {false,false,false};
	private static Vector3[] Vector_WestAfricaEmpire = { 
		new Vector3 (-94.548f+13.63f*6.75f, 41.65f - 8.33f *3.5f, 86),
		new Vector3 (-94.548f+13.63f*7.5f, 41.65f - 8.33f *3.5f, 86),
		new Vector3 (-94.548f+13.63f*6.75f, 41.65f - 8.33f *4.25f, 86),
		new Vector3 (-94.548f+13.63f*7.5f, 41.65f - 8.33f *4.25f, 86)
	};
	private static bool[] Vector_WestAfricaEmpire0 = {false,false,false,false};
	private static Vector3[] Vector_Libya = { 
		new Vector3 (-94.548f+13.63f*7.5f, 41.65f - 8.33f *3f, 86),
		new Vector3 (-94.548f+13.63f*8f, 41.65f - 8.33f *3.5f, 86)
	};
	private static bool[] Vector_Libya0 = {false,false};
	private static Vector3[] Vector_Egypt = { 
		new Vector3 (-94.548f+13.63f*8.25f, 41.65f - 8.33f *3.25f, 86),
	};
	private static bool[] Vector_Egypt0 = {false};
	private static Vector3[] Vector_Chad = { 
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *3.5f, 86),
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *4.25f, 86)
	};
	private static bool[] Vector_Chad0 = {false,false};
	private static Vector3[] Vector_Sudan = { 
		new Vector3 (-94.548f+13.63f*8.25f, 41.65f - 8.33f *3.75f, 86),
		new Vector3 (-94.548f+13.63f*8.25f, 41.65f - 8.33f *4.25f, 86),
		new Vector3 (-94.548f+13.63f*8.3f, 41.65f - 8.33f *4.5f, 86)
	};
	private static bool[] Vector_Sudan0 = {false,false,false};
	private static Vector3[] Vector_RepublicofEastAfrica = { 
		new Vector3 (-94.548f+13.63f*8.6f, 41.65f - 8.33f *4.25f, 86),
		new Vector3 (-94.548f+13.63f*9f, 41.65f - 8.33f *4.5f, 86),
		new Vector3 (-94.548f+13.63f*8.75f, 41.65f - 8.33f *5f, 86)
	};
	private static bool[] Vector_RepublicofEastAfrica0 = {false,false,false};
	private static Vector3[] Vector_TheCongoEmpire = { 
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *4.5f, 86),
		new Vector3 (-94.548f+13.63f*8.1f, 41.65f - 8.33f *5f, 86),
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *5.25f, 86),
		new Vector3 (-94.548f+13.63f*8.1f, 41.65f - 8.33f *5.5f, 86)
	};
	private static bool[] Vector_TheCongoEmpire0 = {false,false,false,false};
	private static Vector3[] Vector_Angola = { 
		new Vector3 (-94.548f+13.63f*7.25f, 41.65f - 8.33f *5.5f, 86),
	};
	private static bool[] Vector_Angola0 = {false};
	private static Vector3[] Vector_Tanzania = { 
		new Vector3 (-94.548f+13.63f*8.5f, 41.65f - 8.33f *5.25f, 86),
		new Vector3 (-94.548f+13.63f*8.5f, 41.65f - 8.33f *6f, 86),
		new Vector3 (-94.548f+13.63f*8.75f, 41.65f - 8.33f *5.5f, 86)
	};
	private static bool[] Vector_Tanzania0 = {false,false,false};
	private static Vector3[] Vector_Zimbabwe = { 
		new Vector3 (-94.548f+13.63f*8.3f, 41.65f - 8.33f *6.25f, 86),
		new Vector3 (-94.548f+13.63f*8.5f, 41.65f - 8.33f *6f, 86)
	};
	private static bool[] Vector_Zimbabwe0 = {false,false};
	private static Vector3[] Vector_SouthAfrica = { 
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *6.25f, 86),
		new Vector3 (-94.548f+13.63f*8f, 41.65f - 8.33f *7f, 86),
		new Vector3 (-94.548f+13.63f*7.5f, 41.65f - 8.33f *7f, 86),
		new Vector3 (-94.548f+13.63f*8.25f, 41.65f - 8.33f *6.75f, 86)
	};
	private static bool[] Vector_SouthAfrica0 = {false,false,false,false};

	//Europe
	private static Vector3[] Vector_Europe = { 
		new Vector3 (-94.548f+13.63f*7.1f, 41.65f - 8.33f *1f, 86),
		new Vector3 (-94.548f+13.63f*7.25f, 41.65f - 8.33f *0.25f, 86),
		new Vector3 (-94.548f+13.63f*6.75f, 41.65f - 8.33f *1.75f, 86),
		new Vector3 (-94.548f+13.63f*6.5f, 41.65f - 8.33f *2.5f, 86),
		new Vector3 (-94.548f+13.63f*7.25f, 41.65f - 8.33f *2.25f, 86),
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *2.75f, 86),
		new Vector3 (-94.548f+13.63f*7.75f, 41.65f - 8.33f *0.25f, 86),
		new Vector3 (-94.548f+13.63f*8.25f, 41.65f - 8.33f *0, 86),
		new Vector3 (-94.548f+13.63f*8.3f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*8.5f, 41.65f - 8.33f *1.25f, 86),
		new Vector3 (-94.548f+13.63f*8.75f, 41.65f - 8.33f *1.75f, 86)
	};
	private static bool[] Vector_Europe0 = {false,false,false,false,false,false,false,false,
		false,false,false};

	//Asia
	private static Vector3[] Vector_SaudiArabia = { 
		new Vector3 (-94.548f+13.63f*8.75f, 41.65f - 8.33f *3.25f, 86),
		new Vector3 (-94.548f+13.63f*9.2f, 41.65f - 8.33f *3.8f, 86)
	};
	private static bool[] Vector_SaudiArabia0 = { false, false };
	private static Vector3[] Vector_Iran = { 
		new Vector3 (-94.548f+13.63f*9.25f, 41.65f - 8.33f *2.75f, 86)
	};
	private static bool[] Vector_Iran0 = { false };
	private static Vector3[] Vector_Kazakhstan = { 
		new Vector3 (-94.548f+13.63f*9.5f, 41.65f - 8.33f *1.75f, 86),
		new Vector3 (-94.548f+13.63f*10.25f, 41.65f - 8.33f *1.75f, 86)
	};
	private static bool[] Vector_Kazakhstan0 = { false,false };
	private static Vector3[] Vector_India = { 
		new Vector3 (-94.548f+13.63f*10.25f, 41.65f - 8.33f *3f, 86),
		new Vector3 (-94.548f+13.63f*10.75f, 41.65f - 8.33f *4f, 86)
	};
	private static bool[] Vector_India0 = { false,false };
	private static Vector3[] Vector_MiddleEast = { 
		new Vector3 (-94.548f+13.63f*9.25f, 41.65f - 8.33f *1.1f, 86),
		new Vector3 (-94.548f+13.63f*10f, 41.65f - 8.33f *1f, 86),
		new Vector3 (-94.548f+13.63f*9.75f, 41.65f - 8.33f *3.5f, 86),
	};
	private static bool[] Vector_MiddleEast0 = { false,false,false };
	private static Vector3[] Vector_Russia = { 
		new Vector3 (-94.548f+13.63f*10f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*10.5f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*11f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*11.5f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*12f, 41.65f - 8.33f *0.75f, 86),
		new Vector3 (-94.548f+13.63f*12.5f, 41.65f - 8.33f *0.75f, 86)
	};
	private static bool[] Vector_Russia0 = { false,false,false,false,false,false };
	private static Vector3[] Vector_China = { 
		new Vector3 (-94.548f+13.63f*10.5f, 41.65f - 8.33f *2.5f, 86),
		new Vector3 (-94.548f+13.63f*11.5f, 41.65f - 8.33f *2.5f, 86),
		new Vector3 (-94.548f+13.63f*12.25f, 41.65f - 8.33f *2f, 86),
		new Vector3 (-94.548f+13.63f*11.75f, 41.65f - 8.33f *3.25f, 86)
	};
	private static bool[] Vector_China0 = { false,false,false };
	private static Vector3[] Vector_SouthAsia = { 
		new Vector3 (-94.548f+13.63f*10.75f, 41.65f - 8.33f *4.25f, 86),
		new Vector3 (-94.548f+13.63f*11.75f, 41.65f - 8.33f *4f, 86)
	};
	private static bool[] Vector_SouthAsia0 = { false,false };
	private static Vector3[] Vector_EastAsiaSea = { 
		new Vector3 (-94.548f+13.63f*13.25f, 41.65f - 8.33f *2.25f, 86),
		new Vector3 (-94.548f+13.63f*13.1f, 41.65f - 8.33f *3f, 86),
		new Vector3 (-94.548f+13.63f*12.75f, 41.65f - 8.33f *3.25f, 86)
	};
	private static bool[] Vector_EastAsiaSea0 = { false,false,false };
	private static Vector3[] Vector_EastSouthAsiaSea = { 
		new Vector3 (-94.548f+13.63f*10.75f, 41.65f - 8.33f *5f, 86),
		new Vector3 (-94.548f+13.63f*11.25f, 41.65f - 8.33f *5.75f, 86),
		new Vector3 (-94.548f+13.63f*12.5f, 41.65f - 8.33f *4.5f, 86)
	};
	private static bool[] Vector_EastSouthAsiaSea0 = { false,false,false };
	private static Vector3[] Vector_PapuaNewGuinea = { 
		new Vector3 (-94.548f+13.63f*13.25f, 41.65f - 8.33f *4.75f, 86),
		new Vector3 (-94.548f+13.63f*13.75f, 41.65f - 8.33f *5.5f, 86)
	};
	private static bool[] Vector_PapuaNewGuinea0 = { false,false };
	private static Vector3[] Vector_Philippines = { 
		new Vector3 (-94.548f+13.63f*12.25f, 41.65f - 8.33f *3.8f, 86),
		new Vector3 (-94.548f+13.63f*12.5f, 41.65f - 8.33f *4.5f, 86)
	};
	private static bool[] Vector_Philippines0 = { false,false };

	//Island
	private static Vector3[] Vector_Greenland = { 
		new Vector3 (-94.548f+13.63f*5f, 41.65f - 8.33f *1f, 86),
		new Vector3 (-94.548f+13.63f*5.75f, 41.65f - 8.33f *0.75f, 86)
	};
	private static bool[] Vector_Greenland0 = { false,false };
	private static Vector3[] Vector_Antarctica = { 
		new Vector3 (-94.548f+13.63f*6f, 41.65f - 8.33f *10.5f, 86),
		new Vector3 (-94.548f+13.63f*7f, 41.65f - 8.33f *10.5f, 86),
		new Vector3 (-94.548f+13.63f*8f, 41.65f - 8.33f *10.5f, 86),
		new Vector3 (-94.548f+13.63f*9f, 41.65f - 8.33f *10.5f, 86)
	};
	private static bool[] Vector_Antarctica0 = { false, false, false, false };
	private static Vector3[] Vector_Iceland = { 
		new Vector3 (-94.548f+13.63f*6.25f, 41.65f - 8.33f *1.25f, 86),
		new Vector3 (-94.548f+13.63f*6.75f, 41.65f - 8.33f *0.5f, 86)
	};
	private static bool[] Vector_Iceland0 = { false, false};
	private static Vector3[] Vector_Madagascar = { 
		new Vector3 (-94.548f+13.63f*9f, 41.65f - 8.33f *7.2f, 86),
		new Vector3 (-94.548f+13.63f*9.5f, 41.65f - 8.33f *6f, 86)
	};
	private static bool[] Vector_Madagascar0 = { false, false};
	private static Vector3[] Vector_Australia = { 
		new Vector3 (-94.548f+13.63f*12.5f, 41.65f - 8.33f *6f, 86),
		new Vector3 (-94.548f+13.63f*10.75f, 41.65f - 8.33f *7.25f, 86),
		new Vector3 (-94.548f+13.63f*12.5f, 41.65f - 8.33f *7.1f, 86),
		new Vector3 (-94.548f+13.63f*13.25f, 41.65f - 8.33f *7.25f, 86)
	};
	private static bool[] Vector_Australia0 = { false, false,false,false};
	private static Vector3[] Vector_NewZealand = { 
		new Vector3 (-94.548f+13.63f*14f, 41.65f - 8.33f *7f, 86),
		new Vector3 (-94.548f+13.63f*14f, 41.65f - 8.33f *8.5f, 86)
	};
	private static bool[] Vector_NewZealand0 = { false, false,false,false};
	// Use this for initialization
	/*public BlankPlace () {
		if (!blankArea1.ContainsKey (1)) {
			blankArea1.Add (1, new Vector3 (-27.3521f, 24.99f, 86));
		}
		if (!blankArea1.ContainsKey (2)) {
			blankArea1.Add (2, new Vector3 (-27.3521f + 13.63f, 24.99f, 86));
		}
	}*/

	public static Vector3 getBlankArea(Country target){
		Vector3[] blankArea;
		bool[] blankArea00;
		bool find = true;
		int index = 0;
		Vector3 result=blankArea2 [0];
		if(target.name.Equals("Canada")){
			blankArea = Vector_Canada;
			blankArea00 = Vector_Canada0;
		}
		else if(target.name.Equals("United States of America")){
			blankArea = Vector_USA;
			blankArea00 = Vector_USA0;
		}
		else if(target.name.Equals("Mexico")){
			blankArea = Vector_Mexico;
			blankArea00 = Vector_Mexico0;
		}
		else if(target.name.Equals("Meso-America")){
			blankArea = Vector_MesoAmerican;
			blankArea00 = Vector_MesoAmerican0;
		}
		else if(target.name.Equals("Peru")||target.name.Equals("Ecuador")){
			blankArea = Vector_Peru;
			blankArea00 = Vector_Peru0;
		}
		else if(target.name.Equals("Bolivia")||target.name.Equals("Argentina")){
			blankArea = Vector_Bolivia_Argentina;
			blankArea00 = Vector_Bolivia_Argentina0;
		}
		else if(target.name.Equals("Brazil")){
			blankArea = Vector_Brazil;
			blankArea00 = Vector_Brazil0;
		}
		else if(target.name.Equals("Morocco")){
			blankArea = Vector_Morocco;
			blankArea00 = Vector_Morocco0;
		}
		else if(target.name.Equals("Algeria")){
			blankArea = Vector_Algeria;
			blankArea00 = Vector_Algeria0;
		}
		else if(target.name.Equals("West Africa Empire")){
			blankArea = Vector_WestAfricaEmpire;
			blankArea00 = Vector_WestAfricaEmpire0;
		}
		else if(target.name.Equals("Lybia")){
			blankArea = Vector_Libya;
			blankArea00 = Vector_Libya0;
		}
		else if(target.name.Equals("Egypt")){
			blankArea = Vector_Egypt;
			blankArea00 = Vector_Egypt0;
		}
		else if(target.name.Equals("Chad")){
			blankArea = Vector_Chad;
			blankArea00 = Vector_Chad0;
		}
		else if(target.name.Equals("Sudan")){
			blankArea = Vector_Sudan;
			blankArea00 = Vector_Sudan0;
		}
		else if(target.name.Equals("Republic of East Africa")){
			blankArea = Vector_RepublicofEastAfrica;
			blankArea00 = Vector_RepublicofEastAfrica0;
		}
		else if(target.name.Equals("The Congo Empire")){
			blankArea = Vector_TheCongoEmpire;
			blankArea00 = Vector_TheCongoEmpire0;
		}
		else if(target.name.Equals("Angola")){
			blankArea = Vector_Angola;
			blankArea00 = Vector_Angola0;
		}
		else if(target.name.Equals("United Republic of Tanzania")){
			blankArea = Vector_Tanzania;
			blankArea00 = Vector_Tanzania0;
		}
		else if(target.name.Equals("Zimbabwe")){
			blankArea = Vector_Zimbabwe;
			blankArea00 = Vector_Zimbabwe0;
		}
		else if(target.name.Equals("South Africa")){
			blankArea = Vector_SouthAfrica;
			blankArea00 = Vector_SouthAfrica0;
		}
		else if(target.name.Equals("Kazakhstan")){
			blankArea = Vector_Kazakhstan;
			blankArea00 = Vector_Kazakhstan0;
		}
		else if(target.name.Equals("Saudi Arabia")){
			blankArea = Vector_SaudiArabia;
			blankArea00 = Vector_SaudiArabia0;
		}
		else if(target.name.Equals("Iran")){
			blankArea = Vector_Iran;
			blankArea00 = Vector_Iran0;
		}
		else if(target.name.Equals("India")){
			blankArea = Vector_India;
			blankArea00 = Vector_India0;
		}
		else if(target.name.Equals("Russia")){
			blankArea = Vector_Russia;
			blankArea00 = Vector_Russia0;
		}
		else if(target.name.Equals("China")){
			blankArea = Vector_China;
			blankArea00 = Vector_China0;
		}
		else if(target.name.Equals("Myanmar")||target.name.Equals("South East Asia United")){
			blankArea = Vector_SouthAsia;
			blankArea00 = Vector_SouthAsia0;
		}
		else if(target.name.Equals("North Korea")||target.name.Equals("South Korea")||target.name.Equals("Japan")){
			blankArea = Vector_EastAsiaSea;
			blankArea00 = Vector_EastAsiaSea0;
		}
		else if(target.name.Equals("Indonesia")||target.name.Equals("Malaysia")){
			blankArea = Vector_EastSouthAsiaSea;
			blankArea00 = Vector_EastSouthAsiaSea0;
		}
		else if(target.name.Equals("Papua New Guinea")){
			blankArea = Vector_PapuaNewGuinea;
			blankArea00 = Vector_PapuaNewGuinea0;
		}
		else if(target.name.Equals("Philippines")){
			blankArea = Vector_Philippines;
			blankArea00 = Vector_Philippines0;
		}
		else if(target.name.Equals("Greenland")){
			blankArea = Vector_Greenland;
			blankArea00 = Vector_Greenland0;
		}
		else if(target.name.Equals("Antarctica")){
			blankArea = Vector_Antarctica;
			blankArea00 = Vector_Antarctica0;
		}
		else if(target.name.Equals("Iceland")){
			blankArea = Vector_Iceland;
			blankArea00 = Vector_Iceland0;
		}
		else if(target.name.Equals("Australia")){
			blankArea = Vector_Australia;
			blankArea00 = Vector_Australia0;
		}
		else if(target.name.Equals("New Zealand")){
			blankArea = Vector_NewZealand;
			blankArea00 = Vector_NewZealand0;
		}
		else if(target.name.Equals("Madagascar")){
			blankArea = Vector_Madagascar;
			blankArea00 = Vector_Madagascar0;
		}
		else if(target.center.x * WorldMap2D.mapWidth>-94.548f+13.63f*9f&&
			target.center.x * WorldMap2D.mapWidth<-94.548f+13.63f*10.5f){
			blankArea = Vector_MiddleEast;
			blankArea00 = Vector_MiddleEast0;
		}
		else if(target.center.x * WorldMap2D.mapWidth>-94.548f+13.63f*6f&&
			target.center.x * WorldMap2D.mapWidth<-94.548f+13.63f*9f){
			blankArea = Vector_Europe;
			blankArea00 = Vector_Europe0;
		}
		else if (target.center.x * WorldMap2D.mapWidth<-27.3521f) {
			blankArea = blankArea1;
			blankArea00 = blankArea10;
		}
		else if(target.center.x*WorldMap2D.mapWidth<-27.3521f + 13.63f*5){
			blankArea = blankArea2;
			blankArea00 = blankArea20;
		}
		else {
			blankArea = blankArea3;
			blankArea00 = blankArea30;
		}

		while (find){
			if (index == blankArea00.Length) {
				find = false;
				result = blankArea [0];
			}
			else if (!blankArea00 [index]) {
				result = blankArea [index];
				blankArea00 [index] = true;
				find = false;
			}
			else {
				index=index+1;
			} 
		}
		return result;

	}
	public static Vector3 getBlankArea1(){
		index++;
		return blankArea2 [index];
	}
	// Update is called once per frame
	/*public void generateBlankPoints(){
		float y_axis;
		while()
		{*/		

}
	