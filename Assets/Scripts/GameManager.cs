using UnityEngine;
using System.Collections;

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
	public int playerHP;
	// Use this for initialization
	void Start () {
		height = 2.0f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		//GameObject sceneCamObj = GameObject.Find ("SceneCamera");
		//Debug.Log (sceneCamObj.camera.pixelRect);
	}
	
	// Update is called once per frame
	void Update () {
		time_since_start += Time.deltaTime;
		int timer = (int)Mathf.Ceil (time_since_start);
		if (timer % time_between_spawns == 0 && timer/time_between_spawns == num_of_cats) {

			Vector3 position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
	
			while(Physics.CheckSphere(position, 6)){
				position = new Vector3(Random.Range (-(150/2), 150 / 2), Random.Range (2,80), 50);
			}
			Instantiate(prefab, position, Quaternion.identity);
			num_of_cats= num_of_cats +1;
		}
	}

	public void decHP(){
		playerHP -= 1;
	}

}
