using UnityEngine;
using System.Collections;

public class SnakeCamera : MonoBehaviour {
	public GameObject target;
	public float height = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position + target.transform.TransformDirection(Vector3.up)* height;
		transform.LookAt(target.transform.position);

	}
}
