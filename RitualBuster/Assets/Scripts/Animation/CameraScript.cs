using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private Transform toFollow;
	private Vector3 _selfOffset;

	// Use this for initialization
	void Start () {
		toFollow = GameObject.FindGameObjectWithTag ("Player").transform;
		_selfOffset = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 xoffset = toFollow.transform.position;
		xoffset.Scale(Vector3.right);
		this.transform.position = xoffset + this._selfOffset;
	}
}
