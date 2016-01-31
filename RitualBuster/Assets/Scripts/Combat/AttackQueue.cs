using UnityEngine;
using System.Collections;

public class AttackQueue : MonoBehaviour {

	public Attack Attack;

	public void FireAttack() {
		GameObject source = this.gameObject;
		GameObject prefab = Resources.Load<GameObject> ("Attack");
		GameObject result = UnityEngine.Object.Instantiate (prefab);
		int sign = source.GetComponent<CombatActor> ().left ? -1 : 1;
		result.transform.position = source.transform.position + new Vector3(Attack.offset.x * sign, Attack.offset.y,0);
		AttackComponent comp = result.GetComponent<AttackComponent> ();
		comp.Source = source;
		comp.Damage = Attack.dmg;
		UnityEngine.Object.Destroy (result, Attack.TimeAlive);
		result.GetComponent<BoxCollider2D> ().size = Attack.collSize;

	}
}
