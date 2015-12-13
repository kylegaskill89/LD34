using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public float currentScore = 100.0f;
    public float minScore = 0.0f;
    public float maxScore = 200.0f;

    private bool gameOver = false;

	// Use this for initialization
	void Start () 
    {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentScore <= minScore)
        {
            gameOver = true;
        }

        if (currentScore >= maxScore)
        {
            currentScore = maxScore;
        }

        if (gameOver)
        {
            if(Input.anyKeyDown)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

        }


	}

    void OnGUI ()
    {
        GUILayout.Label("Points: " + currentScore);

        if (gameOver)
        {
            GUILayout.Label ("You have been sent home! Press any key to restart.");
        }
    }
}
