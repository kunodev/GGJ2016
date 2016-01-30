using UnityEngine;
using System.Collections;

public class DynamicHealthbar : MonoBehaviour {

	public float ActiveForTime;

	public GameObject AssociatedPlayer;

	private float _timeWaited;

	private Healthbar _hb;

	public void Awake(){
		this.gameObject.SetActive (false);
		this._hb = GetComponent<Healthbar> ();
		MonoBehaviorSingleton<GameSingleton>.Instance.DamageDealt += OnDamageDone;
	}

	public void OnDamageDone(GameObject source, GameObject target) {
		if (source == AssociatedPlayer) {
			this._timeWaited = 0;
			this.gameObject.SetActive (true);
			this._hb.TargetObj = target;
		}
	}

	void Update() {
		_timeWaited += Time.deltaTime;
		if (this._timeWaited >= ActiveForTime) {
			this.gameObject.SetActive (false);
		}
	}

}
