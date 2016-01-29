using UnityEngine;
using System.Collections;

public class EncounterSprite : MonoBehaviour {

	public float time;
	void OnEnable () {
		Invoke ("Disable", time);	
	}

	void Disable () {
		this.gameObject.SetActive (false);
		MonoBehaviorSingleton<GameSingleton>.Instance.OnSplashFinished();
	}





}
