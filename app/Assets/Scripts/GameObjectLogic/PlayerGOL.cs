using UnityEngine;
using System.Collections;

public class PlayerGOL : GOL
{
	public PlayerGOL():base(GOL){
		_go = Utils.LoadPrefab("snakeHead");

	}

	public void Update(){
		// get direction of input
		// find a new direction and ask the world for actual coordinates

	}
		
}

