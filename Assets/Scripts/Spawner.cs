using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject ObjectToSpawn;
	public float SpawnEveryNthSeconds;

	private float frameSpawnCounter;
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		frameSpawnCounter = SpawnEveryNthSeconds * 60;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (frameSpawnCounter <= 0) 
		{
			Spawn();
		}
		else
		{
			frameSpawnCounter--;
		}
	
	}

	public void Spawn()
	{
		spawnPosition = new Vector3(Random.Range(48,65),0,Random.Range(30,50));
		GameObject.Instantiate(ObjectToSpawn,spawnPosition,Quaternion.identity);
		frameSpawnCounter = SpawnEveryNthSeconds * 60;
	}
}
