using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGOL : GOL
{
	private Vector3 _trailDimensions;
	private int _trailLength = 5;
	private float _minTrailTickDistance = 1f;
	private int _trailSegmentVertexCount = 4;
	private List<Vector3> _trail;
	private GameObject _trailGO;
	private Collider _trailCollider;
	private Mesh _trailMesh;

	private float nextTrailTick;

	public Vector3[] newVertices;
	public Vector2[] newUV;
	public int[] newTriangles;
	public TrailStyle _trailStyle = TrailStyle.DIAMOND;
	
	public PlayerGOL(){
		Init();
	}

	private void getVerticesForPosition(Vector3 pos){
		Vector3[] ret = new Vector3[_trailSegmentVertexCount]; 
		switch(TrailStyle){
		case( TrailStyle.DIAMOND):
			ret[0] = pos + (_go.transform.TransformDirection(Vector3.left)*_trailDimensions.x)/2;
			ret[1] = pos + (_go.transform.TransformDirection(Vector3.right)*_trailDimensions.x)/2;
			ret[2] = pos + (_go.transform.TransformDirection(Vector3.top)*_trailDimensions.y)/2;
			ret[3] = pos + (_go.transform.TransformDirection(Vector3.down)*_trailDimensions.y)/2;
			break;
		case(TrailStyle.BOX):
			break;
			ret[1] = pos + (_go.transform.TransformDirection(Vector3.left)*_trailDimensions.x)/2 + (_go.transform.TransformDirection(Vector3.top)*_trailDimensions.y)/2;
			ret[0] = pos + (_go.transform.TransformDirection(Vector3.left)*_trailDimensions.x)/2 + (_go.transform.TransformDirection(Vector3.down)*_trailDimensions.y)/2;
			ret[2] = pos + (_go.transform.TransformDirection(Vector3.right)*_trailDimensions.x)/2 + (_go.transform.TransformDirection(Vector3.top)*_trailDimensions.y)/2;
			ret[3] = pos + (_go.transform.TransformDirection(Vector3.right)*_trailDimensions.x)/2 + (_go.transform.TransformDirection(Vector3.down)*_trailDimensions.y)/2;
		}
		return ret;
	}



	public void Init(){

        _position = new Vector3(1,1,1);
        _rotation = new Quaternion(0,0,0,0);
		_offset=1f;
		_rotateSpeed = 1f;
		_speed=2.0f;
		_trail = new List<Vector3>() ;
		// z determinded by traveled distance and tick resolution;
		_trailDimensions = new Vector3(0.3f,1f,0);

		_trailGO = Utils.LoadPrefab("Trail") as GameObject;
		_trailCollider = _trailGO.GetComponent(typeof(Collider)) as Collider;
		_trailMesh = (_trailGO.GetComponent(typeof(MeshFilter)) as MeshFilter).mesh;


		_go = GameManager.Instantiate(Utils.LoadPrefab("Trail"), _position,_rotation) as GameObject;

		_go = GameManager.Instantiate(Utils.LoadPrefab("SnakeHead"), _position,_rotation) as GameObject;
        //base.Init();
	} 
	public override void Update(){
		// get direction of input
		// find a new direction and ask the world for actual coordinates
		if(_go != null){

			//STEERING
			float horizontal = Input.GetAxis("Horizontal") * _rotateSpeed;


			_go.transform.position = GameManager.instance.world.AdjustPosition(this);
			_go.transform.rotation = GameManager.instance.world.AdjustRotation(this);


			Vector3 newPos = GameManager.instance.world.AdjustPosition(_go.transform.position + _speed * _go.transform.TransformDirection(Vector3.forward));
			var v3 = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"), 1.0f);
			var qTo = Quaternion.LookRotation(v3);
			


			_go.transform.rotation = Quaternion.Slerp(_go.transform.rotation, _go.transform.rotation*qTo, _rotateSpeed * Time.deltaTime);
			_go.transform.position = Vector3.Lerp(_go.transform.position,newPos,Time.deltaTime * _speed);


			// TRAIL
			if(Time.time > nextTrailTick){
				UpdateTrail(_go.transform.position);
			}

			
			
		}
	}
	private void UpdateTrail(Vector3 position){
		newVertices = _trailMesh.vertices.Clone();
		newTriangles = _trailMesh.vertices.Clone();
		bool addedPart = false;
		if(_trail.Count > _trailMesh.vertexCount / _trailSegmentVertexCount){
			newVertices = new Vector3[_trailMesh.vertexCount+_trailSegmentVertexCount];
			newTriangles = new int[_trailMesh.triangles.Length+6];

			_trailMesh.vertices.CopyTo(newVertices,0);
			_trailMesh.triangles.CopyTo(newTriangles,0);
			addedPart = true;
		}
		if(!addedPart){


			for (int i = 0; i < _trail.Count*_trailSegmentVertexCount; i= i+_trailSegmentVertexCount ) {
				float distToLast = Vector3.Distance(_trail[i/_trailSegmentVertexCount],_trail[(i/_trailSegmentVertexCount)+1]);
				if(distToLast < _minTrailTickDistance){
					
					
					if(i < _trail.Count*_trailSegmentVertexCount-_trailSegmentVertexCount){
						// other vertices
						newVertices[i] = newVertices[j+_trailSegmentVertexCount];
						newVertices[i+1] = newVertices[i+1+_trailSegmentVertexCount];
						newVertices[i+2] = newVertices[i+2+_trailSegmentVertexCount];
						newVertices[i+3] = newVertices[i+3+_trailSegmentVertexCount];
					}else{
						// nearest to player vertices
						Vector3[] verticesForPos = getVerticesForPosition(_go.transform.position);
						newVertices[i] = verticesForPos[0];
						newVertices[i+1] = verticesForPos[1];
						newVertices[i+2] = verticesForPos[2];
						newVertices[i+3] = verticesForPos[3];
						
					}	
				}
			}
			_trailMesh.Clear();
			_trailMesh.vertices = newVertices;
			_trailMesh.uv = newUV;
			_trailMesh.triangles = newTriangles;
		}

	}
	
}

