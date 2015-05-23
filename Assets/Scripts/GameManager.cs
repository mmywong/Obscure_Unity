using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	//public int playerMaxHP;
	//public int playerCurrentHP;
	//private static gamestate instance;
	public float time_between_spawns;
	private float time_since_start = 0f;
	public Transform prefab;
	private float width;
	private float height;
	private int num_of_cats = 1;
	public int playerHP = 5;
	public GameObject losebanner;

	//input
	public LayerMask touchInputMask;
	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;

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
		int timer = (int)Mathf.Ceil (time_since_start);
		if (timer % time_between_spawns == 0 && timer/time_between_spawns == num_of_cats) 
		{
			
			Vector3 position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
			while(Physics.CheckSphere(position, 6))
			{
				position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
			}
			Instantiate(prefab, position, prefab.rotation);
			num_of_cats= num_of_cats +1;
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
}
