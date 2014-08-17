using UnityEngine;
using System.Collections;

public class PlayerGroup : BaseGroup
{

	void add(GOL item){
		_group.Add(item);
		
	}
	public void remove(int index){
		_group.RemoveAt(index);
	}
	public void UpdateGroup(){
		foreach(GOL gol in _group){
			gol.Update();
		}
	}
}

