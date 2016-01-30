using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameSingleton : MonoBehaviour {

	public float CombatOrthoSize;
	private float _normalSize;
	private GameObject[] _colliders;
	private Vector2 upperRight;
	private List<GameObject>  players;

	public GameObject Splash;

	private EnemySpawner _spawner;
	private List<GameObject> _enemies;

	public event Action<GameObject, GameObject> DamageDealt;

	// Use this for initialization
	void Start () {
		_normalSize = Camera.main.orthographicSize;

		this.players = GameObject.FindGameObjectsWithTag ("Player").ToList();
		this._spawner = new EnemySpawner ();
	}

	public void OnSplashFinished ()
	{
		Camera cam = Camera.main;
		cam.orthographicSize = CombatOrthoSize;

		_colliders = new GameObject[4];
		_colliders [0] = Instantiate (Resources.Load<GameObject> ("Bounds"));
		_colliders [0].transform.position = new Vector3 (-cam.Extends ().x + cam.transform.position.x, 0, 0);
		_colliders [1] = Instantiate (Resources.Load<GameObject> ("Bounds"));
		_colliders [1].transform.position = new Vector3 (cam.Extends ().x + cam.transform.position.x, 0, 0);
		_colliders [2] = Instantiate (Resources.Load<GameObject> ("Bounds"));
		_colliders [2].transform.position = new Vector3 (cam.transform.position.x, cam.Extends ().y, 0);
		_colliders [2].transform.rotation *= Quaternion.Euler (0, 0, 90);
		_colliders [3] = Instantiate (Resources.Load<GameObject> ("Bounds"));
		_colliders [3].transform.position = new Vector3 (cam.transform.position.x, -cam.Extends ().y, 0);
		_colliders [3].transform.rotation *= Quaternion.Euler (0, 0, 90);

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CombatController> ().enabled = true;

		this._enemies = this._spawner.Spawning ();

	}

	public void StartSplash(GameObject collider) {
		Splash.SetActive (true);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<BarbieModePlayerController> ().enabled = false;
		Destroy (collider);

	}

	public void OnFightFinished() {
		Camera.main.orthographicSize = this._normalSize;
		foreach (GameObject col in _colliders) {
			Destroy (col);
		}
		foreach (var player in GameObject.FindGameObjectsWithTag("Player")) {
			player.GetComponent<BarbieModePlayerController>().enabled = true;
			player.GetComponent<CombatController> ().enabled = false;
		}
	}

	public void OnCharDied (GameObject source, GameObject target)
	{
		if (target.tag.Equals ("Player")) {
			this.players.Remove (target);
			if (this.players.Count == 0) {
				SceneManager.LoadScene ("start");
			}
		} else {
			this._enemies.Remove (target);
			if (this._enemies.Count == 0) {
				this.OnFightFinished ();
			}
		}
	}

	public void OnDamageDealt (GameObject source, GameObject target)
	{
		this.DamageDealt (source, target);
	}
}
