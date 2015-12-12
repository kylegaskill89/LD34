using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public float currentScore = 100.0f;
	public float minScore = 0.0f;

    private bool gameOver = false;

	// Use this for initialization

	void Start ()
    {
	
	}

	// Update is called once per frame

	void Update ()
    {

		if (currentScore <= minScore)
		{
			gameOver = true;
		}

        if (gameOver)
        {
            if (Input.anyKeyDown) 
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	
	}

    void OnGUI ()
    {
        if(gameOver)
        { 

            GUILayout.Label ("You have been sent home! Press any key to restart.");

        }
    }
}