using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class damage : MonoBehaviour {
    int health;
    public GameObject caesar;
    public Text CaesarHealthText;
    public Text result;

    // Use this for initialization
    void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0)
        {
            // Debug.Log("I'm dead!");
            CaesarHealthText.text = "Caesar's dead. Again."; 
            Destroy(caesar);
            result.text = "You win!";
            StartCoroutine(Restart());
            StartCoroutine(Restart());


        }
    }

    void OnCollisionExit(Collision collision)
    {
        health -= 3;
        // Debug.Log("Ouch!");
        CaesarHealthText.text = "Caesar's health: " + health.ToString();

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);

        // Code to execute after the delay
        SceneManager.LoadScene(0);


    }
}
