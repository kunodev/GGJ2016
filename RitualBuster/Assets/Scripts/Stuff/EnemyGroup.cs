using UnityEngine;
using System.Collections;

public class EnemyGroup : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D otherCollider) {
		MonoBehaviorSingleton<GameSingleton>.Instance.Splash.SetActive(true);


	}
}
