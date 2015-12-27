using UnityEngine;
using System.Collections;

public class TaskCreator : MonoBehaviour {

    public GameObject task;

	
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Build")
        {
            GameObject createdTask = Instantiate(task, transform.position + new Vector3 (21f, 0, 0), Quaternion.identity) as GameObject;
            createdTask.name = task.name;
        }
    }
}
