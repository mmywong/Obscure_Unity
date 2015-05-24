using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
	private GameManager gamemanager;
	Image Health;
	void Awake(){
		gamemanager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Use this for initialization
	void Start () 
	{
		Health = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update (){
		float playerHP = gamemanager.getPlayerHP ();
		Health.fillAmount = Mathf.Lerp(Health.fillAmount, (float)playerHP / 5, 0.02f);
	}
}