using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public GameObject TargetObj;
	private Image _healthBar;

	// Use this for initialization
	void Start () {
		this._healthBar = GetComponentsInChildren<Image> () [1];
	}
	
	// Update is called once per frame
	void Update () {
		_healthBar.fillAmount = TargetObj.GetComponent<HealthComponent>().HealthPercentage;
	}
}
