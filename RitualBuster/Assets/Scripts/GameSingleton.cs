using UnityEngine;
using System.Collections;

public class GameSingleton : MonoBehaviour {

	public float CombatOrthoSize;
	private float _normalSize;
	private GameObject[] _colliders;
	private Vector2 upperRight;

	public GameObject Splash;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		_normalSize = Camera.main.orthographicSize;
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
	}

	public void StartSplash() {
		Splash.SetActive (true);
	}

	public void OnFightFinished() {
		Camera.main.orthographicSize = this._normalSize;
		foreach (GameObject col in _colliders) {
			Destroy (col);
		}
		foreach (var player in GameObject.FindGameObjectsWithTag("Player")) {
			player.GetComponent<BarbieModePlayerController>().enabled = true;
		}
	}

}
