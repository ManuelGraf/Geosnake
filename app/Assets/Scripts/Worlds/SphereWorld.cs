using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereWorld : BaseWorld
{
	private float _radius;

	public SphereWorld(){

		Init();
	}
	public void Init(){
		_radius = 1f;
		_levelName = "Globe"; 
		this._go = Utils.LoadPrefab("SphereWorld");
		_groups = new Dictionary<string,IGroup>();
		base.Init();

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

