using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

    public GameObject task;

	public int buildLevel = 0;
	public int buildFinish = 0;

    public float successPoints = 10;
    public float failurePoints = 5;

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
        GameManager.Instance.currentScore += successPoints;
		Debug.Log ("Job's done!");
        Destroy(gameObject);
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
            GUILayout.Label("Speed: " + ConvBelt.Instance.Speed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Build")
        {
            Instantiate(task, transform.position + new Vector3 (14f, 0, 0), Quaternion.identity);
        }
    }

    void OnTriggerStay(Collider other)
    {
        canBuild = true;
    }

}
