using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner
{
	public int EncounterNo = 0;
	public const int MaxEnemies = 5;
	public const float MIN_HP = 25f;

	private static GameObject _enemyPrefab;

	public static GameObject EnemyPrefab {
		get {
			if (_enemyPrefab == null) {
				_enemyPrefab = Resources.Load<GameObject> ("Enemy");
			}
			return _enemyPrefab;
		}
	}


	public List<GameObject> Spawning() {
		EncounterNo++;
		Camera cam = Camera.main;
		Vector2 extends = cam.Extends ();
		List<GameObject> result = new List<GameObject> ();

		int noOfEnemies = Mathf.Max(MaxEnemies, EncounterNo);
		int hpLevel = 1;
		int lowerHpLevel = 4;
		if (EncounterNo > MaxEnemies) {
			hpLevel = EncounterNo / MaxEnemies;
			lowerHpLevel = EncounterNo % MaxEnemies;					
		}
		for (int i = 0; i < noOfEnemies; i++) {
			GameObject enemy = Object.Instantiate (EnemyPrefab);
			result.Add (enemy);
			float yOffset = extends.y - 1f * (i + 1);
			enemy.transform.position = 
				new Vector3 (cam.transform.position.x + extends.x - 1f, cam.transform.position.y + yOffset , 0);
			enemy.GetComponent<HealthComponent> ().CurrentHealth = hpLevel * MIN_HP;
		}
		return result;
	}


}
