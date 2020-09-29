using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class FutureEnergyBar : MonoBehaviour {
	private Image image;
	//private float duration;
	WorldMap2D map;
    private Text futureEnergy;

	void Start()
	{
        futureEnergy = GameObject.Find("FutureEnergyDisplay").GetComponent<Text>();
        futureEnergy.text = " ";

        image = this.gameObject.GetComponent<Image>();
		image.type = Image.Type.Filled;
		image.fillAmount = 0f;
		//duration = 0f;

		map = WorldMap2D.instance;
	}
	void Update()
	{
		/*duration += 0.001f;
        if (image.fillAmount < 1f)
            image.fillAmount = duration;
        else if (image.fillAmount == 1f)
            image.fillAmount = 0f;
        */
        if (map.possibleCost == 0)
        {
            image.fillAmount = (float)(map.Energy - map.possibleCost);
            futureEnergy.text = "";
        }
        else if (map.possibleCost == -1)
        {
            futureEnergy.text = "!!";
        }
        else
        {
            image.fillAmount = (float)(map.Energy - map.possibleCost);
			futureEnergy.text = (int)(map.possibleCost * 10000) / 100.0 + "%";
        }
		

    }
}
