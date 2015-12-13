using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(ConvBelt.Instance.Speed * Time.deltaTime * -1, 0, 0);     
	}
}
