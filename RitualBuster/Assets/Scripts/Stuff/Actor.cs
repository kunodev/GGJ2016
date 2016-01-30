using UnityEngine;
using System.Collections;

public class CombatActor : MonoBehaviour {

	private bool _left;

	public bool left {
		get {
			return _left;
		}
		set {
			this.GetComponent<SpriteRenderer> ().flipX = !value;
			this._left = value;
		}
	}

}
