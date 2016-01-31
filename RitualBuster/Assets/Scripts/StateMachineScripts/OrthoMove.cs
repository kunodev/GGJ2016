using UnityEngine;
using System.Collections;

public class OrthoMove : BaseStateMachineScript {

	private Quaternion _rotation;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		animator.SetFloat (AnimatorConstants.MOVING,Random.value + 0.25f);
		animator.SetFloat (AnimatorConstants.ORTHO, Random.value);
		_rotation = Random.value < 0.5f ? Quaternion.Euler (0, 0, 90) : Quaternion.Euler (0, 0, -90);

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Enemy en = animator.GetComponent<Enemy> ();
		GameObject target = en.Target;
		Vector3 fromTo = target.transform.position - animator.transform.position;
		Vector3 added = fromTo.normalized * en.Speed * Time.deltaTime;
		added = _rotation * added;
		animator.transform.position += added;
	}

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
