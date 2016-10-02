using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {

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
            other.GetComponent<randompunchscript>().isGoodPunch = false;

        }
    }

}
