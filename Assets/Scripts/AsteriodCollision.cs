using UnityEngine;
using System.Collections;

public class AsteriodCollision : MonoBehaviour {
	
	public GameObject ObjectToDestroy;
	public GameObject Explosion;
	public int Health = 10;
	public int score = 2;
	
	private GameObject UIReference;
	
	private UIScript scoreReference;
	// Use this for initialization
	void Start ()
	{
		UIReference = GameObject.Find("UI");
		scoreReference = UIReference.GetComponent<UIScript>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Health <= 0)
		{

			GameObject.Instantiate(Explosion,this.gameObject.transform.position, Quaternion.identity);
			GameObject.Destroy(ObjectToDestroy);
			
			
		}
		
		
	}
	public void OnTriggerEnter(Collider other)
	{
	

		Health--;
		if (other.tag == "Player") 
		{
			if (Health <= 0) 
			{
				scoreReference.score += score;
			}
		}
		/*else if (other.tag == "EnemyLaser")
		{
			GameObject.Instantiate(Explosion,other.gameObject.transform.position, Quaternion.identity);
			GameObject.Destroy(other.gameObject);
		}*/
		
		//Debug.Log("Hit");
	}
	public void OnTriggerStay(Collider other)
	{
		/*if (other.tag == "Enemy") 
		{
			GameObject.Instantiate(Explosion,this.gameObject.transform.position, Quaternion.identity);
			GameObject.Destroy(ObjectToDestroy);
			
		}*/
	}
}
