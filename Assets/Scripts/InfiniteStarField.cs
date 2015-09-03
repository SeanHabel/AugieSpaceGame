using UnityEngine;
using System.Collections;

public class InfiniteStarField : MonoBehaviour {


	public int starsMax = 100;
	public float starSizeLow = 1.0f;
	public float starSizeHigh = 4.0f;
	public float starDistance = 25;
	public float movementSpeed = 0.05f;
	public float particleLifetime = 100f;


	
	private float rand;
	private ParticleSystem.Particle[] points;



	// Use this for initialization
	void Start ()
	{
	
	}

	private void createStars()
	{
		points = new ParticleSystem.Particle[starsMax];

		for (int i = 0; i < starsMax; i++) 
		{
			rand = Random.Range(starSizeLow,starSizeHigh);
			points[i].position = Random.insideUnitSphere * starDistance + transform.position;
			points[i].color = new Color(1,1,1,1);
			points[i].size = rand;
			points[i].lifetime = particleLifetime;
		}

	}

	// Update is called once per frame
	void Update () {
		if (points == null) 
		{
			createStars();
		}
		//transform.position += Vector3.back * movementSpeed;
		for (int i = 0; i < starsMax; i++) 
		{
			points[i].position += Vector3.back * movementSpeed;
			if (points[i].position.z < -50) 
			{
				points[i].position += Vector3.forward * Random.Range(starDistance,starDistance*2);
			}
		}

		GetComponent<ParticleSystem>().SetParticles (points, points.Length);

		if (transform.position.z < -starDistance/2)
		{
			transform.position += Vector3.forward * starDistance;
		}

	
	}
}
