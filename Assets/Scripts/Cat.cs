using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
	public GameObject deathParticles;
	public GameObject attackParticlesL;
	public GameObject attackParticlesR;
	public int health;
	private float time = 0f;
	private float timer;
	public int time_between_attacks;
	public int num_of_attacks = 1;
	private GameManager gamemanager;
	//public GameManager scriptA;
	//private Vector3 spawn;

	// Use this for initialization
	void Awake()
	{
		gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		int timer = (int)Mathf.Ceil (time);
		if (timer % time_between_attacks == 0 && timer/time_between_attacks == num_of_attacks)
		{

			Vector3 lefteyepos = new Vector3((int)transform.position.x-(float)1.5, (int)transform.position.y+6, (int)transform.position.z-2);	
			Vector3 righteyepos = new Vector3((int)transform.position.x+(float)1.5, (int)transform.position.y+6, (int)transform.position.z-2);
			GameObject lefteye = (GameObject)Instantiate(this.attackParticlesL,lefteyepos,this.attackParticlesL.transform.rotation);		
			GameObject righteye = (GameObject)Instantiate(this.attackParticlesR,righteyepos,this.attackParticlesR.transform.rotation);
			Destroy(lefteye,1);
			Destroy(righteye,1);
			num_of_attacks += 1;
			gamemanager.TakeDamage(1);
		}
	}

	void OnMouseDown(){
		if(health>0){
			health--;
		}
	}

	void OnMouseUp(){
		if (health == 0){
			GameObject bloodeffect = (GameObject)Instantiate(this.deathParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			Destroy(bloodeffect,1);
		}
	}
	/*
	void OnTouchDown(){
		if(health>0){
			health--;
		}
	}

	void OnTouchUp(){
		if (health == 0){
			Instantiate (this.deathParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	void OnTouchExit(){
		if (health == 0){
			Instantiate (this.deathParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
	*/
}
