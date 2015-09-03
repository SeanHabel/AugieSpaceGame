using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	public GameObject ObjectToDestroy;
	public GameObject Explosion;

	private GameObject UIReference;
	private UIScript UIScriptReference;
	// Use this for initialization
	void Start () {
		UIReference = GameObject.Find("UI");
		UIScriptReference = UIReference.GetComponent<UIScript>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//GameObject.Destroy(this.gameObject);
		}
		else
		{
			UIScriptReference.dead = true;
			GameObject.Instantiate(Explosion, this.gameObject.transform.position,Quaternion.identity);
			GameObject.Destroy(ObjectToDestroy);

			
		}
	}
}
