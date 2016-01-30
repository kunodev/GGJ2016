using UnityEngine;
using System;

[Serializable]
public class Attack
{
	public Vector3 offset;
	public Vector2 collSize;
	public KeyCode[] Codes;
	public Sprite sprite;
	public float TimeAlive;
	public float dmg;

	public bool Perform(GameObject source) {
		for (int i = 0; i < Codes.Length; i++) {
			if (Input.GetKeyDown (Codes [i])) {
				GameObject prefab = Resources.Load<GameObject> ("Attack");
				GameObject result = UnityEngine.Object.Instantiate (prefab);
				result.transform.position = source.transform.position + offset;
				AttackComponent comp = result.GetComponent<AttackComponent> ();
				comp.Source = source;
				comp.Damage = dmg;
				UnityEngine.Object.Destroy (result, TimeAlive);
				result.GetComponent<SpriteRenderer> ().sprite = sprite;
				result.GetComponent<BoxCollider2D> ().size = collSize;
				return true;
			}
		}
		return false;

	}
}

