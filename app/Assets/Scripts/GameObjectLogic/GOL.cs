using UnityEngine;
using System.Collections;


public class GOL{
	protected GameObject _go;
	protected Vector3 _position;
    protected Quaternion _rotation;
    protected string _groupName;
	protected float _offset;

	protected int _index;
	protected float _speed = 1f;
	protected float _rotateSpeed = 5;
	

	public GameObject go{get{return this._go;}set{this._go=value;}}
	public string groupName{get{return this._groupName;}set{this._groupName = value;}}
	public int index{get{return this._index;}set{this._index = value;}}
	public float offset{get{return this._offset;}set{this._offset = value;}}
		

	public void Init (){

		_go = GameManager.Instantiate(_go, new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;

	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
			
	}
}

