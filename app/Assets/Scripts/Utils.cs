using UnityEngine;
using System.Collections;

public static class Utils
{
	public static GameObject LoadPrefab(string path) {
		return  Resources.Load("Prefabs/" + path, typeof(GameObject)) as GameObject;
	}
		
}

