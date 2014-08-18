using UnityEngine;
using System.Collections;

public class PlayerGOL : GOL
{
	public PlayerGOL(){
		Init();
	}
	public void Init(){
		_go = Utils.LoadPrefab("SnakeHead");
		base.Init ();
	} 
	public override void Update(){
		// get direction of input
		// find a new direction and ask the world for actual coordinates

	}
		
}

