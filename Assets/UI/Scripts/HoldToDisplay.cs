using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using WPMF;

[RequireComponent(typeof(Image))]
public class HoldToDisplay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject abilityDetails;
	private AbilityDetail abilityDetailScript;

	bool pointerDown = false;
	float pointerDownTimer = 0f;
	float holdThreshold = 0.25f;


	//sets a default of "temp" where the abilityDetails wont pop up
	private string eventName = "temp";



	private void Start(){
		abilityDetailScript = abilityDetails.GetComponent<AbilityDetail> ();

	}

	private void Update()
	{
		if (pointerDown) {
			pointerDownTimer += Time.deltaTime;
		}
		if (pointerDownTimer >= holdThreshold) {
			abilityDetailScript.setName (eventName);
			abilityDetails.SetActive (true);
		}

	}

	public void setName(string name){
		eventName = name;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log ("press");
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		resetHold ();
		Debug.Log ("release");
	}
	public void resetHold()
	{
		pointerDown = false;
		pointerDownTimer = 0f;

		abilityDetails.SetActive (false);
	}

}