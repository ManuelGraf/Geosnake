using UnityEngine;
using System.Collections;


public class SphereWorld : World
{
	public SphereWorld(): base(World){
		Init();
	}
	public void Init(){
		_worldGO = Utils.LoadPrefab("sphereWorld");
	}

	
	public string _levelName;
	private ArrayList<Group> _groups ;
	private GameObject _go;

	public Vector3 AdjustPosition(Transform trans){
		// transform of gol to spherical coordinates

	}
	public Quaternion AdjustRotation(Transform trans){
		// set up orientation of gol to "boards" normal

	}
	public override void UpdateWorld(){
		foreach (Group g in _groups){
			g.UpdateGroup();
			
		}
		
	};
}

