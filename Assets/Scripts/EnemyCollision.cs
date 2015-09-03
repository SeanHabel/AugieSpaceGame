using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public GameObject ObjectToDestroy;
	public GameObject Explosion;
	public int Health = 1;
	public int score = 0;

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
			scoreReference.score += score;
			GameObject.Instantiate(Explosion,this.gameObject.transform.position, Quaternion.identity);
			GameObject.Destroy(ObjectToDestroy);


		}

	
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyLaser") 
		{

		}
		else
		{
			Health--;
		}

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
