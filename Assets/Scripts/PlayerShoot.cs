using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public GameObject UIReference;
	public GameObject Laser;
	public float energyRefreshRateInSeconds = 1.5f;


	private UIScript EnergyReference;
	private float energyRefresh;
	public float energy = 14;


	// Use this for initialization
	void Start () 
	{
		energyRefresh = energyRefreshRateInSeconds*60;
		EnergyReference = UIReference.GetComponent<UIScript>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			if (energy > 0)
			{
				Instantiate(Laser,transform.position,transform.rotation);
				energy--;
			}

		}
		if (energy < 14)
		{
			if (energyRefresh <= 0) 
			{
				energy++;
				energyRefresh = energyRefreshRateInSeconds*60;
			}
			else
			{
				energyRefresh--;
			}
		}
		else
		{
			energyRefresh = energyRefreshRateInSeconds*60;
		}
		//Debug.Log(energy);
	
	}

}
