using UnityEngine;
using System.Collections;

public class LoadLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		

	
	}
	
	// Update is called once per frame
	void Update () {


	
	}
    public void LoadLevel(int i)
    {
        Application.LoadLevel(i);

    }
    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }
    public void Quit()
    {
        Application.Quit();
    }
	
}
