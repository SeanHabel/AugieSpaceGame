using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	public GameObject Ship;
	public AudioSource ambientThruster;
	public AudioSource ambientSounds;

	// Use this for initialization
	void Start () {
		ambientSounds.Play();
		ambientSounds.loop = true;

		ambientThruster.Play ();
		ambientThruster.loop = true;

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter(Collider other)
	{

	}
}
