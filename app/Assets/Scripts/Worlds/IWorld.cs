using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IWorld
{

	Dictionary<string,IGroup> groups{get;}
	string levelName{get;}
	void Init();
	Vector3 AdjustPosition(Transform trans);
	Quaternion AdjustRotation(Transform trans);
	void addGroup(IGroup g);
	IGroup getGroup(string name);
	void removeGroup(string name);
	GOL getGOL(string groupName,int index);
	void setGOL(string groupName,GOL gol);
	void setGOL(string groupName,int index,GOL gol);
	void removeGOL(string groupName,int index);
	void UpdateWorld();


}

