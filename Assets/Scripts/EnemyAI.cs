using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public GameObject EnemyLaser;
	public float moveSpeed = .4f;
	public float moveAwayRadius;
	public float firingRange = 22;
	public GameObject playerInstance;
	public GameObject LookResetter;

	private bool canShoot;
	private int cooldown = 90;
	private Vector3 direction;
	private float[] distance;
	private float xBetween;
	private float yBetween;
	private float zBetween;
	private float distanceBetweenFloat;
	private Vector3 distanceBetween;
	private GameObject[] enemyObjectsInScene;
	private float[] gameObjectDistances;
	private Vector3 closestDistance = new Vector3(900,0,900);
	private GameObject ClosestEnemy;
	private bool shouldMoveAway;
	// Use this for initialization
	void Start () {
		playerInstance = GameObject.Find("Player");
		LookResetter = GameObject.Find ("Look");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cooldown > 0) 
		{
			cooldown--;
		}
		else
		{
			canShoot = true;
		}
		enemyObjectsInScene = GameObject.FindGameObjectsWithTag("Enemy");
		distance = new float[enemyObjectsInScene.Length];
		for (int i = 0; i < enemyObjectsInScene.Length; i++) 
		{
			if (enemyObjectsInScene[i] != null)
			{
				
			
				distance[i] = DistanceBetween(enemyObjectsInScene[i].transform.position,transform.position);
				//Debug.Log(distance[i]);
				//closestDistance = Vector3.Normalize(gameObject.transform.position - closestDistance);
				if (distance[i] == 0)
				{
				
				}
				else if (distance[i] < DistanceBetween(closestDistance,transform.position)) 
				{
					ClosestEnemy = enemyObjectsInScene[i];
					closestDistance = enemyObjectsInScene[i].transform.position;
				}
			}

		}
		if (ClosestEnemy != null) 
		{

				
			if (Mathf.Abs(ClosestEnemy.transform.position.z - transform.position.z) <= Mathf.Abs(ClosestEnemy.transform.position.x - transform.position.x)) 
			{
				if (transform.position.z > ClosestEnemy.transform.position.z) 
				{
					direction = Vector3.forward;
	
				}
				else
				{
					direction = Vector3.back;
				}
			}

			if (transform.position.x > ClosestEnemy.transform.position.x) 
			{
				direction = Vector3.right;
			}
			else
			{
				direction = Vector3.left;
			}

			//Debug.Log(shouldMoveAway);
			if (DistanceBetween(ClosestEnemy.transform.position,transform.position) <= moveAwayRadius) 
			{
				//Debug.Log("MovingAway");
				shouldMoveAway = true;
			}
		}
		if (playerInstance != null)
		{
			if (shouldMoveAway) 
			{
				AvoidCrash();
				shouldMoveAway = false;
				//Debug.Log("MovingAway");
			}
			else if (DistanceBetween(playerInstance.transform.position,transform.position) <= firingRange && transform.position.z < 15 && transform.position.z > 10) 
			{
				gameObject.transform.LookAt(playerInstance.transform.position);
				if (canShoot) 
				{
					
					Shoot();
					canShoot = false;
					cooldown = 90;
					//Debug.Log("Shooting");
				}
			}
			else
			{
				MoveTowards();
				//Debug.Log("MovingForward");
			}
		}

	}

	void AvoidCrash()
	{
		transform.position += direction * moveSpeed;
	}
	void Shoot()
	{
		GameObject.Instantiate(EnemyLaser,transform.position,Quaternion.identity);
		gameObject.transform.LookAt(playerInstance.transform.position);
	}
	void MoveTowards()
	{
		transform.position += Vector3.back * moveSpeed*.5f;
		gameObject.transform.LookAt(LookResetter.transform.position);
	}
	public float DistanceBetween(Vector3 from, Vector3 to)
	{
		xBetween = to.x * to.x - from.x * from.x;
		yBetween = to.y * to.y - from.y * from.y;
		zBetween = to.z * to.z - from.z * from.z;
		distanceBetween = new Vector3(xBetween,yBetween,zBetween);
		distanceBetweenFloat = distanceBetween.magnitude;
		return(distanceBetweenFloat);
	}
}
