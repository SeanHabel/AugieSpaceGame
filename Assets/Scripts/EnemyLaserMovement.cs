using UnityEngine;
using System.Collections;

public class EnemyLaserMovement : MonoBehaviour {
	public float projectileSpeed = .5f;
	public float lifeSpanInSeconds = 2;


	private GameObject playerInstance;

	private Vector3 direction;
	private float secondsAlive = 0;
	
	// Use this for initialization
	void Start () {
		playerInstance = GameObject.Find("Player");
		direction = Vector3.Normalize(playerInstance.transform.position - gameObject.transform.position);
		gameObject.transform.LookAt(playerInstance.transform);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * projectileSpeed;
		if (secondsAlive < lifeSpanInSeconds*60) 
		{
			secondsAlive++;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
			
		}
		
	}
}
