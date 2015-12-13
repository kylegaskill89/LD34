using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

	public int buildLevel = 0;
	public int buildFinish = 0;

    public float successPoints = 10.0f;
    public float failurePoints = 5.0f;

	public bool canFinish = false;

    public bool canBuild = false;



    void Start ()
    {

    }
	

	// Update is called once per frame
	void Update ()
	{
		if(canBuild && Input.GetButtonDown("Fire1"))
		{
			buildLevel += 1;
		}

		if (buildLevel == buildFinish) 
		{
			canFinish = true;
		}
		else 
		{
			canFinish = false;
		}

		if (canFinish)
		{
			if(Input.GetButtonDown ("Fire2"))
			{
				Finish();
			}
		}

        if (!canFinish && canBuild && Input.GetButtonDown("Fire2"))
        {
            taskFailed();
        }

        if (buildLevel > buildFinish)
        {
            taskFailed();
        }

	}

	void Finish ()
	{
		buildLevel = 0;
        GameManager.Instance.currentScore += successPoints;
        Destroy (gameObject);
		Debug.Log ("Job's done!");
	}

    void taskFailed ()
    {
        Destroy(gameObject);
        GameManager.Instance.currentScore -= failurePoints;
        Debug.Log("Failed");
    }

    void OnGUI ()
    {
        if (canBuild)
        {
            GUILayout.Label("");
            GUILayout.Label("");
            GUILayout.Label("Build Level: " + buildLevel);
        }

    }

    void OnTriggerStay(Collider other)
    {
        canBuild = true;
    }

    void OnTriggerExit(Collider other)
    {
        canBuild = false;
    }
}
