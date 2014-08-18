using UnityEngine;
using System.Collections;


public class GOL{
	protected GameObject _go;
	protected Transform _xform;
	protected string _groupName;

	protected int _index;
	protected float _speed = 1f;


	public GameObject go{get{return this._go;}set{this._go=value;}}
	public string groupName{get{return this._groupName;}set{this._groupName = value;}}
	public int index{get{return this._index;}set{this._index = value;}}
		
	public GOL(){
			Init ();
	}
	void Init (){
	
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
			
	}
}

