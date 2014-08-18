using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGroup
{
	Dictionary<int,GOL> group{get;set;}
	string name{get;set;}

	int add(GOL item);
	GOL get(int index);
	void remove(int index);
	void UpdateGroup();
	void freeze();
	void unFreeze();
}

 