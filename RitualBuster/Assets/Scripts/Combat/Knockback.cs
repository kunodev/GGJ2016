using UnityEngine;
using System.Collections.Generic;

public class Knockback : MonoBehaviour {

	public Dictionary<GameObject,Tuple<float,int>> KnockbackData;

	public float KnockbackforgetTime;
	public float KnockbackForce;


	void Awake() {
		this.KnockbackData = new Dictionary<GameObject, Tuple<float, int>> ();
		MonoBehaviorSingleton<GameSingleton>.Instance.DamageDealt += OnDamageDealt;
	}

	public void OnDamageDealt(GameObject source, GameObject target, float dmg) {
		if (!KnockbackData.ContainsKey (target)) {
			KnockbackData.Add (target, new Tuple<float, int> ());
		}
		float currTime = Time.time;
		//Too long since last hit
		if (currTime - KnockbackData [target].first > KnockbackforgetTime) {
			KnockbackData [target].second = 0;
		}
		KnockbackData [target].first = Time.time;
		KnockbackData [target].second++;
		CombatActor actor = source.GetComponent<CombatActor> ();
		Rigidbody2D rigidBodySource = source.GetComponent<Rigidbody2D> ();
		Rigidbody2D rigidBodyTarget = target.GetComponent<Rigidbody2D> ();
		Vector2 force = new Vector2 (Mathf.Pow(KnockbackForce, KnockbackData[target].second), 0);
		if (actor.left) {
			rigidBodySource.AddForce (force);
			rigidBodyTarget.AddForce (-force);
		} else {
			rigidBodySource.AddForce (-force);
			rigidBodyTarget.AddForce (force);
		}
	}
}
