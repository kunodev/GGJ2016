using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageCounter : MonoBehaviour {

	private float _dmgDone;

	// Use this for initialization
	void Start () {
		MonoBehaviorSingleton<GameSingleton>.Instance.DamageDealt += Increment;
	}

	void Increment (GameObject arg1, GameObject arg2, float dmg)
	{
		this._dmgDone += dmg;
		this.GetComponent<Text> ().text = "Highscore: " + Mathf.Round (_dmgDone);
	}
}
