using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

    public GameObject task;
    public GameObject taskText;
    public GameObject wrapppedGift;

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

        if (buildLevel > finishLevel)
        {
            taskFailed();
        }

        taskText.GetComponent<TextMesh>().text = ((finishLevel - buildLevel).ToString());
	}

	void Finish ()
	{
        GameManager.Instance.currentScore += successPoints;
		Debug.Log ("Job's done!");
        Instantiate(wrapppedGift, transform.position, Quaternion.identity);
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
