using UnityEngine;
using System.Collections;

public class PlayerLaserMovement : MonoBehaviour {
	public float projectileSpeed = .5f;
	public float lifeSpanInSeconds = 1;

	private float secondsAlive = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.forward * projectileSpeed;
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
