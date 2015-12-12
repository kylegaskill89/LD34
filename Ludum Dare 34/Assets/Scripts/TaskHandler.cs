using UnityEngine;
using System.Collections;

public class TaskHandler : MonoBehaviour {

	public int buildLevel = 0;
	public int buildFinish = 0;

	public bool canFinish = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			buildLevel += 1;
			Debug.Log (buildLevel);
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
				buildLevel = 0;
			}
		}

	}
}
