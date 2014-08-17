using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	GameObject snakeHead;
	SnakeCamera cameraScript;
	private GameObject player;
	IWorld _world;

	private static GameManager _instance;
	
	
	private GameManager() {}
	
	public static GameManager instance
	{
		get 
		{
			if (instance == null)
			{
				_instance = new World();
			}
			return instance;
		}
	}
	// Use this for initialization
	void Start () {
		//snakeHead = GameObject.Find("snakeHead");
		player= GameObject.Find("Player");
		cameraScript = Camera.main.GetComponent(typeof(SnakeCamera)) as SnakeCamera;
		cameraScript.target = player;
		cameraScript.targetxform = player.transform;

		_world = new SphereWorld();
		PlayerGroup pg = new PlayerGroup();
		_world.add(pg);
		_pg.add(new PlayerGOL())
		GoGroup gg = new GoGroup();

		_world.add(gg);



	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
