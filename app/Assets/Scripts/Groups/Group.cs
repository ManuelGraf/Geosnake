using UnityEngine;
using System.Collections;

public interface Group
{
	ArrayList<GOL> group{get;}

	void add(GOL item);
	void remove(int index);
	void UpdateGroup();
}

