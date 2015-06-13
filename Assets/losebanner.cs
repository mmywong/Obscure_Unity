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
		Vector3 scale = loseprefab.transform.localScale;

		scale.x = width * scale.x / curr_width;
		scale.y = height * scale.y / curr_height;
	
		loseprefab.transform.localScale += new Vector3(scale.x, scale.y,0);

		Vector3 pos = new Vector3(0,0,120);
		Instantiate(loseprefab, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 backpos = new Vector2 (width - 10, height - 10);

		//backbutton.anchoredPosition = backpos;
	}

}
