using UnityEngine;
using System.Collections;

/// <summary>
/// Delegames most of the methods all cameras
/// </summary>
[AddComponentMenu("CameraLib/Composite Camera")]
[RequireComponent (typeof (Camera))]
public class CompositeCamera : AbstractCamera {

	public AbstractCamera[] cameras;
	public int currentCamera = 0;
	public int lastCamera = -1;
	private float interpolationTime = 0;
	private float maxInterpolationTime = 0;
	private float maxInterpolationTimeInv = 0;
	private float lastInterpol;
	
	// An ease in, ease out animation curve (tangents are all flat)
	public AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
	
	public override void SetTarget(Transform target){
		base.SetTarget(target);
		cameras[currentCamera].SetTarget(target);
	}
	
	public override void InitCamera(){
		// do nothing
	}
	
	public void SetCamera(int newCamera, float time){
		if (newCamera == currentCamera){
			// cannot change camera to self
			return;
		}
		
		if (time>0 && lastCamera==-1){
			maxInterpolationTimeInv = 1/time;
			interpolationTime = 0;
			maxInterpolationTime = time;
			lastCamera = currentCamera;
			// enabled smooth lookat during transition
			smoothLookAtEnabled = cameras[newCamera].smoothLookAtEnabled || cameras[lastCamera].smoothLookAtEnabled;
		} else {
			// if interpolation is already running, then do jumpcut
			lastCamera=-1;
			smoothLookAtEnabled = cameras[newCamera].smoothLookAtEnabled;
			smoothLookAtDamping = cameras[newCamera].smoothLookAtDamping;
			targetMinimumRenderingDistance = cameras[newCamera].targetMinimumRenderingDistance;
		}
		currentCamera = newCamera;
		cameras[currentCamera].SetTarget(target);
		cameras[currentCamera].InitCamera();
	}
	
	public int GetCurrentCamera(){
		return currentCamera;
	}
	
	public void SetCamera(int newCamera){
		SetCamera(newCamera,0f);
	}
	
	// Use this for initialization
	void Start () {
		// disables all cameras (since UpdateCameraPosition() is called manually and the location is copied afterwards)
		for (int i=0;i<cameras.Length;i++){
			if (cameras[i]!=null){
				cameras[i].enabled = false;
				cameras[i].camera.enabled = false;
			}
		}
		cameras[currentCamera].InitCamera();
		smoothLookAtEnabled = cameras[currentCamera].smoothLookAtEnabled;
		smoothLookAtDamping = cameras[currentCamera].smoothLookAtDamping;
		targetMinimumRenderingDistance = cameras[currentCamera].targetMinimumRenderingDistance;
	}
	
	// Update is called once per frame
	public override void UpdateCameraPosition (float lookHorizontal, float lookVertical) {
		cameras[currentCamera].UpdateCameraPosition(lookHorizontal, lookVertical);
		if (lastCamera != -1){
			interpolationTime += Time.deltaTime;
			cameras[lastCamera].UpdateCameraPosition(lookHorizontal, lookVertical);
			lastInterpol = curve.Evaluate(interpolationTime*maxInterpolationTimeInv);
			transform.position = Vector3.Lerp(cameras[lastCamera].transform.position,cameras[currentCamera].transform.position,lastInterpol);
			if (interpolationTime>maxInterpolationTime){
				lastCamera = -1;
				smoothLookAtDamping = cameras[currentCamera].smoothLookAtDamping;
				smoothLookAtEnabled = cameras[currentCamera].smoothLookAtEnabled;
				targetMinimumRenderingDistance = cameras[currentCamera].targetMinimumRenderingDistance;
			} 
		} else {
			transform.position = cameras[currentCamera].transform.position;
		}
	}
	
	/*
	public override void UpdateLookOrientation(){
		if (lastCamera != -1){
			cameras[lastCamera].UpdateLookOrientation();
			cameras[currentCamera].UpdateLookOrientation();
			
			Quaternion from = cameras[lastCamera].transform.rotation;
			Quaternion to = cameras[currentCamera].transform.rotation;
			transform.rotation = Quaternion.Slerp(from,to,lastInterpol); 
		} else{
			cameras[currentCamera].UpdateLookOrientation();
			transform.rotation = cameras[currentCamera].transform.rotation;
		}
	}*/
}
