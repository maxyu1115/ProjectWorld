using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WPMF;

public class EnergyFillBar : MonoBehaviour {
    private Image image;
    //private float duration;
	WorldMap2D map;
    private Text energy;

    void Start()
    {
        energy = GameObject.Find("EnergyDisplay").GetComponent<Text>();
        energy.text = " ";

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

		if (!map.tutorialMode) {
			image.fillAmount = (float)map.Energy;
			energy.text = map.Energy * 100 + "%";
		}

    }
}
