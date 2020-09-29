using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericDisasters : HumanDisasters {
	
	int genericLevel=0;
	public abstract int getLevel ();
	public abstract void refreshLevel (RegionData data);

	private double[] effectIndex;
	public override double[] effect_Index{
		get{
			return effectIndex;
		}
	}

	public abstract double[] getEffectIndex(int level);

	public abstract Sprite getIcon (int level);

	public virtual void boostCountries () {}


	public override void additionalEarlyStart (RegionData data)
	{
		base.additionalEarlyStart (data);

		refreshLevel (data);
		genericLevel = getLevel ();

		//getting the effect index out of the genre
		effectIndex = getEffectIndex (genericLevel);

		//updating the icon
		SpriteRenderer icon = this.gameObject.GetComponent<SpriteRenderer> ();
		icon.sprite = getIcon (genericLevel);

		boostCountries ();
	}

	public override void additionalUpdate (RegionData data)
	{
		base.additionalUpdate (data);

		refreshLevel (data);

		specialDestroy ();

		if (genericLevel != getLevel ()) {
			target.data.eventQueue.Remove (eventName (genericLevel));
			target.data.eventQueue.Add (eventName ());
			genericLevel = getLevel();

			anim.SetBool ("StateChange", true);

		}

		if (anim.GetBool ("EndAnim") == true) {
			if (genericLevel != anim.GetInteger ("Level")) {

				SpriteRenderer icon = this.gameObject.GetComponent<SpriteRenderer> ();
				icon.sprite = getIcon (getLevel ());

				if (genericLevel < getLevel ()) {
					float tempDTime = getDTIME (data);
					if (tempDTime > destroyTime) {
						destroyCountdown += tempDTime - destroyTime;
						destroyTime = tempDTime;
					}
					refreshEffect (destroyTime);
				} else {
					refreshEffect (destroyTime);
				}

				target.data.eventQueue.Remove (eventName (genericLevel));
				target.data.eventQueue.Add (eventName ());

				genericLevel = getLevel ();
			} else {
				
			}

		}

	}

	public void animationLevel(){
		anim.SetInteger ("Level", genericLevel);
		anim.SetBool ("StateChange", true);

		//reset iterations
		anim.SetBool ("EndAnim", false);
		anim.SetInteger("Count", 3);
		Debug.Log ("hey");
	}

	public override void animationCount(){
		base.animationCount ();
		anim.SetBool ("StateChange", false);
	}

	public virtual void specialDestroy() {}

	public abstract string eventName (int level);


}
