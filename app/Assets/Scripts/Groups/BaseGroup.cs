using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseGroup : IGroup
{
	protected string _name;
	protected Dictionary<int,GOL> _group;	
	protected int _index = 0;
	protected bool _frozen = false;

	public Dictionary<int,GOL> group{get{return _group;}set{_group=value;}}
	public string name{get{return _name;}set{_name=value;}}

	public BaseGroup(string groupName){
		_name = groupName;
		Init();
	}

	public void Init(){
		_group = new Dictionary<int,GOL>();
	}

	public int add(GOL item){

		item.index = _index++;
		item.groupName = _name;
		_group.Add(item.index,item);
		return item.index;
		
	}

	public GOL get(int index){
		GOL gol = null;

		if(_group.ContainsKey(index)){
			gol = _group[index];
		}else{
			Debug.Log("BaseGroup::get - no GOL with index "+index+" found");
		}

		return gol;
	}
	public void freeze(){
		_frozen = true;
	}
	public void unFreeze(){
		_frozen = false;
	}

	public void remove(int index){
		_group.Remove(index);
	}
	public void UpdateGroup(){
		foreach(GOL gol in _group.Values){
			gol.Update();
		}
	}
}

