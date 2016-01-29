using UnityEngine;
using System.Collections.Generic;

public static class Extensions
{
	public static T GetRandom<T>(this T[] arr) {
		int random = Random.Range (0, arr.Length);
		return arr [random];
	}

	public static T getRandom<T>(this List<T> list) {
		int random = Random.Range (0, list.Count);
		return list [random];
	}

	public static T getRandomAndRemove<T>(this List<T> list) {
		int random = Random.Range (0, list.Count); 
		var result = list [random];
		list.Remove (result);
		return result;
	}

	public static Vector2 Extends(this Camera cam) {
		if (cam.orthographic) {
			Vector2 result = new Vector2 (cam.orthographicSize * Screen.width / Screen.height, 
				                 cam.orthographicSize);
			return result;
		} else {
			Debug.LogError ("no orthographic cam! make new extends thingy");
			return new Vector2 ();
		}
	}


}
