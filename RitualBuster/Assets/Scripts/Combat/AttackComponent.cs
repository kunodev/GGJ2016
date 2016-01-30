using UnityEngine;
using System.Collections;

public class AttackComponent : MonoBehaviour {

	public float Damage;
	public GameObject Source;

	public void OnTriggerEnter2D(Collider2D otherCollider)  {
		MonoBehaviorSingleton<GameSingleton>.Instance.OnDamageDealt (Source, otherCollider.gameObject);
		otherCollider.GetComponent<HealthComponent> ().Damage (Damage, Source);
	}
}
