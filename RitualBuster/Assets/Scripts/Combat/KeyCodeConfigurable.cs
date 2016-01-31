using System;

using UnityEngine;

public class KeyCodeConfigurable : MonoBehaviour
{
	public KeyCode code;
	public string animator;
	public Attack Attack;


	public void CheckKeyDown() {
		if (Input.GetKeyDown (code)) {
			this.GetComponent<Animator> ().SetTrigger (animator);
			this.GetComponent<AttackQueue> ().Attack = Attack;
		}
	}
}

