using UnityEngine;
using System.Collections;

public class DisasterDefaultAnim : StateMachineBehaviour {


	Animator anim;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Debug.Log ("hi?");
		anim = animator;

		AnimationEvent evt = new AnimationEvent ();
		evt.time = 0;
		evt.functionName = "print";
		evt.intParameter = 1325;
		//evt.functionName = "animationCount";
		Debug.Log (animator.runtimeAnimatorController.animationClips [0].name);
		Debug.Log (animator.runtimeAnimatorController.animationClips [0].length);
		Debug.Log (animator.runtimeAnimatorController.animationClips [0].isLooping);

		animator.runtimeAnimatorController.animationClips [0].AddEvent (evt);

	}

	public void print(int i){
		Debug.Log (i);
	}

	public void animationCount(){
		Debug.Log ("fck yeah");
		int temp = anim.GetInteger ("Count");
		temp -= 1;
		anim.SetInteger ("Count", temp);
		if (temp <= 0) {
			anim.SetBool ("EndAnim", true);
		}

	}


	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

