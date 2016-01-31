using UnityEngine;
using System.Collections;

public class BaseStateMachineScript : StateMachineBehaviour {
	

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		Attack attack = animator.GetComponent<AttackQueue> ().Attack;
		Enemy enem = animator.GetComponent<Enemy> ();
		Vector3 fromTo = enem.Target.transform.position - animator.transform.position;
		if (fromTo.magnitude <= attack.collSize.magnitude) {
			animator.SetFloat (AnimatorConstants.PUNCH, Random.value);
		} else {
			animator.SetFloat (AnimatorConstants.PUNCH, 0f);
		}
	}
}
