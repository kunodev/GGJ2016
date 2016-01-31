using UnityEngine;
using System.Collections;

public class BaseStateMachineScript : StateMachineBehaviour {
	

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		Attack attack = animator.GetComponent<Enemy> ().Attack;
		animator.SetFloat (AnimatorConstants.PUNCH, 0f);
		bool left;
		for (int i = 0; i < players.Length; i++) {
			Vector2 fromTo = players [i].transform.position - animator.transform.position;

			if (fromTo.magnitude <= attack.collSize.magnitude) {
				animator.SetFloat (AnimatorConstants.PUNCH, Random.value);
			}
		}
				
	}
}
