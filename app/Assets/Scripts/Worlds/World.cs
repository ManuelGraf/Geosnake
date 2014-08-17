using UnityEngine;
using System.Collections;

public interface IWorld
{

	public void Init();

	public Vector3 AdjustPosition(Transform trans);
	public Quaternion AdjustRotation(Transform trans);
	public virtual void UpdateWorld();


}

