using UnityEngine;
using System.Collections;

public class SnakeCamera : MonoBehaviour {
	public GameObject target;
	public float height = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position+(target.transform.TransformDirection(Vector3.up)*height);
		transform.rotation = target.transform.rotation;
		Quaternion q = Quaternion.FromToRotation(transform.TransformDirection(Vector3.forward),target.transform.TransformDirection(Vector3.down));

		transform.rotation = q*transform.rotation;
		Debug.Log (Vector3.Angle(transform.TransformDirection(Vector3.forward),target.transform.TransformDirection(Vector3.down)));
		Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down),Color.magenta,10f);
		Debug.DrawRay(target.transform.position,target.transform.TransformDirection(Vector3.down),Color.yellow,1f);
		//transform.RotateAround(transform.position, target.transform.TransformDirection(Vector3.right), 45f);


	}
}
