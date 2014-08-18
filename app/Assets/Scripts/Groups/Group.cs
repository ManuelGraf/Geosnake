using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Group
{
	List<Group> group{get;}

	int add(GOL item);
	void remove(int index);
	void UpdateGroup();
}

 