using UnityEngine;

public class EnemyGroupSpawner 
{
	private static GameObject _groupPrefab;

	public static GameObject GroupPrefab {
		get {
			if(_groupPrefab == null) {
				_groupPrefab = Resources.Load<GameObject>("EnemyGroup");
			}
			return _groupPrefab;
		}
	}

	public static void SpawnGroup(GameObject background) {
		var game = MonoBehaviorSingleton<GameSingleton>.Instance;
		float x = background.transform.position.x + Random.value;
		float y = Random.Range (game.MinYBound, game.MaxYBound);
		GameObject result = Object.Instantiate (GroupPrefab);
		result.transform.position = new Vector3 (x, y, 0);
	}
}
