using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	GameObject snakeHead;
	SnakeCamera _cameraScript;
	private GameObject _player;
	private BaseGroup _pg;
	private BaseGroup _mg; 
	IWorld _world;

	private static GameManager _instance;
	
	
	private GameManager() {}

	//singleton
	public static GameManager instance{get {if (instance == null){_instance = new GameManager();}return instance;}}

	// Use this for initialization
	void Start () {
		//snakeHead = GameObject.Find("snakeHead");

		_world = new SphereWorld();
		_pg = new BaseGroup("Players");
		_world.addGroup(_pg);
		_pg.add(new PlayerGOL());
		_mg= new BaseGroup("Mobs");

		_world.addGroup(_mg);



	
	}
	
	// Update is called once per frame
	void Update () {

		_world.UpdateWorld();
	}
}
