using UnityEngine;
using System.Collections;

public class DebugControls : MonoBehaviour {

	

	// Use this for initialization
	void Start () 
	{

	}

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.KeypadMinus))
		{
            GameManager.Instance.currentScore -= 10;
		}

        if (Input.GetKeyDown (KeyCode.KeypadPlus))
        {
            GameManager.Instance.currentScore += 10;
        }
	}

}
