using UnityEngine;
using System.Collections;

public class GOL
{
	private GameObject _go;
	private Transform _transform;
	private Type _group;
	private int _index;
	private float _speed = 1f;


	public GameObject go{get{return this._o;}set{this._go=value;}}
	public Type group{get{return this._group;}set{this._group = value;}}
	public int index{get{return this._index;}set{this._index = value;}}
		
		public GOL(Type groupClass){
			group = groupClass;
			Init ();
		}
		void Init ()
		{
	
		}
	
		// Update is called once per frame
		public virtual void Update ()
		{
			
		}
}

