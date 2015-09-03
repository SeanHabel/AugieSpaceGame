using UnityEngine;
using System.Collections;

public class PlayerLaserCollision : MonoBehaviour {
	public GameObject ObjectToDestroy;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//GameObject.Destroy(this.gameObject);
		}
		else
		{
			GameObject.Instantiate(Explosion, this.gameObject.transform.position,Quaternion.identity);
			GameObject.Destroy(ObjectToDestroy);

		}
	}
}
