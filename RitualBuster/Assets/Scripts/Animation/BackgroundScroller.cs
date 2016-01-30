using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BackgroundScroller : MonoBehaviour {

	public float XOffset;

	private int _currStep;

	private GameObject _curr;
	private GameObject _next;

	private List<GameObject> _unused;

	private const float RIGHTOFFSET = 19;

	private Camera _cam;
	private int _currIndexOffset = 1;

	// Use this for initialization
	void Start () {
		_unused = GameObject.FindGameObjectsWithTag ("bg").ToList();
		_curr = _unused.getRandomAndRemove ();
		_next = _unused.getRandomAndRemove ();
		_curr.transform.position = Vector3.forward;
		_next.transform.position = Vector3.forward + Vector3.right * RIGHTOFFSET;
		_cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (_cam.transform.position.x >= (RIGHTOFFSET) * _currIndexOffset) {
			_unused.Add (_curr);
			_curr = _next;
			_next = _unused.getRandomAndRemove ();
			_currIndexOffset++;
			_next.transform.position = Vector3.forward + Vector3.right * RIGHTOFFSET * _currIndexOffset;
			EnemyGroupSpawner.SpawnGroup (_next);
		}
	}
}
