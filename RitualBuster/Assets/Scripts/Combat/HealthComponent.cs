using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {

	public float MaxHealth;
	public float CurrentHealth;

	public float HealthPercentage {
		get {
			return CurrentHealth / MaxHealth;
		}
	}

	public void Damage (float dmg, GameObject source)
	{
		if (this.CurrentHealth - dmg <= 0) {
			this.CurrentHealth = 0;
			MonoBehaviorSingleton<GameSingleton>.Instance.OnCharDied (source, this.gameObject);
			this.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.25f, 0.25f);
		} else {
			this.CurrentHealth -= dmg;
//			this.GetComponent<SpriteRenderer> ().color = Color.blue;
			//TODO: Enter poof/bam/whack effect here
		}
	}
}
