using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner
{
	public int EncounterNo = 0;

	private int _enemiesToSpawn;
	private int _enemiesSpawned;

	public const int MAX_ENEMIES = 5;
	public const float ENEMY_START_HP = 25f;
	public const float WAIT_TIME_SPAWNING = 2f;

	private static GameObject _enemyPrefab;

	public bool InProgress;

	public static GameObject EnemyPrefab {
		get {
			if (_enemyPrefab == null) {
				_enemyPrefab = Resources.Load<GameObject> ("Enemy");
			}
			return _enemyPrefab;
		}
	}

	public IEnumerator SpawnEnemy() {
		while (_enemiesSpawned < _enemiesToSpawn) {
			GameObject enemy = Object.Instantiate (EnemyPrefab);
			GameSingleton game = MonoBehaviorSingleton<GameSingleton>.Instance;
			game.AddEnemy (enemy);
			Camera cam = Camera.main;
			Vector2 extends = cam.Extends ();

			float rand = Random.value;
			bool left =  rand < 0.5f;
			Debug.Log ("left: " + left);				
			Vector3 offset = new Vector3 (left ? game.MinXBound + 1 : game.MaxXBound - 1, Random.value * 2f, 0);
			enemy.transform.position = offset;
			enemy.GetComponent<HealthComponent> ().CurrentHealth = ENEMY_START_HP;
			enemy.GetComponent<HealthComponent> ().MaxHealth =  ENEMY_START_HP;
			this._enemiesSpawned++;
			yield return new WaitForSeconds (WAIT_TIME_SPAWNING);
		}
		this.InProgress = false;
		yield return null;

	}

	public void StartSpawning(GameSingleton game) {
		EncounterNo++;
		this._enemiesSpawned = 0;
		this._enemiesToSpawn = MAX_ENEMIES;
		this.InProgress = true;

		game.StartCoroutine (SpawnEnemy ());
//		List<GameObject> result = new List<GameObject> ();
//
//		int noOfEnemies = Mathf.Max(MaxEnemies, EncounterNo);
//		int hpLevel = 1;
//		int lowerHpLevel = 4;
//		if (EncounterNo > MaxEnemies) {
//			hpLevel = EncounterNo / MaxEnemies;
//			lowerHpLevel = EncounterNo % MaxEnemies;					
//		}
//		for (int i = 0; i < noOfEnemies; i++) {
//			GameObject enemy = Object.Instantiate (EnemyPrefab);
//			result.Add (enemy);
//			float yOffset = extends.y - 1f * (i + 1);
//			enemy.transform.position = 
//				new Vector3 (cam.transform.position.x + extends.x - 1f, cam.transform.position.y + yOffset , 0);
//			enemy.GetComponent<HealthComponent> ().CurrentHealth = hpLevel * MIN_HP;
//			enemy.GetComponent<HealthComponent> ().MaxHealth = hpLevel * MIN_HP;
//		}
//		return result;
	}




}
