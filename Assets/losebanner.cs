using UnityEngine;
using System.Collections;

public class losebanner : MonoBehaviour {
	private float width;
	private float height;
	public GameObject loseprefab;

	void Awake(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Use this for initialization
	void Start () {
		height = 2.0f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
		float curr_width = loseprefab.GetComponent<Renderer> ().bounds.size.x;
		float curr_height = loseprefab.GetComponent<Renderer>().bounds.size.y;
		Vector3 scale_width = loseprefab.transform.localScale;
		Vector3 scale_height = loseprefab.transform.localScale;

		scale_width.x = width * scale_width.x / curr_width;
		scale_height.y = height * scale_height.y / curr_height;

		loseprefab.transform.localScale = new Vector3 (scale_width.x, scale_height.y, 1);
		Vector3 pos = new Vector3(0,50,50);
		Instantiate(loseprefab, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
