using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WPMF
{
	public class ModList
	{
		public ModList (string dname)
		{
			DisasterName = dname;
			
		}

		//a ModList entry for each disaster
		public string DisasterName { get; set;}

		public Dictionary<string, double> eventMods = new Dictionary<string,double> ();

	}
}

