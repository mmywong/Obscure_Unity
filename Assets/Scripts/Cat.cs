using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
	public GameObject deathParticles;
	public int health;
	private float time;
	
	public GameManager scriptA;
	//private Vector3 spawn;

	// Use this for initialization
	void Start () {

		//spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		int timer = (int)Mathf.Ceil (time);
		/*
		if (timer == 1) {
			scriptA.decHP();

		}*/
	
	}

	void OnMouseDown(){
		if(health>0){
			health--;
		}
	}

	void OnMouseUp(){
		if (health == 0){
			Instantiate (this.deathParticles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

}
