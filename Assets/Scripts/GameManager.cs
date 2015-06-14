using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	//public int playerMaxHP;
	//public int playerCurrentHP;
	//private static gamestate instance;
	private float time_between_spawns;
	private float time_since_start = 0f;
	public Transform prefab1;
	public Transform prefab2;
	public Transform prefab3;
	public Transform prefab4;
	public Transform prefab5;
	private float width;
	private float height;
	private int num_of_cats = 0;
	public float playerHP = 10;
	public GameObject losebanner;
	//input
	public LayerMask touchInputMask;
	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;
	private float temp_time = 0;
	private bool cat_spawned = false;
	//private int spawn_num = 0;
	//private int spawn_rate = 2.0;
	//private int index = 0;
	private int random_index=0;

	void Awake(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	// Use this for initialization
	void Start () {
		height = 2.0f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		//GameObject sceneCamObj = GameObject.Find ("SceneCamera");
		//Debug.Log (sceneCamObj.camera.pixelRect);
	}
	
	// Update is called once per frame
	void Update () {
		//=============Cat Spawner===============//
		time_since_start += Time.deltaTime;
		int timer = (int)Mathf.Floor (time_since_start);
		float timer_dec = Mathf.Round (time_since_start * 10f) / 10f;
		int index = timer / 10;

		//int[] spawn_rates = {5,4,3,2,1};

		Transform[] cat_list = {prefab1,prefab2,prefab3,prefab4,prefab5};
		time_between_spawns = 1;

		if (temp_time != timer) 
		{
			temp_time = timer;
			cat_spawned = false;
		}

		//if (time_between_spawns*num_of_cats <(index+1)*10 && num_of_cats < max_num_of_cats)//Mathf.Repeat(time_since_start, time_between_spawns) == 0)
		//if(timer_dec%time_between_spawns == 0 && timer_dec/time_between_spawns == num_of_cats)//cat_spawned == false)
		//if((timer_dec%time_between_spawns == 0 && timer_dec < 11.2 || (timer_dec%time_between_spawns == 1.6 && 11.2 <= timer_dec && timer_dec< 20 )))
		if(timer%time_between_spawns == 0 && timer/time_between_spawns == num_of_cats)
		{
			if(timer <=5)
				random_index = Random.Range(0,1);
			if(timer <=10&&timer>5)
				random_index = Random.Range(0,2);
			if(timer <=20&& timer>10)
				random_index = Random.Range(0,3);
			if(timer <=30 && timer>20)
				random_index = Random.Range(0,4);
			if(timer >30)
				random_index = Random.Range(0,5);

				Vector3 position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
				while(Physics.CheckSphere(position, 6))
				{
					position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
				}
				Instantiate(cat_list[random_index], position, cat_list[random_index].rotation);
				num_of_cats += 1;

			cat_spawned = true;
		}
		
		/*
//#if UNITY_EDITOR
		//================Mouse Clicks================//
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) 
		{
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit, touchInputMask)) 
			{
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				
				if (Input.GetMouseButtonDown(0)) {
					recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonUp(0)) {
					recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}	
				if (Input.GetMouseButton(0)) {
					recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}			
			}

			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
//#endif
		//================Touches================//
		if (Input.touchCount > 0) 
		{
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches) 
			{
				Ray ray = GetComponent<Camera>().ScreenPointToRay (touch.position);

				if (Physics.Raycast (ray, out hit, touchInputMask)) 
				{
					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				
					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					}	
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
						recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
					}		
					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
					}

				}
			}
			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}*/
	}

	public void TakeDamage(int amount)
	{
		playerHP -= amount;
		if (playerHP <= 0) {
			Application.LoadLevel("LoseScene");
		}
	}

	public float getPlayerHP(){
		return playerHP;
	}
}
