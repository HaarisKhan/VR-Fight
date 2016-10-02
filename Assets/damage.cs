using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class damage : MonoBehaviour {
    public int health;
    public GameObject caesar;
    public Text CaesarHealthText;
    public Text result;
    public Slider healthSlider;

    public AudioSource source;
    public AudioClip sword1;
    public AudioClip sword2;
    public AudioClip death;
    public AudioClip evil;



    // Use this for initialization
    void Start () {
        health = 100;
        healthSlider.value = health;
        source.clip = evil;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0)
        {
            // Debug.Log("I'm dead!");
            CaesarHealthText.text = "Caesar's dead. Again."; 
            Destroy(caesar);
            result.text = "You win!";
        }
    }

    void OnCollisionExit(Collision collision)
    {
        health -= 3;
        healthSlider.value = health;
        if (Random.Range(0, 1) <= .5f)
        {
            source.clip = sword1;
        }
        else
        {
            source.clip = sword2;
        }

        source.Play();
        // Debug.Log("Ouch!");

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);

        // Code to execute after the delay
        SceneManager.LoadScene(0);


    }
}
