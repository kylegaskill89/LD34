using UnityEngine;
using System.Collections;

public class CanBuild : MonoBehaviour {

    public bool inTrigger = false;

    public static CanBuild Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerStay(Collider other)
    {
        if (inTrigger == false)
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

}
