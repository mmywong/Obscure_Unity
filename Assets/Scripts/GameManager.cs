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
	private int i = 0;
	private float temp_time = 0;
	private bool cat_spawned = false;

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

		int index = timer/10;
		if (index > 4) {
			index = 4;
		}
		float[] spawn_rates = {2.0f,1.6f,1.2f,0.8f,0.4f};
		int max_num_of_cats = timer;
		Transform[] cat_list = {prefab1,prefab2,prefab3,prefab4,prefab5};
		time_between_spawns = 2;

		//if(timer % time_between_spawns == 0 && num_of_cats <= max_num_of_cats
		if (timer % time_between_spawns == 0 && timer/time_between_spawns == num_of_cats) 
		{
			int random_index = Random.Range(1,index)-1;
			int random_index = Random.Range(0,index);
			Vector3 position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
			while(Physics.CheckSphere(position, 6))
			{
				position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
			}
			Instantiate(cat_list[random_index], position, cat_list[random_index].rotation);
			num_of_cats= num_of_cats +1;
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
		print (playerHP);
		if (playerHP <= 0) {
			Application.LoadLevel("LoseScene");
		}
	}

	public float getPlayerHP(){
		return playerHP;
	}
}
