﻿using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKeyDown) 
		{
			Application.LoadLevel(levelName);
		}
	}
}
