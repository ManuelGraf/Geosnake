using UnityEngine;
using System.Collections;

public class PlayerGOL : GOL
{
	public PlayerGOL() : base(){
		_go = Utils.LoadPrefab("snakeHead");

	}

	public override void Update(){
		// get direction of input
		// find a new direction and ask the world for actual coordinates

	}
		
}

