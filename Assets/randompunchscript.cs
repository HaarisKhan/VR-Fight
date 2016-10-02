using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class randompunchscript : MonoBehaviour {
    public GameObject head;
    private IEnumerator routine;
    private IEnumerator delay;

    public AudioSource source;
    public AudioClip sword1;
    public AudioClip sword2;
    public AudioClip death;
    public AudioClip evil;

    public int myHealth = 100;
    public bool isGoodPunch = true;
    public bool hit = false;

    public Text myHealthText;
    public GameObject caesar;
    public Text result;
    public Slider healthSlider;

    // GameObject fist;
    //public GameObject right;

    //private bool hand;

    // Use this for initialization
    void Start () {
        StartCoroutine(Delay(Random.Range(0.2f, 0.6f)));
        source.clip = evil;
        source.Play();
    }

    // Update is called once per frame
    void Update () {
        
        if(myHealth <= 0)
        {
            // Debug.Log("Caesar lives another day");
            myHealthText.text = "Caesar lives another day!  ";
            Destroy(caesar);
            result.text = "You lose!";
            StartCoroutine(Restart());
        }
    }

    IEnumerator PunchLocation(GameObject glove)
    {
        while (true)
        {
            float duration = 1.0f;
            Vector3 startPosition = glove.transform.position;

            Vector3 headPosition = head.transform.position;
            float width = glove.transform.localScale.z;
            Vector3 endPosition = new Vector3(headPosition.x + Random.Range(-4, 4), headPosition.y + Random.Range(-5, -2), headPosition.z - width);
            isGoodPunch = true;
            hit = false;
            for (float i = 0; i < duration && isGoodPunch; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }

            if (isGoodPunch)
            {
                glove.transform.position = endPosition;
                myHealth -= 10;
                source.clip = death;
            }

            else
            {
                endPosition = glove.transform.position;
                myHealth -= 5;
                if ((Random.Range(0, 1)) <= .5)
                {
                    source.clip = sword1;
                } else
                {
                    source.clip = sword2;
                }
            }

            healthSlider.value = myHealth;




            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(endPosition, startPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }
          
            
            glove.transform.position = startPosition;

            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));
            source.Play();

        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        StartCoroutine(PunchLocation(this.gameObject));


    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);

        // Code to execute after the delay
        SceneManager.LoadScene(0);
    }
}
