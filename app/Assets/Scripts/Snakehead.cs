using UnityEngine;
using System.Collections;

public class Snakehead : MonoBehaviour {
	float moveDistance = 0.01f;
	float distance = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//MOVEMENT


		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseHit;





		//DIRECTION
		Vector3 up = transform.TransformDirection (Vector3.up);

		RaycastHit hit;
		Vector3 offset = -1*gameObject.transform.position;

		Debug.DrawRay(transform.position, offset, Color.green,3,true);
		if (Physics.Raycast (transform.position, offset, out hit,100.0f)) {
			var distanceToGround = hit.distance;
			transform.position = hit.point;

			Quaternion q = Quaternion.FromToRotation(up, hit.normal);
			Debug.DrawRay(hit.point, hit.normal+hit.point, Color.red,3,true);
			q = q*gameObject.transform.rotation;
			gameObject.transform.rotation = q;

			transform.position = transform.position+transform.position*distance;
			this.transform.position += transform.TransformDirection (Vector3.forward*moveDistance);

			gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, q, 0.01f*Time.deltaTime);
			//print(hit.point.ToString("G4"));
		}
		float leftX = Input.GetAxis("Horizontal");
		float leftY = Input.GetAxis("Vertical");

		if (Physics.Raycast(mouseRay, out mouseHit, 100)){
			//print ("mouse hit sphere at " +mouseHit.point.ToString("G4"));
			Quaternion rotBackup = transform.rotation;
			transform.LookAt(mouseHit.point);
			Quaternion q =  transform.rotation;
			transform.rotation = rotBackup;
			Quaternion rot = Quaternion.Euler(transform.rotation.eulerAngles.x,q.eulerAngles.y,transform.rotation.eulerAngles.z);
			//print (transform.rotation.eulerAngles.x+" "+q.eulerAngles.y+" "+transform.rotation.eulerAngles.z);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.001f*Time.deltaTime);

			Debug.DrawRay(mouseHit.point, mouseHit.point+ mouseHit.normal, Color.white,1,true);
		}
		Debug.DrawRay(transform.position, transform.position+ transform.TransformDirection(Vector3.forward), Color.yellow,20,true);


	}
}
