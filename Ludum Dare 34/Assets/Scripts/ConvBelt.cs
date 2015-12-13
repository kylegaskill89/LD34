using UnityEngine;
using System.Collections;

public class ConvBelt : MonoBehaviour {

    public static ConvBelt Instance;
    
    public float Speed = 0.0f;
    public float maxSpeedUp = .07f;
    public float minSpeedUp = .02f;

    public float maxSpeed = 7;

	// Use this for initialization
	void Start ()
    {
        Instance = this;
        StartCoroutine(speedUp());
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    IEnumerator speedUp()
    {
        while (Speed > maxSpeed)
        {
            yield return new WaitForSeconds(15);
            Speed += (Random.Range(minSpeedUp, maxSpeedUp));
        }
    }
}
