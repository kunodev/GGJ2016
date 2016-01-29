using System;
using UnityEngine;

public class MonoBehaviorSingleton<T> where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = UnityEngine.Object.FindObjectOfType<T> ();
			}
			return _instance;
		}
	}
}

