using UnityEngine;
using System.Collections;
using System.Linq;

public class Enemy : CombatActor {

	public GameObject Target;
	public float Speed;

	void Update() {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		this.Target = players
			.OrderBy (pl => Vector3.Distance (this.transform.position, pl.transform.position)).FirstOrDefault ();
		Vector3 fromTo = Target.transform.position - this.transform.position;
		if (fromTo.x < 0) {
			this.left = true;
		} else {
			this.left = false;
		}
	}

}
