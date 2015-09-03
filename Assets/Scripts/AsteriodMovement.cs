using UnityEngine;
using System.Collections;

public class AsteriodMovement : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Vector3.back * moveSpeed;

		if (transform.position.z <= -25) 
		{
			GameObject.Destroy(gameObject);
		}
	}
}
