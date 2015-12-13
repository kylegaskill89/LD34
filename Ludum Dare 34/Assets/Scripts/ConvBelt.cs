using UnityEngine;
using System.Collections;

public class ConvBelt : MonoBehaviour {

    public float Speed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);	    
	}
}
