using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	SnakeCamera _cameraScript;
	private GameObject _player;
	private BaseGroup _pg;
	private BaseGroup _mg; 
	IWorld _world;
	public bool _isServer = true;
    public IWorld world { get { return _world; } set { _world = value; } }



	private static GameManager _instance;
	
	
	private GameManager() {}

	//singleton
	public static GameManager instance{get {return _instance;}}

	// Use this for initialization
	void Start () {
		//snakeHead = GameObject.Find("snakeHead");

		_world = new SphereWorld();
		_pg = new BaseGroup("Players");
		_world.addGroup(_pg);
		PlayerGOL player = new PlayerGOL();
		_pg.add(player);
		_mg= new BaseGroup("Mobs");
		_world.addGroup(_mg);

		_cameraScript = Camera.main.GetComponent(typeof(SnakeCamera))as SnakeCamera;
		_cameraScript.target = player.go;
	}
	void Awake(){

		_instance = this;
	}
	// Update is called once per frame
	void Update () {

		_world.UpdateWorld();
	}
}
