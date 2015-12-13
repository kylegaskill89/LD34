using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public float currentScore = 100f;
    public float minScore = 0f;
    public static float highScore = 0.0f;

    public bool gameOver = false;

	// Use this for initialization
	void Start () 
    {
        Instance = this;
        loadHighScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentScore <= minScore)
        {
            failState();
        }

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        if (gameOver)
        {
            Time.timeScale = 0;
        } 
        else
        {
            Time.timeScale = 1;
        }


        // DEBUG

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            currentScore -= 50;
        }


	}

    void OnGUI ()
    {
        int Score = (int)currentScore;
        int currentHighScore = (int)highScore;
        GUILayout.Label("Points: " + Score.ToString());
        GUILayout.Label("High Score: " + currentHighScore.ToString());

        if (gameOver)
        {
            GUILayout.Label ("You have been sent home! Press any key to restart.");
        }
    }

    void failState()
    {
        gameOver = true;
        
        if(Input.anyKeyDown)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

       saveHighScore();
    }

    void OnApplicationExit()
    {
        saveHighScore();
    }

    void saveHighScore()
    {
        PlayerPrefs.SetInt("Highscore", (int)highScore);
        PlayerPrefs.Save();
    }

    void loadHighScore()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
    }
}
