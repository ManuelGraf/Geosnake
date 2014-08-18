using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseWorld : IWorld
{
	protected string _levelName = "Base World";
	protected Dictionary<string,IGroup> _groups ;
	public Dictionary<string,IGroup> groups{get{return _groups;}}
	public string levelName{get{return _levelName;}set{_levelName=value;}}

	protected GameObject _go;

	public void Init(){
		_groups = new Dictionary<string,IGroup>();
		GameManager.Instantiate(_go, new Vector3(0,0,0), new Quaternion(0,0,0,0));

	}

	public void addGroup(IGroup g){
		_groups.Add(g.name,g);
	}

	public IGroup getGroup(string name){
		IGroup g = null;
		if(_groups.ContainsKey(name)){
			g= _groups[name];
		}else{
			Debug.Log("BaseWorld::getGroup - no Group with name "+name+" found...");
		}
		return g;
	}

	public void removeGroup(string name){
		_groups.Remove(name);
	}

	public GOL getGOL(string groupName,int index){
		return getGroup(groupName).get(index);
	}

	public void setGOL(string groupName,GOL gol){
		IGroup g = getGroup(groupName);
		if(g!=null){
			g.add(gol);
		}
	}

	public void setGOL(string groupName,int index,GOL gol){
		IGroup g = getGroup(groupName);
		if(g!=null){
			g.group[index]=gol;
		}
	}

	public void removeGOL(string groupName,int index){
		IGroup g = getGroup(groupName);
		if(g!=null){
			g.remove(index);
		}
	}

	public virtual Vector3 AdjustPosition(Transform trans){
		return trans.position;
		
	}

	public virtual Quaternion AdjustRotation(Transform trans){
		return trans.rotation;
		
	}

	public virtual void UpdateWorld(){
		foreach (IGroup g in _groups.Values){
			g.UpdateGroup();
			
		}
		
	}

}

