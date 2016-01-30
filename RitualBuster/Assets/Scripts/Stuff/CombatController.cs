using System;
using UnityEngine;


public class CombatController : MonoBehaviour
{
	public float XSpeed;
	public float YSpeed;

	void Update() {
		float upDown = Input.GetAxis ("Vertical");
		float leftRight = Input.GetAxis ("Horizontal");
		Vector3 added = new Vector3 (leftRight * Time.deltaTime * XSpeed, upDown * Time.deltaTime * YSpeed, 0);
		this.transform.position += added;

		if (Vector3.Distance (added, Vector3.zero) <= 0.01) {
			this.GetComponent<SpriteRenderer> ().color = Color.white;
		} else {
			this.GetComponent<SpriteRenderer> ().color = Color.yellow;
		}


	}
}

