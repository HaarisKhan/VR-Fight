using UnityEngine;
using System.Collections;

public class motorvibration : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<randompunchscript>())
        {
            other.GetComponent<randompunchscript>().hit = true;

        }
    }
}
