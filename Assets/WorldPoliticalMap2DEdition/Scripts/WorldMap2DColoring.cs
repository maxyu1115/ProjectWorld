using UnityEngine;
using System.Collections;


namespace WPMF
{
	
	public partial class WorldMap2D : MonoBehaviour
	{
		int[] previousColoringLevels;

		public void initializeCultColoring()
		{
			previousColoringLevels = new int[countries.Length];

			Color fillColor = new Color (0, 0, 0);
			float r, g, b;
			float h, s, l;

			for (int i = 0; i < countries.Length; i++) {
				//r = 1 - i / 85.0f;
				//g = 0.7f + 0.3f * i / 85.0f;

				//r = i / 85.0f;
				//g = 0.7f + 0.3f * i / 85.0f;

				//r = i / 85.0f; //yellowish brown black
				//g = 0.7f * i/85.0f;

				r=1;
				g = 0.7f;

				b = 0.1f*(i%3);

				RGBtoHSL (r, g, b, out h, out s, out l);
				s *= 0.8f;
				HSLtoRGB (h, s, l, out r, out g, out b);

				fillColor.r = r;
				fillColor.g = g;
				fillColor.b = b;

				//fillColor.r = 1 - i / 85.0f; //red brown green
				//fillColor.g = 0.7f * i/85.0f;

				//fillColor = makeColor(i/85.0f);
				ToggleCountrySurface (i, true, fillColor);
			}

		}

		public void refreshCultColoring ()
		{
			Color fillColor = new Color (0, 0, 0);
			int tempColorLevel = 0;

			float r, g, b;
			float h, s, l;

			int tempEnergyLevel = (int)(Energy * 20);

			for (int i=0;i<countries.Length;i++){

				if (!countries [i].data.notEliminated && previousColoringLevels [i] != -1) {
					fillColor.r = 1;
					fillColor.g = 1;
					fillColor.b = 1;
					ToggleCountrySurface (i, true, fillColor);

					previousColoringLevels [i] = -1;

					continue;
				}

				tempColorLevel = (int)(countries [i].data.cultist * 20);

				if (tempColorLevel != previousColoringLevels[i]) {

					r = 1 - 0.05f * tempColorLevel;
					g = 0.7f - 0.035f * tempColorLevel;
					b = 0.1f*(i%3);

					RGBtoHSL (r, g, b, out h, out s, out l);
					s *= 0.8f - 0.015f * tempEnergyLevel;
					HSLtoRGB (h, s, l, out r, out g, out b);

					fillColor.r = r;
					fillColor.g = g;
					fillColor.b = b;

					ToggleCountrySurface (i, true, fillColor);

					previousColoringLevels [i] = tempColorLevel;

				}
			}
		}

		/*Color makeColor(float value) {
			// value must be between [0, 510]

			value = value * 2;

			float redValue;
			float greenValue;
			if (value < 1) {
				redValue = 1;

				greenValue = Mathf.Sqrt(value) * 16f/255f;

				greenValue = Mathf.Round(greenValue);
			} else {
				greenValue = 1;
				value = value - 1;
				redValue = 1 - (value * value / 1);
				redValue = Mathf.Round(redValue);
			}

			return new Color(redValue,greenValue,0);
		}*/



		//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
		//https://gist.github.com/mjackson/5311256
		private void RGBtoHSL(float r, float g, float b, out float Hue, out float Saturation, out float Luminance){
			float max = 0;
			float min = 0;
			int biggest = 0;  //0 for r, 1 for g, 2 for b
			if (r > g) {
				if (g > b) {
					max = r;
					biggest = 0;
					min = b;
				} else {
					min = g;
					if (r > b) {
						max = r;
						biggest = 0;
					} else {
						max = b;
						biggest = 2;
					}
				}
			} else { //g>r
				if (r > b) {
					max = g;
					biggest = 1;
					min = b;
				} else { //b>r
					min = r;
					if (g > b) {
						max = g;
						biggest = 1;
					} else {
						max = b;
						biggest = 2;
					}
				}
			}



			Luminance = (max + min) / 2;

			//float Hue;
			//float Saturation;

			if (max == min) {
				Hue = 0;
				Saturation = 0;
				return;
			}

			if (Luminance > 0.5) {
				Saturation = (max - min) / (max + min);
			} else {
				Saturation = (max - min) / (2.0f - max - min);
			}
			if (biggest == 0) {
				Hue = (g - b) / (max - min);
				if (g < b) {
					Hue += 6;
				}

			} else if (biggest == 1) {
				Hue = 2.0f + (b - r) / (max - min);
			} else {
				Hue = 4.0f + (r - g) / (max - min);
			}

			Hue /= 6f;

		}


		private void HSLtoRGB(float h, float s, float l, out float Red, out float Green, out float Blue){

			/*if (s == 0) {
				Red = 1;
				Green = 1;
				Blue = 1;
				return;
			}*/

			float temp1;
			float temp2;

			if (l > 0.5f) {
				temp1 = l * (1 + s);
			} else {
				temp1 = l + s - l * s;
			}

			temp2 = 2 * l - temp1;

			float tempR = h + 0.333f;
			if (tempR > 1)
				tempR -= 1;

			float tempG = h;

			float tempB = h - 0.333f;
			if (tempB < 0)
				tempB += 1;

			//float Red;
			//float Green;
			//float Blue;

			if (6 * tempR < 1) {
				Red = temp2 + (temp1 - temp2) * 6 * tempR;
			} else if (2 * tempR < 1) {
				Red = temp1;
			} else if (3 * tempR < 2) {
				Red = temp2 + (temp1 - temp2) * 6 * (0.666f - tempR);
			} else {
				Red = temp2;
			}

			if (6 * tempG < 1) {
				Green = temp2 + (temp1 - temp2) * 6 * tempG;
			} else if (2 * tempG < 1) {
				Green = temp1;
			} else if (3 * tempG < 2) {
				Green = temp2 + (temp1 - temp2) * 6 * (0.666f - tempG);
			} else {
				Green = temp2;
			}

			if (6 * tempB < 1) {
				Blue = temp2 + (temp1 - temp2) * 6 * tempB;
			} else if (2 * tempB < 1) {
				Blue = temp1;
			} else if (3 * tempB < 2) {
				Blue = temp2 + (temp1 - temp2) * 6 * (0.666f - tempB);
			} else {
				Blue = temp2;
			}



		}

	}

}

