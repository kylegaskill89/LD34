using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

	public int buildLevel = 0;
	public int buildFinish = 0;

    public float successPoints = 10.0f;
    public float failurePoints = 5.0f;

	public bool canFinish = false;
	

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
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

        if (!canFinish && Input.GetButtonDown("Fire2"))
        {
            taskFailed();
        }

	}

	void Finish ()
	{
		buildLevel = 0;
        GameManager.Instance.currentScore += successPoints;
		Debug.Log ("Job's done!");
	}

    void taskFailed ()
    {
        buildLevel = 0;
        GameManager.Instance.currentScore -= failurePoints;
        Debug.Log("Failed");
    }
}
