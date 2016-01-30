using System;
using UnityEngine;


public class BarbieModePlayerController : MonoBehaviour
{
	public float Speed;
	public float YUpperBound;
	public float YLowerbound;

	void Start() {
		HealthComponent health = this.GetComponent<HealthComponent>();
		health.CurrentHealth = health.MaxHealth;
	}

	public void OnEnable() {
//		GetComponent<Animator>().SetBool(AnimatorConstants.MOVING, true);
		GetComponent<SpriteRenderer>().color = Color.yellow;
	}

	public void Update ()
	{
		this.transform.position += Vector3.right * Speed * Time.deltaTime;
		float upDown = Input.GetAxis ("Vertical");

		this.transform.position += upDown * Vector3.up * Speed * Time.deltaTime;
	}

	void OnDisable() {
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}

