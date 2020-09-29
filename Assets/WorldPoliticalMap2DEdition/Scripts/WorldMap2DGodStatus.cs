using System;
using UnityEngine;

namespace WPMF
{
	public partial class WorldMap2D : MonoBehaviour
	{		
		public const float evoGaugeTime=15f;

		public int godForm=0;
		public bool godChange=false;

		private int godInstantaneousForm=0;
		public float[] godStatusTime=new float[3];

		public void refreshGodForm(){

			if (godChange) {
				return;
			}

			if (Energy < 0.3f) {
				godInstantaneousForm = 0;
			} else if (Energy < 0.6f) {
				godInstantaneousForm = 1;
			} else {
				godInstantaneousForm = 2;
			}

			//Debug.Log (godInstantaneousForm);

			if (godInstantaneousForm != godForm) {
				godStatusTime [godInstantaneousForm] += Time.deltaTime; 
			} else {
				godStatusTime [0] = 0;
				godStatusTime [1] = 0;
				godStatusTime [2] = 0;
			}

			for (int i = 0; i < 3; i++) {
				if (godStatusTime [i] > evoGaugeTime) {

					godChange = true;
					godForm = i;

					godStatusTime [0] = 0;
					godStatusTime [1] = 0;
					godStatusTime [2] = 0;
					break;
				}
			}

		}
	}
}

