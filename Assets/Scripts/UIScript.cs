using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Slider energySlider;
    public Text scoreText;
    public int score;
    public int scoreToWin = 100;

    public GameObject gun1;
    public GameObject gun2;
	public bool dead = false;
	public GameObject player;
	
    
    private float countDownTimer = 150;
    private PlayerShoot ps1;
    private PlayerShoot ps2;


	// Use this for initialization
	void Start () {
        ps1 = gun1.GetComponent<PlayerShoot>();
        ps2 = gun2.GetComponent<PlayerShoot>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (score >= scoreToWin) 
		{
			if (countDownTimer <= 0) 
			{
				Application.LoadLevel(3);
			}
			else
			{
				countDownTimer--;
			}
		}
		if (dead) 
		{
			if (countDownTimer <= 0) 
			{
				Application.LoadLevel(2);
			}
			else
			{
				countDownTimer--;
			}

		}
        energySlider.value = Lerp(energySlider.value,ps1.energy + ps2.energy,.25f);
        scoreText.text = "" + score;
	
	}

    public float Lerp(float min, float max, float percentage)
    {
        return ((max-min)*percentage) + min;
    }

	
}
