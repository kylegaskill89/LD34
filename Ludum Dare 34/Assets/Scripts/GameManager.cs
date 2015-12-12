using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float currentScore = 100.0f;
	public float minScore = 0.0f;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentScore <= minScore)
		{
			gameOver();
		}
	
	}

	void gameOver ()
	{
		Debug.Log ("You have sent home! Press any key to restart.");

		if (Input.anyKeyDown) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
