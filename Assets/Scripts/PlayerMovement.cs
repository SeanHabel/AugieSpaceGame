using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;

	Vector2 mouse;
	Vector3 mousePositionConverted;
	Vector3 position;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		//mousePositionConverted = new Vector3(mouse.x,mouse.y,0);
		//Debug.Log(mousePositionConverted);

		Plane p;
		p = new Plane(Vector3.up, Vector3.zero);
		Ray ray;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float hitDist;
		if (p.Raycast(ray,out hitDist)) 
		{
			mouse = ray.GetPoint(hitDist);
			if (transform.position.x < mouse.x && transform.position.x < 65 && Mathf.Abs(transform.position.x - mouse.x) > 1) 
			{
				transform.position += Vector3.right * moveSpeed;
			}
			else if (transform.position.x > mouse.x && transform.position.x > 44 && Mathf.Abs(transform.position.x - mouse.x) > 1)
			{
				transform.position += Vector3.left * moveSpeed;
			}

		}

		//Debug.Log(hitDist);


		/*if (transform.position.x < mousePositionConverted.x) 
		{
			transform.position += Vector3.right * moveSpeed;
		}
		else if (transform.position.x > mousePositionConverted.x)
		{
			transform.position += Vector3.left * moveSpeed;
		}*/
	}
}
