using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereWorld : BaseWorld
{
	private float _radius;

	public SphereWorld(){
		Init();
	}

	public override void Init(){
		_radius = 1f;
		_levelName = "Globe"; 
		_go = Utils.LoadPrefab("sphereWorld");
	}

	



	public override Vector3 AdjustPosition(Transform trans){
		return Utils.CarToPol(trans.position);

	}
	public override Quaternion AdjustRotation(Transform trans){
		return trans.rotation;

	}
	public override void UpdateWorld(){
		foreach (IGroup g in _groups.Values){
			g.UpdateGroup();
			
		}
		
	}
}

