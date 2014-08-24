using UnityEngine;
using System.Collections;

public static class Utils
{
	public static GameObject LoadPrefab(string path) {
		Debug.Log ("trying to load prefab "+"Prefabs/" + path);
		GameObject go;
		go = Resources.Load("Prefabs/" + path, typeof(GameObject)) as GameObject;
		if(go ==null){
			Debug.Log ("but didnt find prefab "+ path);
		}
		return  go;
	}

	public static Vector3 PolToCar(Vector2 pol,float radius){
		float x =Mathf.Sin(pol.y)*Mathf.Cos(pol.x)*radius;
		float z=Mathf.Sin (pol.y)*Mathf.Sin(pol.x)*radius;
		float y=Mathf.Cos(pol.y)*radius;

		return new Vector3(x,y,z);
		
	} 

	public static Vector2 CarToPol(Vector3 point,float radius){
		float lon = Mathf.Atan2(point.z,point.x);
		float lat = Mathf.Acos(point.x / radius);

		return new Vector2(lon,lat);


		/**Vector2 polar;
		polar.y = Mathf.Atan2(point.x,point.z);
		float xzLen = new Vector2(point.x,point.z).magnitude; 
		polar.x = Mathf.Atan2(-point.y,xzLen);
		polar *= Mathf.Rad2Deg;
		return polar;**/
	} 	
}

