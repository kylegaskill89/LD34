using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

    public GameObject task;
    public GameObject taskText;
    public GameObject wrapppedGift;
    public GameObject explosion;

	public int buildLevel = 0;
	public int minFinish = 1;
    public int maxFinish = 10;

    public int finishLevel;

    public float successPoints = 10f;
    public float failurePoints = 5f;

	public bool canFinish = false;

    public bool canBuild = false;
        


    void Awake ()
    {
        finishLevel = (Random.Range(minFinish, maxFinish));

    }
	
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

		if (buildLevel == finishLevel) 
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

        if (buildLevel > finishLevel && canBuild)
        {
            taskFailed();
        }

        taskText.GetComponent<TextMesh>().text = ((finishLevel - buildLevel).ToString());
	}

	void Finish ()
	{
        GameManager.Instance.currentScore += successPoints;
		Debug.Log ("Job's done!");
        GameObject successfulGift = Instantiate(wrapppedGift, transform.position, Quaternion.identity) as GameObject;
        successfulGift.name = wrapppedGift.name;
        Destroy(gameObject);
	}

    void taskFailed ()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameManager.Instance.currentScore -= failurePoints;
        Instantiate(task, transform.position + new Vector3 (21f, 0, 0), Quaternion.identity);
        canBuild = false;
        Destroy(gameObject);
        Debug.Log("Failed");
    }


    void OnGUI ()
    {
        if (canBuild)
        {
            GUILayout.Label("");
            GUILayout.Label("");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Build")
        {
            GameObject createdTask = Instantiate(task, transform.position + new Vector3 (21f, 0, 0), Quaternion.identity) as GameObject;
            createdTask.name = task.name;
        }
    }

    void OnTriggerStay(Collider other)
    {
        canBuild = true;
    }

}
