using System;
using UnityEngine;


public class CombatController : CombatActor
{
	public float XSpeed;
	public float YSpeed;

	void Update() {
		Animator anim = this.GetComponent<Animator>();
		//Blocked by attacking
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (AnimatorConstants.KICK)
		   || anim.GetCurrentAnimatorStateInfo (0).IsName (AnimatorConstants.PUNCH)) {
			return;
		}
		float upDown = Input.GetAxis ("Vertical");
		float leftRight = Input.GetAxis ("Horizontal");

		Vector3 added = new Vector3 (leftRight * Time.deltaTime * XSpeed, upDown * Time.deltaTime * YSpeed, 0);
		this.transform.position += added;
		if (leftRight != 0f) {
			this.left = leftRight < 0;
		}

		if (Vector3.Distance (added, Vector3.zero) <= 0.01) {
			this.GetComponent<Animator> ().SetBool (AnimatorConstants.MOVING, false);
		} else {
			this.GetComponent<Animator> ().SetBool (AnimatorConstants.MOVING, true);
		}

		KeyCodeConfigurable[] attackTriggers = GetComponents<KeyCodeConfigurable> ();
		for (int i = 0; i < attackTriggers.Length; i++) {
			attackTriggers [i].CheckKeyDown ();
		}
	}
}

