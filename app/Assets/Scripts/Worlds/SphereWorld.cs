using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereWorld : BaseWorld
{
	private float _radius;
    private Vector3 lon = new Vector3(0,1,0);
	private Vector3 lat = new Vector3(1,0,0);

	public SphereWorld(){

		Init();
	}
	public void Init(){
		_radius = 5f;
		_levelName = "Globe"; 
		this._go = Utils.LoadPrefab("SphereWorld");
		_groups = new Dictionary<string,IGroup>();
		base.Init();

	}

	public Vector3 SphericalToCartesian(float radius, float polar, float elevation){
		float a = radius * Mathf.Cos(elevation);
		float x = a * Mathf.Cos(polar);
		float y = radius * Mathf.Sin(elevation);
		float z = a * Mathf.Sin(polar);
		return new Vector3(x,y,z);
	}

	public Vector3 CartesianToSpherical(Vector3 cartCoords){
		if (cartCoords.x == 0)
			cartCoords.x = Mathf.Epsilon;
		float outRadius = Mathf.Sqrt((cartCoords.x * cartCoords.x)
		                       + (cartCoords.y * cartCoords.y)
		                       + (cartCoords.z * cartCoords.z));
		float outPolar = Mathf.Atan(cartCoords.z / cartCoords.x);
		if (cartCoords.x < 0)
			outPolar += Mathf.PI;
		float outElevation = Mathf.Asin(cartCoords.y / outRadius);
		return new Vector3(outRadius,outPolar,outElevation);

	}


	public override Vector3 AdjustPosition(GOL gol){
     
		Vector3 position = gol.go.transform.position; 
		Vector3 pol = CartesianToSpherical(position);
		pol.x = _radius+gol.offset;

		return SphericalToCartesian(pol.x, pol.y,pol.z);

	}
	public override Vector3 AdjustPosition(Vector3 position){
		 
		Vector3 pol = CartesianToSpherical(position);
		pol.x = _radius;
		
		return SphericalToCartesian(pol.x, pol.y,pol.z);
		
	}
	public override Quaternion AdjustRotation(GOL gol){

		Transform trans = gol.go.transform; 
        Quaternion q = Quaternion.FromToRotation(trans.TransformDirection(Vector3.up), trans.position);
        q =  q*trans.rotation;
        return q;

	}
	public override void UpdateWorld(){
		//Vector3 test = new Vector3(1,1,1);
		//Debug.Log (Utils.CarToPol (Utils.PolToCar(Utils.CarToPol(test,_radius),_radius),_radius) == Utils.CarToPol(test,_radius));
		foreach (IGroup g in _groups.Values){
			g.UpdateGroup();
			
		}
		
	}
}

